using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedSpeed : MonoBehaviour

{

    Rigidbody rb;
    [SerializeField] float fixedSpeed = 10f;
    [SerializeField] private float answerModeSpeed = 5f;


    void Start()
    {

        rb = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {

        if (Time.timeScale == 0f)
            return;

        if (rb.velocity.sqrMagnitude < 0.0001f)
            return;

        float targetSpeed = AnswerModeState.IsAnswerMode ? answerModeSpeed : fixedSpeed;

        Vector3 direction = rb.velocity.normalized;
        rb.velocity = direction * targetSpeed;

    }
}
