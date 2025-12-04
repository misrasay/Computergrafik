using UnityEngine;

public class MathBrickHit : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ball"))
            return;

        GenerateEquation equation = FindObjectOfType<GenerateEquation>();
        if (equation != null)
        {
            equation.ShowEquation();
        }


        Destroy(gameObject);
   
    }
}
