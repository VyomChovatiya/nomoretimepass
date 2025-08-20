using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardSpeed = 10f;     // constant forward speed
    public float horizontalSpeed = 7f;   // how fast you strafe
    public float smoothness = 5f;        // higher = smoother movement
    public float jumpForce = 8f;
    private bool isGrounded = true;
    private int numJumps = 2;

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //  Constant forward velocity 
        Vector3 targetVelocity = new Vector3(forwardSpeed, rb.linearVelocity.y, rb.linearVelocity.z);

        //  Horizontal movement 
        float horizontal = 0f;
        if (Input.GetKey("a")) horizontal = horizontalSpeed;
        if (Input.GetKey("d")) horizontal = -horizontalSpeed;

        targetVelocity.z = horizontal;

        //  Smoothly interpolate current velocity towards target 
        rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, targetVelocity, Time.fixedDeltaTime * smoothness);
    }

    void Update()
    {
        //  Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && (numJumps > 0))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            numJumps--;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
}

