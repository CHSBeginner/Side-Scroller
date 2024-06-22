using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    static float t = 0.0f; 
    public float distance = 2.0f; 
    public float speed = 1.0f; 
    private float originalPos;

    void Start()
    {
        originalPos = transform.position.x; 
    }

    void Update()
    {
        transform.position = new Vector3(originalPos + Mathf.Sin(t) * distance, transform.position.y, transform.position.z);
        t += speed * Time.deltaTime;
    }
}
