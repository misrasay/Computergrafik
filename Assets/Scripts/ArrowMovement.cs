using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{


    [SerializeField] private float rotateSpeed = 120f;
    [SerializeField] private float maxAngle = 60f;
    [SerializeField] private Transform paddle;

    private float currentAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float input = 0f;

        if (Input.GetKey(KeyCode.D))
            input -= 1f;

        if (Input.GetKey(KeyCode.A))
            input += 1f;

        if (input != 0f)
        {
            currentAngle += input * rotateSpeed * Time.deltaTime;
            currentAngle = Mathf.Clamp(currentAngle, -maxAngle, maxAngle);

            transform.localRotation = Quaternion.Euler(0f, 0f, currentAngle);
        }
    }

    void LateUpdate()
    {
   
        transform.position = paddle.position;
    }

    public Vector3 GetDirection()
    {
        return transform.up.normalized;
    }

}
