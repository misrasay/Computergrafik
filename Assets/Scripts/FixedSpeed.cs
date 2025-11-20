using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedSpeed : MonoBehaviour

{

    Rigidbody rb;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.down);
        
    }

    void FixedUpdate()
    {

        if (Time.timeScale == 0f)
            return;
    
        rb = GetComponent<Rigidbody>();
        float fixedSpeed = 10f;
        rb.velocity = rb.velocity.normalized * fixedSpeed;

    }
}
