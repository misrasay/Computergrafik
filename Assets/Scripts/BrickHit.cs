using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            gameObject.SetActive(false);

            GenerateEquation equation = FindObjectOfType<GenerateEquation>();
            equation.Generate();

            Destroy(gameObject);
        }
    }
}
