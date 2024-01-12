using Assets.Scripts.State.Contexts;
using Assets.Scripts.State.States.GameStates;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public float gravityScale;

    // asset, color

    public BallPhysics ballPhysics;

    private GameStateContext gameStateContext;

    [SerializeField] private TrajectoryRenderer trajectoryRenderer;
    //[SerializeField] Ball ballPrefab;


    void Start()
    {
        speed = 100f;
        gravityScale = 1f;

        ballPhysics = GetComponent<BallPhysics>();
        ballPhysics.SetGravityScale(gravityScale);
        
        gameStateContext = new GameStateContext(this);
        //gameStateContext.Init();
    }

    public void InitBall()
    {
        transform.position = new Vector2(-8, 0);
    }

    public bool IsBallMoving()
    {
        return ballPhysics.IsMoving();
    }

    // TODO: IMPLEMENT IT LATER
    public bool IsBallInBounds()
    {
        if (transform.position.y < -20f)
            return false;
        return true;
    }

    // WIN CONDITION
    // TODO: IMPLEMENT IT LATER
    public bool IsBallInGoalArea()
    {
        return ballPhysics.IsBallCollidingWithGoalArea();
    }

    public void ResetBallPosition()
    {
        ballPhysics.StopBall();
        ballPhysics.ReturnToInitialPosition();
    }

    // FUNCTIONS FOR MY CUSTOM INPUT SYSTEM
    public void InpAimBall()
    {
        Vector2 aimedVelocity = ballPhysics.AimBall(speed);
        trajectoryRenderer.DisplayTrajectory(transform.position, aimedVelocity, gravityScale);
        //trajectoryRenderer.SimulateTrajectory(transform.position, aimedVelocity);
    }

    public void InpReleaseBall()
    {
        trajectoryRenderer.ClearTrajectory();
        gameStateContext.HandleHitBall();
        ballPhysics.HitBall();
    }

    // SIMULATION ATTEMPT
    //public void Hit(Vector3 velocityIn)
    //{
    //    ballPhysics.ApplyForce(velocityIn);
    //}

    public void HandleWallHit()
    {
        if(gameStateContext.GetCurrentState() is ProcessState)
        {
            gameStateContext.IncBounceCount();
        }
    }

    private void OnMouseDrag()
    {
        GameInputSystem.Instance.BallMouseDrag();
    }

    private void OnMouseUp()
    {
        GameInputSystem.Instance.BallMouseUp();
    }

    private void Update()
    {
        if (gameStateContext.GetCurrentState() is ProcessState)
        {
            gameStateContext.HandleProcessBall();
        }
    }
}
