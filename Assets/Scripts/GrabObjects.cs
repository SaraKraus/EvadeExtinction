using UnityEngine;

//using UnityEngine.InputSystem;

public class GrabObjects : MonoBehaviour
{
    [SerializeField]
    private Transform grabPoint;

    private GameObject grabbedObject;
    private int layerIndex;

    private void Start()
    {
        layerIndex = LayerMask.NameToLayer("Objects");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == layerIndex && grabbedObject == null)
        {
            grabbedObject = collision.gameObject;

            Rigidbody2D rb = grabbedObject.GetComponent<Rigidbody2D>();
            rb.isKinematic = true;

           // grabbedObject.transform.position = grabPoint.position;
            grabbedObject.transform.SetParent(grabPoint);
            grabbedObject.transform.localPosition = Vector3.zero;
        }
    }
}

/*    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);

        if (hitInfo.collider!=null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame && grabbedObject == null)
            {
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(grabPoint);
            }

            else if (Keyboard.current.spaceKey.wasPressedThisFrame && grabbedObject != null)
            {
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
            }
        }
        Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
    }
}
*/