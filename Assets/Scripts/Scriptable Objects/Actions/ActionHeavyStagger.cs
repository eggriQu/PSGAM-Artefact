using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Player/Heavy Stagger")]
public class ActionHeavyStagger : IAction
{
    public override IEnumerator ActionRoutine(BaseController controller)
    {
        controller.rb.linearVelocity = Vector2.zero;
        Vector2 hitForce = controller.currentOpponent.facingDirection * 15;
        controller.rb.AddForce(hitForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(recoveryFrames);
        controller.actionCoroutine = null;
        controller.beenHit = false;
    }

    public override void UpdateActionPhysics(BaseController controller)
    {

    }
}
