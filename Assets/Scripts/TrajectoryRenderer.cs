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
        // Implement logic to display the trajectory using LineRenderer
        // Set the positions of the LineRenderer based on the calculated trajectory

        // Calculate and display dots along the trajectory
        float timeStep = 1f / numberOfDots;
        for (int i = 0; i < numberOfDots; i++)
        {
            float t = i * timeStep;
            Vector2 position = CalculateTrajectoryPoint(startPosition, velocity, gravityScale, t);
            dots[i].transform.position = new Vector3(position.x, position.y, 0f);
            dots[i].SetActive(true);
        }
    }

    public void ClearTrajectory()
    {
        // The dots will remain in the same place as we left them, but invisible
        for (int i = 0; i < numberOfDots; i++)
        {
            dots[i].SetActive(false);
        }
    }

    // Helper method to calculate a point along the trajectory using physics
    private Vector2 CalculateTrajectoryPoint(Vector2 startPosition, Vector2 velocity, float gravityScale, float time)
    {
        // Implement your trajectory calculation based on physics
        // This could involve using the kinematic equations of motion
        // For a simple example, you might use something like startPosition + velocity * time
        // Adjust this based on your game's physics

        float gravity = -9.8f * gravityScale;

        return startPosition + velocity * time + 0.5f * time * time * new Vector2(0, gravity);
    }
}
