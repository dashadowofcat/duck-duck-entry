using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraShake : MonoBehaviour
{
    public float tension;
    public float dampening;


    private Vector2 BasePosition;
    private Vector2 CurrentPosition;

    private Vector2 velocity;

    private Vector3 OriginalPosition;

    private void Start()
    {
        OriginalPosition = transform.position;
    }

    void Update()
    {
        Vector2 heightOffset = BasePosition - CurrentPosition;
        velocity += tension * heightOffset - velocity * dampening;
        CurrentPosition += velocity;

        transform.position = (OriginalPosition + (Vector3)CurrentPosition) / 10;
    }

    public void Shake(Vector2 Direction)
    {
        velocity += Direction;
    }
    
}
