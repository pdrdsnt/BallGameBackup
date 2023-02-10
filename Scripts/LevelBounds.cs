using System.Collections.Generic;
using UnityEngine;

public class LevelBounds : MonoBehaviour
{    
    public List<ResetState> toReset;

    private void OnTriggerEnter(Collider other) {
        
        var r = other.GetComponent<ResetPlayer>();

        if (r == null)return;

        r.condition++;     
    }

    private void OnTriggerExit(Collider other) {

        var r = other.GetComponent<ResetPlayer>();

        if(r == null)return;

        if(r.Reset())
        {
            if(toReset == null)return;
            if(toReset.Count == 0)return;

            foreach(var v in toReset)
            {
                if(v == null)continue;
                v.Reset();
            }
        }
    }
}
