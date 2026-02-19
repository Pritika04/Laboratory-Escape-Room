using UnityEngine;

public class SpinItem : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up, 50 * Time.deltaTime);
        
        float newY = transform.position.y + (Mathf.Sin(Time.time * 2) * 0.001f);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}