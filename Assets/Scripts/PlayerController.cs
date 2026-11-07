using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PlayerController : BaseController
{
    private InputAction _moveInput;
    private InputAction _dashInput;
    private InputAction _jumpInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Awake()
    {
        base.Awake();
        _moveInput = InputSystem.actions.FindAction("Move");
        _dashInput = InputSystem.actions.FindAction("Sprint");
        _jumpInput = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void LateUpdate()
    {
        base.LateUpdate();
    }

    private void OnEnable()
    {
        _moveInput.Enable();
        _moveInput.performed += Moving;
        _moveInput.canceled += Moving;

        _dashInput.Enable();
        _dashInput.performed += Dashing;
        _dashInput.canceled += DashCancelled;

        _jumpInput.Enable();
        _jumpInput.performed += Jump;
        _jumpInput.canceled -= Jump;
    }

    private void OnDisable()
    {
        _moveInput.Disable();
        _dashInput.Disable();
        _jumpInput.Disable();
    }

    private void Jump(InputAction.CallbackContext context)
    {
        //groundCast.collider.excludeLayers = LayerMask.GetMask("Ground");
        //rb.excludeLayers = LayerMask.GetMask("Ground");
        //GetComponent<Collider2D>().excludeLayers = LayerMask.GetMask("Ground");

        if (isGrounded)
        {
            isAirborne = true;
        }
    }

    private void Moving(InputAction.CallbackContext context)
    {
        followDirection = context.ReadValue<Vector2>();
    }

    private void Dashing(InputAction.CallbackContext context)
    {
        isDashing = true;

        if (currentState.name == "PlayerNeutralAir" && actionCoroutine == null && !usedAirDash)
        {
            actionCoroutine = StartCoroutine(currentState.actionList[0].ActionRoutine(this));
        }
    }

    private void DashCancelled(InputAction.CallbackContext context)
    {
        isDashing = false;
    }
}
