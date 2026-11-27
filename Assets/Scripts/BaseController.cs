using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class BaseController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 followDirection;
    public Vector2 facingDirection;
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
    public bool isAttacking;
    public bool beenHit;
    public BaseController currentOpponent;
    public AttackType currentAttack;

    public enum AttackType
    {
        Light,
        Heavy
    }

    public BoxCollider2D attackCollider;
    public CapsuleCollider2D hitCollider;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public BaseState currentState;
    public Coroutine actionCoroutine;

    private RaycastHit2D groundCast;
    public LayerMask groundMask;
    [SerializeField] private LayerMask groundLayer;
    public LayerMask ignoreLayer;

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

        if (facingDirection.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (facingDirection.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    //public virtual void LateUpdate()
    //{
    //    currentState.UpdatePhysics(this);
    //}

    public virtual void FixedUpdate()
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
        groundCast = Physics2D.BoxCast(transform.position, Vector2.one * 0.5f, 0, -transform.up, 0.5f, groundLayer);

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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + (-transform.up * 0.5f), Vector2.one * 0.5f);
    }

    public void ChangeUsingTransition()
    {
        if (actionCoroutine == null)
        {
            int stateIndex = (int)(currentState?.transition.decision.Check(this));

            if (currentState != currentState.transition.potentialStates[stateIndex])
            {
                ChangeState(currentState.transition.potentialStates[stateIndex]);
            }
        }
    }

    public Vector2 SetColliderXY(float xValue, float yValue)
    {
        return new Vector2(xValue, yValue);
    }

    public void SetColliderValues(float xOffset, float yOffset, float xSize, float ySize)
    {
        attackCollider.offset = new Vector2(xOffset, yOffset);
        attackCollider.size = new Vector2(xSize, ySize);
    }

    public void SetAnimation(string animationName)
    {
        anim.Play(animationName);
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            currentOpponent = collision.GetComponentInParent<BaseController>();

            if (currentOpponent != this && currentOpponent.isAttacking)
            {
                beenHit = true;
            }
        }
    }
}
