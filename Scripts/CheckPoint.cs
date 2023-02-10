using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
        private void OnTriggerEnter(Collider other) {
        
        var r = other.GetComponent<ResetPlayer>();

        if(r == null)return;

        r.currentCheckPoint = this;

    }
}
