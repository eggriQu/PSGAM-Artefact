using UnityEngine;

[CreateAssetMenu(menuName = "State/Player/Walk")]
public class PlayerWalk : BaseState
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void Entry(BaseController controller)
    {
        controller.SetAnimation("Walking");
    }

    public override void UpdatePhysics(BaseController controller)
    {
        if (controller.actionCoroutine == null)
        {
            controller.rb.linearVelocityX = controller.followDirection.x * controller.moveSpeed;
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
