using UnityEngine;
using UnityEngine.Events;

public class GameInputSystem : MonoBehaviour
{
    public static GameInputSystem Instance;

    public UnityEvent mouseDrag;
    public UnityEvent mouseUp;

    public Ball ball;

    private void Awake()
    {
        Instance = this;

        Initialize();
    }

    private void Initialize()
    {
        mouseDrag = new UnityEvent();
        mouseUp = new UnityEvent();
    }

    public void EnableInput()
    {
        mouseDrag.AddListener(ball.InpAimBall);
        mouseUp.AddListener(ball.InpReleaseBall);
    }

    public void DisableInput()
    {
        mouseDrag.RemoveListener(ball.InpAimBall);
        mouseUp.RemoveListener(ball.InpReleaseBall);
    }

    public void BallMouseDrag()
    {
        mouseDrag.Invoke();
    }

    public void BallMouseUp()
    {
        mouseUp.Invoke();
    }

}
