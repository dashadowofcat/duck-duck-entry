using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : MonoBehaviour
{
    private PlayerMovement Player;

    [Header("Dash")]
    public float DashDistance;

    [Header("Effects")]
    public CameraShake CameraShake;

    public float ShakeForce;

    private void Start()
    {
        Player = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            MousePos.z = 0;

            Vector3 DashPos = Vector3.MoveTowards(transform.position, MousePos, DashDistance);

            if (!Player.IsGrounded(DashPos))
            {
                transform.position = DashPos;
                Player.Velocity = Vector2.zero;

                CameraShake.Shake(Vector3.MoveTowards(transform.position, MousePos, 1) * ShakeForce);
            }
        }
    }
}
