using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    public CheckPoint currentCheckPoint = null;
    public int condition = 0;
    public bool Reset()
    {
        condition--;

        if(condition > 0)return false;

        if(currentCheckPoint == null)
        {
            transform.position = Vector3.zero;
        
        }else
        {
            transform.position = currentCheckPoint.transform.position;
        }

        return true;
    }
}

