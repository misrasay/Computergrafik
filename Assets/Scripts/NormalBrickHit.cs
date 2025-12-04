using UnityEngine;

public class NormalBrickHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ball"))
            return;

        Destroy(gameObject);
    }
}
