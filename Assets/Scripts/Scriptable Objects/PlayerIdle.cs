using UnityEngine;

[CreateAssetMenu(menuName = "State/Player/Idle")]
public class PlayerIdle : BaseState
{
    public override void Entry(BaseController controller)
    {
        Debug.Log("Player Idle");
        controller.rb.gravityScale = controller.groundedGravity;
    }

    public override void UpdatePhysics(BaseController controller)
    {
        controller.rb.linearVelocityX = 0;
    }

    public override void UpdateLogic(BaseController controller)
    {
        controller.ChangeUsingTransition();
    }

    public override void Exit(BaseController controller)
    {

    }
}
