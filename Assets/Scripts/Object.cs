using UnityEngine;

public class Object : MonoBehaviour
{
    //[SerializeField] private int value = 1;
    private bool hasTriggered;

    //private ObjectManager objectManager;

    // private void Start()
    // {
    //     objectManager = FindFirstObjectByType<ObjectManager>();
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            ObjectManager.Instance.ChangeObjects();
            //Destroy(gameObject);
        }
    }
}
