using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float moveSpeed = 10f;
    bool isFacingRight = false;
    float jumpPower = 10f;
    bool isGrounded = false;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckDistance = 0.12f;
    public Vector2 groundCheckOffset = new Vector2(0f, -0.5f);
    Rigidbody2D rb;
    Animator animator;

    [SerializeField] private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    private float jumpForce = 1;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");

        Vector2 rayOrigin = groundCheck != null ? (Vector2)groundCheck.position : (Vector2)transform.position + groundCheckOffset;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, groundCheckDistance, groundLayer);
        isGrounded = hit.collider != null;

        FlipSprite();

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            isGrounded = false;
            //animator.SetBool("isJumping", !isGrounded); 
            
             if (MenuAudioManager.Instance != null && MenuAudioManager.Instance.jumpSFX != null)
             {
                 MenuAudioManager.Instance.PlaySFX(MenuAudioManager.Instance.jumpSFX);
             }
        }

        if(animator != null)
        {
            animator.SetBool("isGrounded", isGrounded);
            animator.SetFloat("xVelocity", Mathf.Abs(horizontalInput));
        }

        if(isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else coyoteTimeCounter -= Time.deltaTime;
        if(jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        jumpBufferCounter = 0f;
        coyoteTimeCounter = 0f;
        isGrounded = false;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
       // animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));
      //  animator.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    void FlipSprite()
    { 
        if(isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    public void PlayRunSFX()
    {
         if (MenuAudioManager.Instance != null && MenuAudioManager.Instance.stepsSFX != null)
         {
             MenuAudioManager.Instance.PlaySFX(MenuAudioManager.Instance.stepsSFX);
         }
    }

    public void PlayJumpSFX()
    {
         if (MenuAudioManager.Instance != null && MenuAudioManager.Instance.jumpSFX != null)
         {
             MenuAudioManager.Instance.PlaySFX(MenuAudioManager.Instance.jumpSFX);
         }
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //    isGrounded = true;
    //    animator.SetBool("isJumping", isGrounded);
    // }
}

