using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{

    [SerializeField] private float paddleSpeed = 50f;

    [SerializeField] private ArrowMovement arrow;


    void Start()
    {

        
    }

    void Update()
    {

        if (Time.timeScale == 0f)
            return;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Lerp(transform.position.x, worldPosition.x, paddleSpeed * Time.deltaTime);

        transform.position = newPosition;

    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody ballRb = collision.rigidbody;

        if (ballRb != null)
        {
            Vector3 dir = arrow.GetDirection();

            if (dir.y <= 0f)
                dir.y = 0.1f;

            dir = dir.normalized;

            ballRb.velocity = dir;
        }
    }
}
