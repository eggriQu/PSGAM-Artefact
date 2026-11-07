using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class BaseController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 followDirection;
    public float moveSpeed;
    public float jumpForce;
    public float dashForce;
    public float fallingGravity;
    public float groundedGravity;

    public bool isDashing;
    public bool usedAirDash;
    public bool isAirborne;
    public bool isFalling;
    public bool isGrounded;

    public BaseState currentState;
    public Coroutine actionCoroutine;

    private RaycastHit2D groundCast;
    [SerializeField] public LayerMask groundMask;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] public LayerMask ignoreLayer;

    public virtual void Awake()
    {
        
    }

    public virtual void Update()
    {
        currentState.UpdateLogic(this);

        if (rb.linearVelocityY <= 0f && isAirborne && isFalling)
        {
            groundMask.value = groundLayer;
        }
        else if (rb.linearVelocityY > 0f && isAirborne && !isFalling)
        {
            groundMask.value = ignoreLayer;
        }

        isGrounded = GroundCheck();
    }

    public virtual void LateUpdate()
    {
        currentState.UpdatePhysics(this);
    }

    public void ChangeState(BaseState newState)
    {
        currentState?.Exit(this);
        currentState = newState;
        currentState.Entry(this);
    }

    public bool GroundCheck()
    {
        groundCast = Physics2D.BoxCast(transform.position, Vector2.one, 0, -transform.up, 1, groundLayer);

        if (groundCast)
        {
            isAirborne = false;
            usedAirDash = false;
            return true;
        }
        else
        {
            isAirborne = true;
            return false;
        }
    }

    public void ChangeUsingTransition()
    {
        int stateIndex = (int)(currentState?.transition.decision.Check(this));

        if (currentState != currentState.transition.potentialStates[stateIndex])
        {
            ChangeState(currentState.transition.potentialStates[stateIndex]);
        }
    }
}
