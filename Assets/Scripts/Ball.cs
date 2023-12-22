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
    public bool IsBallInHole()
    {
        return false;
    }

    public void ResetBallPosition()
    {
        BallStopped();
        ballPhysics.ReturnToInitialPosition();
    }

    private void BallStopped()
    {
        ballPhysics.StopBall();

    }

    private void OnMouseDrag()
    {
        Vector2 aimedVelocity = ballPhysics.AimBall(speed);
        trajectoryRenderer.DisplayTrajectory(transform.position, aimedVelocity, gravityScale);
    }

    private void OnMouseUp()
    {
        trajectoryRenderer.ClearTrajectory();
        gameStateContext.HandleHitBall();
        ballPhysics.HitBall();
    }

    private void Update()
    {
        if (gameStateContext.GetCurrentState() is ProcessState)
        {
            gameStateContext.HandleProcessBall();
        }
    }



}
