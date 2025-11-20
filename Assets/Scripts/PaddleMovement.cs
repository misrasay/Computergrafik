using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{

    [SerializeField]
    private float paddleSpeed = 30f;

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
            Vector3 hitpoint = collision.contacts[0].point;
            float hitfactor = (hitpoint.x - transform.position.x) / transform.localScale.x;
            Vector3 newDirection = new Vector3(hitfactor, 1, 0).normalized;
            ballRb.velocity = newDirection;
        }
    }
}
