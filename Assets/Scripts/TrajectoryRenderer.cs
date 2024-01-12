using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrajectoryRenderer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject dotPrefab; // Prefab for the aiming dots
    public int numberOfDots = 10; // Number of dots to display

    private GameObject[] dots;

    // SIMULATION ATTEMPT
    //[SerializeField] private Transform _obstaclesParent; // map1
    //private Scene _simulationScene;
    //private PhysicsScene _physicsScene;
    //private readonly Dictionary<Transform, Transform> _spawnedObjects = new Dictionary<Transform, Transform>();
    //[SerializeField] private BallPhysics ballPhysics;
    //[SerializeField] private Ball ball;
    //[SerializeField] private Ball ghostBall;
        
    void Start()
    {
        dots = new GameObject[numberOfDots];
        for (int i = 0; i < numberOfDots; i++)
        {
            GameObject dot = Instantiate(dotPrefab, transform.position, Quaternion.identity);
            dot.transform.SetParent(transform);
            dot.SetActive(false);
            dots[i] = dot;
        }
        // SIMULATION ATTEMPT
        //CreatePhysicsScene();
    }

    //private void Update()
    //{
    //    // SIMULATION ATTEMPT
    //    foreach (var item in _spawnedObjects)
    //    {
    //        item.Value.position = item.Key.position;
    //        item.Value.rotation = item.Key.rotation;
    //    }
    //}

    // WORRY ABOUT IT LATER
    // SIMULATION ATTEMPT
    //private void CreatePhysicsScene()
    //{
    //    _simulationScene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
    //    _physicsScene = _simulationScene.GetPhysicsScene();

    //    foreach (Transform obj in _obstaclesParent)
    //    {
    //        var ghostObj = Instantiate(obj.gameObject, obj.position, obj.rotation);
    //        if(ghostObj.GetComponent<Renderer>())
    //            ghostObj.GetComponent<Renderer>().enabled = false;
    //        SceneManager.MoveGameObjectToScene(ghostObj, _simulationScene);
    //        if (!ghostObj.isStatic) _spawnedObjects.Add(obj, ghostObj.transform);
    //    }
    //}

    // WORRY ABOUT IT LATER
    // SIMULATION ATTEMPT
    //public void SimulateTrajectory(Vector3 posIn, Vector3 velocityIn)
    //{
    //    Ball tempBall = Instantiate(ghostBall, posIn, Quaternion.identity);
    //    SceneManager.MoveGameObjectToScene(tempBall.gameObject, _simulationScene);

    //    Debug.Log(velocityIn);

    //    //ghostBall.Hit(velocityIn);
    //    tempBall.gameObject.GetComponent<Rigidbody2D>().velocity = velocityIn;

    //    for (var i = 0; i < numberOfDots; i++)
    //    {
    //        _physicsScene.Simulate(Time.fixedDeltaTime);
    //        Vector3 ghostPos = tempBall.transform.position;
    //        //Debug.Log(ghostPos);
    //        dots[i].transform.position = new Vector3(ghostPos.x, ghostPos.y, 0f);
    //        dots[i].SetActive(true);
    //    }

    //    Destroy(tempBall.gameObject);
    //}

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

        }
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
