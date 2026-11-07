using UnityEngine;

[CreateAssetMenu(menuName = "State/Player/Dash")]
public class PlayerDash : BaseState
{
    public override void Entry(BaseController controller)
    {
        Debug.Log("Player dashing");
    }

    public override void UpdatePhysics(BaseController controller)
    {
        controller.rb.linearVelocityX = controller.followDirection.x * controller.moveSpeed * 1.5f;
    }

    public override void UpdateLogic(BaseController controller)
    {
        controller.ChangeUsingTransition();
    }

    public override void Exit(BaseController controller)
    {

    }
}