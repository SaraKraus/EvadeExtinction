using UnityEngine;

public class FlameMovement : MonoBehaviour
{

    public GameObject Flames;
    public GameObject End;
        public float speed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        Flames.transform.position = Vector2.MoveTowards(Flames.transform.position, End.transform.position, speed);
    }
}
