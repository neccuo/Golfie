using Assets.Scripts.State.Contexts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    /*[SerializeField] private Rigidbody2D rigidBody;*/

    [SerializeField] private Vector2 velocity;

    [SerializeField] private float speed;
    [SerializeField] private float gravityScale;

    [SerializeField] private TrajectoryRenderer trajectoryRenderer;
    private Rigidbody2D rigidBody;

    private GameStateContext gameStateContext;

    void Start()
    {
        speed = 100f;
        gravityScale = 1f;

        rigidBody = GetComponent<Rigidbody2D>();
        /*trajectoryRenderer = GetComponent<TrajectoryRenderer>();*/

        if (rigidBody != null)
        {
            // Set gravity scale
            rigidBody.gravityScale = gravityScale;
        }
        gameStateContext = new GameStateContext();
        gameStateContext.Init();
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
        rigidBody.velocity = velocity;

        trajectoryRenderer.ClearTrajectory();

        gameStateContext.HandleHitBall();
    }
}
