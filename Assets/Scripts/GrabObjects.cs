using UnityEngine;
using System.Collections;

//using UnityEngine.InputSystem;

public class GrabObjects : MonoBehaviour
{
    [SerializeField] private Transform grabPoint;
    private Transform lastObject;
    private int layerIndex;

    private float stackHeight = 1.5f; //decides how far from the player the first animal is displayed

    // private void Update()
    // {
    //      if(OnTriggerEnter2D == true)
    //      {
    //          get transform;
    //      }
    // }
    private void Start()
    {
        layerIndex = LayerMask.NameToLayer("Objects");
        lastObject = grabPoint;
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if(collision.gameObject.layer == layerIndex )
    //     {
    //         GameObject obj = collision.gameObject;

    //         Rigidbody2D rb = obj.GetComponentInParent<Rigidbody2D>();
    //         if (rb == null)
    //         {
    //             Debug.LogWarning(obj.name + "has no RigidBody2D");
    //             return;
    //         }
    //         rb.isKinematic = true;
            
    //         SpriteRenderer objSR = obj.GetComponentInParent<SpriteRenderer>();

    //         if (objSR == null)
    //         {
    //             Debug.LogWarning(obj.name + "has no SpriteRenderer");
    //             return;                
    //         }

    //         float objHeight = 1f;

    //         //objSR != null;

    //         objHeight = objSR.sprite.bounds.size.y * 0f; //Decides how far the second animal is drawn above the previous one

    //         obj.transform.SetParent(grabPoint);
    //         obj.transform.localPosition = new Vector3(0, stackHeight, 0); //the two numbers just make the sprites disapear???

    //         stackHeight += objHeight;

    //              if (MenuAudioManager.Instance != null && MenuAudioManager.Instance.collectibleSFX != null)
    //          {
    //              MenuAudioManager.Instance.PlaySFX(MenuAudioManager.Instance.collectibleSFX);
    //          }
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered by: " + collision.name);

        if (collision.gameObject.layer != layerIndex) return;

        GameObject obj = collision.gameObject;

        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("No RB2d on object: " + obj.name);
            return;
        }

        rb.isKinematic = true;

        SpriteRenderer objSR = obj.GetComponent<SpriteRenderer>();
        if (objSR == null)
        {
            Debug.LogError("No SR on object: " + obj.name);
            return;
        }

        float objHeight = 1f;

        if (objSR.sprite != null)
        {
            objHeight = objSR.sprite.bounds.size.y * 0f;
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