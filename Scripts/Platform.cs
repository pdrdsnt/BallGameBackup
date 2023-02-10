using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour , ISwitch
{
    Vector3 initialPosition;
    [SerializeField]Vector3[] stateVectors;
    Vector3 targetPosition;
    [SerializeField]private int _state;
    [SerializeField]private bool _on;
    public bool on {get => _on; set => _on = value;}
    public int state { get => _state; set => _state = value;}
    public int initialState;
    public float velocity = .5f;
    private void Awake()
    {
        state = initialState;
        initialPosition = transform.position;
        targetPosition = initialPosition + stateVectors[state];
    }

    public void TurnOn()
    {
        on = !on;
    }
    public void ChangeState()
    {
        if(stateVectors.Length == 0)return;
        
        state++;
        if(state >= stateVectors.Length)state = 0;

        targetPosition = initialPosition + stateVectors[state];
    }

    void Update()
    {
        if(Vector3.Distance(targetPosition,transform.position) < .02f)
        {
            if(on)ChangeState();
            
        }else
        {
            Vector3 vel = (targetPosition - transform.position).normalized * velocity * Time.deltaTime;
            transform.localPosition += vel; 
        }       
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.GetContact(0).normal.y < .5f)
        {
            other.transform.SetParent(transform,true);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.transform.parent != transform){
            if(other.GetContact(0).normal.y < .5f){
                other.transform.SetParent(transform,true);
            }
        } 
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.transform.parent == transform)
        {
            other.transform.SetParent(null,true);
        }
    }
}
