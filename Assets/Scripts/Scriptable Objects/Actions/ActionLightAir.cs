using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Player/Light Attacks/Air")]
public class ActionLightAir : IAction
{
    public override IEnumerator ActionRoutine(BaseController controller)
    {
        SetActionTime();
        controller.SetAnimation("Air_Light");
        yield return new WaitForSeconds(startup);
        controller.SetColliderValues(hitboxOffsetX * controller.facingDirection.x, hitboxOffsetY, hitboxSizeX, hitboxSizeY);
        controller.rb.AddForceX(controller.facingDirection.x * 3.5f, ForceMode2D.Impulse);

        yield return new WaitForSeconds(active);
        controller.SetColliderValues(0, 0, 0.1f, 0.1f);

        yield return new WaitForSeconds(recovery);
        controller.actionCoroutine = null;
        controller.isAttacking = false;
        controller.SetAnimation("Jumping");
    }

    public override void UpdateActionPhysics(BaseController controller)
    {
        
    }
}
