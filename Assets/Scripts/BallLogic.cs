using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    /*[SerializeField] private Rigidbody2D rigidBody;*/

    [SerializeField] private Vector2 velocity;

    [SerializeField] private float speed;
    [SerializeField] private float gravityScale = 1f;

    [SerializeField] private TrajectoryRenderer trajectoryRenderer;
    private Rigidbody2D rigidBody;



    void Start()
    {
        speed = 100f;
        rigidBody = GetComponent<Rigidbody2D>();
        /*trajectoryRenderer = GetComponent<TrajectoryRenderer>();*/

        if (rigidBody != null)
        {
            // Set gravity scale
            rigidBody.gravityScale = gravityScale;
        }
    }

    private Vector3 GetDirection()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z));

        return (transform.position - worldMousePosition).normalized;

    }

    private void OnMouseDrag()
    {
        velocity = GetDirection() * speed;
        trajectoryRenderer.DisplayTrajectory(transform.position, velocity, gravityScale);
    }

    private void OnMouseUp()
    {
        /*rigidBody.AddForce(velocity * 10f);*/
        rigidBody.velocity = velocity;

        trajectoryRenderer.ClearTrajectory();
    }

    /*void Dragging()
    {
        Vector2 dragDelta = (Vector2)Input.mousePosition - dragStartPos;

        // Adjust the trajectory calculation based on your game's physics
        float power = Mathf.Clamp(dragDelta.magnitude * powerMultiplier, minPower, maxPower);
        Vector2 direction = dragDelta.normalized;

        // Calculate trajectory using physics
        Vector2 velocity = direction * power;
        trajectoryRenderer.DisplayTrajectory(transform.position, velocity);
    }*/


    // Update is called once per frame
    void Update()
    {

    }
}
