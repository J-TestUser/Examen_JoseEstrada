using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5;
    public float jumpForce = 13;

    public Vector2 movementDirection;

    private InputAction moveAction;
    private InputAction jumpAction;
    private Rigidbody2D rbody;
    private SpriteRenderer renderer;
    private GroundSensor sensor;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        rbody = GetComponent<Rigidbody2D>();
        sensor = GetComponentInChildren<GroundSensor>();

        moveAction = InputSystem.actions["Move"];
        jumpAction = InputSystem.actions["Jump"];
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = moveAction.ReadValue<Vector2>();


        if (movementDirection.x < 0)
        {
            renderer.flipX = true;
        }
        else if (movementDirection.x > 0)
        {
            renderer.flipX = false;
        }

        if (jumpAction.WasPressedThisFrame() && sensor.isGrounded)
        {
            rbody.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    void FixedUpdate()
    {
        rbody.linearVelocity = new Vector2 (movementDirection.x * movementSpeed, rbody.linearVelocity.y);
    }
}
