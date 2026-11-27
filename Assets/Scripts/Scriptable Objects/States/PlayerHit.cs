using UnityEngine;
using static BaseController;

[CreateAssetMenu(menuName = "State/Player/Hit")]
public class PlayerHit : BaseState
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void Entry(BaseController controller)
    {
        controller.SetAnimation("Jumping");
        transition.decision.ActionCheck(controller, controller.currentOpponent.currentAttack);
    }

    public override void UpdatePhysics(BaseController controller)
    {
        
    }

    public override void UpdateLogic(BaseController controller)
    {
        if (!controller.beenHit)
        {
            controller.ChangeUsingTransition();
        }
    }

    public override void Exit(BaseController controller)
    {

    }
}
