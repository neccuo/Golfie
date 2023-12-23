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

    void Start()
    {
        speed = 100f;
        gravityScale = 1f;

        ballPhysics = GetComponent<BallPhysics>();
        ballPhysics.SetGravityScale(gravityScale);
        
        gameStateContext = new GameStateContext(this);
        //gameStateContext.Init();
    }

    public bool IsBallMoving()
    {
        return ballPhysics.IsMoving();
    }

    // TODO: IMPLEMENT IT LATER
    public bool IsBallInBounds()
    {
        if (transform.position.y > 3)
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
    }

    public void InpReleaseBall()
    {
        trajectoryRenderer.ClearTrajectory();
        gameStateContext.HandleHitBall();
        ballPhysics.HitBall();
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
