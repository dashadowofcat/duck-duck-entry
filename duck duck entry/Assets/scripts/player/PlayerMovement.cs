using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float MovementSpeed;

    public Vector2 Velocity;

    public float VelocityLimit;

    public float Deceleration;

    public float EdgePrevention;

    private Vector2 input;

    [Header("Collision")]
    public LayerMask GroundMask;

    void Start()
    {
        
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Velocity += input * MovementSpeed * Time.deltaTime;

        Velocity = (Velocity / Deceleration);

        Velocity.x = Mathf.Clamp(Velocity.x, -VelocityLimit, VelocityLimit);

        Velocity.y = Mathf.Clamp(Velocity.y, -VelocityLimit, VelocityLimit);

        Vector2 potentialX = transform.position + new Vector3(Velocity.x,0) * Time.deltaTime;

        Vector2 potentialY = transform.position + new Vector3(0, Velocity.y) * Time.deltaTime;

        if (IsGrounded(potentialX))
        {
            Velocity.x = 0;
        }

        if (IsGrounded(potentialY))
        {
            Velocity.y = 0;
        }

        transform.position += (Vector3)Velocity * Time.deltaTime;

    }


    public bool IsGrounded(Vector2 position)
    {
        return Physics2D.CircleCast(position, .2f, Vector2.zero, GroundMask);
    }
}
