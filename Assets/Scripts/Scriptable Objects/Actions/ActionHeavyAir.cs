using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Player/Heavy Attacks/Air")]
public class ActionHeavyAir : IAction
{
    public override IEnumerator ActionRoutine(BaseController controller)
    {
        SetActionTime();
        controller.SetAnimation("Air_Heavy");
        yield return new WaitForSeconds(startup);
        controller.SetColliderValues(hitboxOffsetX * controller.facingDirection.x, hitboxOffsetY, hitboxSizeX, hitboxSizeY);
        controller.rb.linearVelocity = Vector2.zero;
        controller.rb.gravityScale = 0;
        controller.rb.AddForce(controller.facingDirection * 15f, ForceMode2D.Impulse);

        yield return new WaitForSeconds(active);
        controller.rb.gravityScale = controller.fallingGravity;
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
