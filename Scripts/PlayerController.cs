using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cam;
    public float force = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(cam == null)cam = Camera.main.transform;
    }

    void Update()
    {           
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 dir = cam.right * x + cam.forward * y;
        dir.y = 0;

        dir = dir.normalized * force;

        rb.AddForce(dir);
    }
}
