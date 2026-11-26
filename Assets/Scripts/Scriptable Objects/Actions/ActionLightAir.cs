using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Player/Light Attacks/Air")]
public class ActionLightAir : IAction
{
    public override IEnumerator ActionRoutine(BaseController controller)
    {
        SetActionTime();
        yield return new WaitForSeconds(startup);
        controller.SetColliderValues(1 * controller.facingDirection.x, 0, 1, 1);
        controller.rb.AddForceX(controller.facingDirection.x * 3.5f, ForceMode2D.Impulse);

        yield return new WaitForSeconds(active);
        controller.SetColliderValues(0, 0, 0.1f, 0.1f);

        yield return new WaitForSeconds(recovery);
        controller.actionCoroutine = null;
        controller.isAttacking = false;
    }

    public override void UpdateActionPhysics(BaseController controller)
    {
        
    }
}
