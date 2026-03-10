using UnityEngine;

//using UnityEngine.InputSystem;

public class GrabObjects : MonoBehaviour
{
    [SerializeField]
    private Transform grabPoint;

    private Transform lastObject;
    private int layerIndex;

    private void Start()
    {
        layerIndex = LayerMask.NameToLayer("Objects");
        lastObject = grabPoint;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == layerIndex )
        {
            GameObject obj = collision.gameObject;

            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            rb.isKinematic = true;

            SpriteRenderer lastSR = lastObject.GetComponent<SpriteRenderer>();
            SpriteRenderer objSR = obj.GetComponent<SpriteRenderer>();

            float offset = 1f;

            if (lastSR != null && objSR != null)
            {
                offset = lastSR.bounds.size.y;
            }

            obj.transform.SetParent(lastObject);
            obj.transform.localPosition = new (0, offset, 0);

            lastObject = obj.transform;
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