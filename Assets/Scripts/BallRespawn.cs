using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallRespawn : MonoBehaviour
{

    [SerializeField] private float startSpeed = 10f;

    private Vector3 startPosition;
    private Vector3 startDirection = Vector3.down;
    private Rigidbody rb;
    private TrailRenderer trail;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        trail = GetComponent<TrailRenderer>();

        startPosition = transform.position;
        rb.velocity = startDirection * startSpeed;

    }

    void FixedUpdate()
    {
        if (Time.timeScale == 0)
            return;

        if (transform.position.y < -5)
        {
            trail.enabled = false;
            Respawn();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            trail.enabled = false;
            Respawn();
        }
    }

    private void Respawn()
    {

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.position = startPosition;
        transform.position = startPosition;

        trail.Clear();
        trail.enabled = true;

        rb.velocity = startDirection * startSpeed;
    }
}
