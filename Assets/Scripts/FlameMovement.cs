using UnityEngine;

public class FlameMovement : MonoBehaviour
{

    public GameObject Flames;
    public GameObject End;
        public float speed;

    void FixedUpdate()
    {
        Flames.transform.position = Vector2.MoveTowards(Flames.transform.position, End.transform.position, speed);
    }
}
