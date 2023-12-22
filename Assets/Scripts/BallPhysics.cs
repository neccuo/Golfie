using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;

    [SerializeField] private Vector2 initialPosition;

    [SerializeField] private Rigidbody2D rigidBody;


    public Vector2 GetVelocity()
    {
        return rigidBody.velocity;
    }

    public bool IsMoving(float toleranceIn=0.1f)
    {
        return rigidBody.velocity.magnitude > toleranceIn;
    }

    public void StopBall()
    {
        rigidBody.velocity = Vector2.zero;
    }

    public void ReturnToInitialPosition()
    {
        transform.position = initialPosition;
    }

    public void SetGravityScale(float gravityScaleIn)
    {
        rigidBody.gravityScale = gravityScaleIn;
    }

    public Vector2 AimBall(float speedIn)
    {
        velocity = GetDirection() * speedIn;
        return velocity;
    }

    public void HitBall()
    {
        initialPosition = transform.position;
        rigidBody.velocity = velocity;
    }

    private Vector3 GetDirection()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z));

        return (transform.position - worldMousePosition).normalized;
    }
}
