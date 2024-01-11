using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;

    [SerializeField] private Vector2 initialPosition;

    // YOU CAN SET THEM IN SCRIPT IF YOU WANT
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Collider2D ballCollider;

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

    // SIMULATION ATTEMPT
    //public void ApplyForce(Vector3 velocity)
    //{
    //    rigidBody.AddForce(velocity, ForceMode2D.Impulse);
    //}

    public void HitBall()
    {
        initialPosition = transform.position;
        rigidBody.velocity = velocity;
    }

    public void HitBall(Vector2 velocityIn)
    {
        initialPosition = transform.position;
        rigidBody.velocity = velocityIn;
    }

    public bool IsBallCollidingWithGoalArea()
    {
        float radius = ((CircleCollider2D)ballCollider).radius;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("GoalArea"))
            {
                Debug.Log("Collision detected with " + collider.gameObject.name);
                return true;
            }
        }
        return false;
    }

    private Vector3 GetDirection()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z));

        return (transform.position - worldMousePosition).normalized;
    }
}
