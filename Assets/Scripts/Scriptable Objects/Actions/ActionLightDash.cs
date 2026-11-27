using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Player/Light Attacks/Dash")]
public class ActionLightDash : IAction
{
    public override IEnumerator ActionRoutine(BaseController controller)
    {
        SetActionTime();
        controller.SetAnimation("Dash_Light");
        yield return new WaitForSeconds(startup);
        controller.SetColliderValues(hitboxOffsetX * controller.facingDirection.x, hitboxOffsetY, hitboxSizeX, hitboxSizeY);

        yield return new WaitForSeconds(active);
        controller.SetColliderValues(0, 0, 0.1f, 0.1f);

        yield return new WaitForSeconds(recovery);
        controller.actionCoroutine = null;
        controller.isAttacking = false;
        controller.currentState.Entry(controller);
    }

    public override void UpdateActionPhysics(BaseController controller)
    {
        
    }
}
