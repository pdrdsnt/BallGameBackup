using System;
using System.Collections.Generic;
using UnityEngine;

public class ResetState : MonoBehaviour, IResetable
{
    [SerializeField]
    ValueSwitch[] valueSwitches;
    Dictionary<ISwitch, int> switchInitialValuePair;
    int _condition;
    public bool Reset()
    {
        foreach(var k in switchInitialValuePair)
        {
            k.Key.state = k.Value;
        }

        return true;
    }



    private void OnValidate() {

        switchInitialValuePair = new Dictionary<ISwitch, int>();
        
        foreach(var v in valueSwitches)
        {
            if(v.switchInstace == null)continue;
            switchInitialValuePair.Add(v.switchInstace as ISwitch,v.startValue);
        }

    }

}






[Serializable]
struct ValueSwitch 
{    
    public  UnityEngine.Object switchInstace;
    public int startValue;
}


