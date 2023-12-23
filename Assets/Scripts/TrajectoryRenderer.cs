using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject dotPrefab; // Prefab for the aiming dots
    public int numberOfDots = 10; // Number of dots to display

    private GameObject[] dots;

    void Start()
    {
        dots = new GameObject[numberOfDots];
        for (int i = 0; i < numberOfDots; i++)
        {
            dots[i] = Instantiate(dotPrefab, transform.position, Quaternion.identity);
            dots[i].SetActive(false);
        }
    }

    public void DisplayTrajectory(Vector2 startPosition, Vector2 velocity, float gravityScale)
    {
        float timeStep = 1f / numberOfDots;
        Vector2 currentPosition = startPosition;
        for (int i = 0; i < numberOfDots; i++)
        {
            float t = i * timeStep;
            Vector2 position = CalculateTrajectoryPoint(currentPosition, velocity, gravityScale, t);
            dots[i].transform.position = new Vector3(position.x, position.y, 0f);
            dots[i].SetActive(true);

            // Check for collision and handle ricochet
            if (CheckCollision(position))
            {
                velocity = ReflectVelocity(velocity, GetSurfaceNormal(position));
                currentPosition = position;
            }
        }
    }

    private bool CheckCollision(Vector2 position)
    {
        // Perform collision detection based on your game logic
        // For example, check if the position is inside a collider
        // If collision occurs, return true; otherwise, return false
        return false; // Placeholder, replace with actual collision detection
    }

    private Vector2 ReflectVelocity(Vector2 velocity, Vector2 normal)
    {
        // Reflect the velocity vector based on the surface normal
        return Vector2.Reflect(velocity, normal);
    }

    private Vector2 GetSurfaceNormal(Vector2 position)
    {
        // Determine the surface normal at the collision point
        // You may need to use Raycasting or other methods based on your game
        // Return the surface normal vector
        return Vector2.up; // Placeholder, replace with actual surface normal
    }

    private Vector2 CalculateTrajectoryPoint(Vector2 startPosition, Vector2 velocity, float gravityScale, float time)
    {
        float gravity = -9.8f * gravityScale;

        return startPosition + velocity * time + 0.5f * time * time * new Vector2(0, gravity);
    }

    public void ClearTrajectory()
    {
        // The dots will remain in the same place as we left them, but invisible
        for (int i = 0; i < numberOfDots; i++)
        {
            dots[i].SetActive(false);
        }
    }
}
