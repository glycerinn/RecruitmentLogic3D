using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Plane")){
            Destroy(gameObject);
        }
    }
}
