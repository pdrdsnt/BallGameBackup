using System;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    public List<SwichtOptions> iSwitchInstances;
    public Material buttonMaterial;
    public bool changeOnExit;

    public bool triggered = false;
    public int type;
    [Serializable]
    public struct SwichtOptions
    {
        public UnityEngine.Object iswichInstance;
        public bool TurnOn;
    }

    private void UpdateShader()
    {
        if(buttonMaterial == null)buttonMaterial = GetComponent<MeshRenderer>().material;

        if(buttonMaterial == null)return;

        ISwitch s = null;
        
        foreach(var k in iSwitchInstances)
        {
            var j = k.iswichInstance as MonoBehaviour;

            if(j.enabled){

                s = (k.iswichInstance as ISwitch);   

                if (s == null) return;
                
                if(s is Platform){type = 0;}else
                if(s is SwitchScripts){type = 1;}  
                buttonMaterial.SetFloat("_Hold",k.TurnOn ? 1 : 0);   
                buttonMaterial.SetFloat("_State", s.state);
                buttonMaterial.SetFloat("_On", s.on ? 1 : 0);
                buttonMaterial.SetFloat("_Trigger", triggered ? 1 : 0);
                buttonMaterial.SetFloat("_Type", type);  
                
                break; 
            }

        }     

    }
    private void OnValidate()
    {
        foreach (var obj in iSwitchInstances)
        {
            if (obj.iswichInstance == null)
            {
                continue;
            }
        }
    }

    public void Trigger()
    {
        for (int i = 0; i < iSwitchInstances.Count; i++)
        {
            ISwitch v = iSwitchInstances[i].iswichInstance as ISwitch;

            if (iSwitchInstances[i].TurnOn)
            {
                v.TurnOn();
            }
            else
            {
                v.ChangeState();
            }
        }
    }
    private void FixedUpdate() {
        UpdateShader();
    }
    private void Start()
    {
        buttonMaterial = GetComponent<MeshRenderer>().material;

        for (int i = 0; i < iSwitchInstances.Count; i++)
        {
            SwichtOptions obj = iSwitchInstances[i];
            if (obj.iswichInstance == null)
            {
                iSwitchInstances.Remove(obj);
                i--;
            }
        }

        if (buttonMaterial == null) { buttonMaterial = GetComponent<MeshRenderer>().material; }

    }
    private void OnTriggerEnter(Collider other)
    {

        Trigger();
        triggered = true;

    }

    private void OnTriggerExit(Collider other)
    {
        triggered = false;

        if (changeOnExit)
        {

            Trigger();

            UpdateShader();
        }
    }


}
