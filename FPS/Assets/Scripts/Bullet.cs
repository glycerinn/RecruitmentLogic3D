using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Target")){
            print("hit");
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Plane")){
            Destroy(gameObject);
        }
    }
}
