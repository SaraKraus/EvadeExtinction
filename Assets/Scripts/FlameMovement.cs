using UnityEngine;

public class FlameMovement : MonoBehaviour
{
float speed = 5f; // Units per second

    
void Update()
{
transform.Translate(Vector2.up * speed * Time.deltaTime);
}
    }
