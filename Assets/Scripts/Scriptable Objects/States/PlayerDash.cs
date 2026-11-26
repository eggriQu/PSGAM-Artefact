using UnityEngine;

[CreateAssetMenu(menuName = "State/Player/Dash")]
public class PlayerDash : BaseState
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void Entry(BaseController controller)
    {
        controller.SetAnimation("Dashing");
    }

    public override void UpdatePhysics(BaseController controller)
    {
        if (controller.actionCoroutine == null)
        {
            controller.rb.linearVelocityX = controller.followDirection.x * controller.moveSpeed * 1.5f;
        }
        else
        {
            currentAction.UpdateActionPhysics(controller);
        }
    }

    public override void UpdateLogic(BaseController controller)
    {
        controller.ChangeUsingTransition();
    }

    public override void Exit(BaseController controller)
    {

    }
}