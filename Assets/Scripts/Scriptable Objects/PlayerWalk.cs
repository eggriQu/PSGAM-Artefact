using UnityEngine;

[CreateAssetMenu(menuName = "State/Player/Walk")]
public class PlayerWalk : BaseState
{
    public override void Entry(BaseController controller)
    {
        Debug.Log("Player walking");
    }

    public override void UpdatePhysics(BaseController controller)
    {
        controller.rb.linearVelocityX = controller.followDirection.x * controller.moveSpeed;
    }

    public override void UpdateLogic(BaseController controller)
    {
        controller.ChangeUsingTransition();
    }

    public override void Exit(BaseController controller)
    {
        
    }
}
