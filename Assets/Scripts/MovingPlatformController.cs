using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovingPlatformController : MonoBehaviour
{
    public int motionRange;
    public float speed;
    public float direction;

    private bool movingForward = true;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(startPosition, transform.position) >= motionRange && movingForward)
        {
            direction = (direction + 180f) % 360f;
            movingForward = false;
        }
        else if (Vector3.Distance(startPosition, transform.position) <= 0.01f && !movingForward)
        {
            direction = (direction + 180f) % 360f;
            movingForward = true;
        }

        float radians = direction * Mathf.Deg2Rad;
        float xComponent = Mathf.Cos(radians);
        float yComponent = Mathf.Sin(radians);

        Vector3 movementVector = new Vector3(xComponent, yComponent) * speed * Time.deltaTime;
        transform.Translate(movementVector);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(null);
    }
}
