using UnityEngine;

public class NewCollectible : MonoBehaviour
{
    float horizontalInput;
    float moveSpeed = 5f;
    bool isFacingRight = false;
    float jumpPower = 5f;
    public bool isGrounded = false;

    //private int cowCounter = 0;
   // public TMP Text counterText;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        FlipSprite();

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }

    void FlipSprite()
    {
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector2 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }


    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.CompareTag("Cow") && collision.gameObject.activeSelf == true)
        {
            collision.gameObject.SetActive(false);
            cowCounter += 1;
          //  counterText.text = "Cows: " + cowCounter;
        }
    }*/
}


