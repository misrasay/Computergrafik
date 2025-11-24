using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawn : MonoBehaviour
{

    [SerializeField] private float startSpeed = 10f;

    private Vector3 startPosition;
    private Vector3 startDirection = Vector3.down;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        rb.velocity = startDirection * startSpeed;

    }

    void FixedUpdate()
    {
        if (Time.timeScale == 0)
            return;

        if (transform.position.y < -5)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.position = startPosition;
        transform.position = startPosition;

        rb.velocity = startDirection * startSpeed;
    }
}
