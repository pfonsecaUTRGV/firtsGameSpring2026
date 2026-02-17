using UnityEngine;

public class mc_movement : MonoBehaviour
{
    //[SerializeField] private float speed;
    private Rigidbody2D body;
    public float speed = 5f;
    Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

        body = GetComponent<Rigidbody2D>();
        GameSettings.Load();
        speed = GameSettings.PlayerSpeed;
    }

    // Update is called once per frame
    void Update()
{
    // Always pull the latest configured move speed (from Settings scene)
    speed = GameSettings.PlayerSpeed;

    // Read horizontal movement (platformer)
    float horizontalInput = Input.GetAxisRaw("Horizontal");

    // Set X velocity (keep current Y velocity)
    body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

    // Animation: use horizontal movement magnitude for "Speed"
    animator.SetFloat("speed", Mathf.Abs(horizontalInput));

    // Flip player when facing left/right
    if (horizontalInput > 0.01f)
        transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
    else if (horizontalInput < -0.01f)
        transform.localScale = new Vector3(-2.0f, 2.0f, 2.0f);

    // Jump (NOTE: this is a simple jump; ideally restrict to "grounded")
    if (Input.GetKeyDown(KeyCode.Space))
        body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
}
}
