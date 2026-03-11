using UnityEngine;

public class FlameMovement : MonoBehaviour
{
    public GameObject FinishPoint;
        public float speed;

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, FinishPoint.transform.position, speed);
    }
}
