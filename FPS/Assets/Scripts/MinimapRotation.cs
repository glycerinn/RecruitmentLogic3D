using UnityEngine;

public class MinimapRotation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eulerAngles = transform.eulerAngles;
        eulerAngles.y = 0;
        eulerAngles.z = 0;
        transform.eulerAngles = eulerAngles;
    }
}
