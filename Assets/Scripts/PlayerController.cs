using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5;

    public Vector2 movementDirection;

    public InputAction moveAction;
    private RigidBody2D rbody;
    private SpriteRenderer renderer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        renderer = GetComponent<Spriterenderer>();
        rbody = GetComponent<RigidBody2D>();

        moveAction = InputSystem.actions["Move"];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {

    }
}
