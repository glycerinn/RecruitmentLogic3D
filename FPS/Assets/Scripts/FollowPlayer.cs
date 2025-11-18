using UnityEngine;
using UnityEngine.UIElements;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float offsetX, offsetZ;
    [SerializeField] private float lerpSpeed;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, 
        new Vector3(target.position.x + offsetX, transform.position.y, target.position.z + offsetZ), lerpSpeed);
    }
}
