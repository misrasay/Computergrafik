using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedSpeed : MonoBehaviour

{

    Rigidbody rb;
    [SerializeField] float fixedSpeed = 10f;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {

        if (Time.timeScale == 0f)
            return;
    
        rb.velocity = rb.velocity.normalized * fixedSpeed;

    }
}
