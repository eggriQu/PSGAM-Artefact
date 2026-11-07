using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Player/Dash")]
public class ActionDash : IAction
{
    public override IEnumerator ActionRoutine(BaseController controller)
    {
        controller.rb.gravityScale = 0;
        controller.rb.linearVelocityY = 0;
        controller.usedAirDash = true;
        
        controller.rb.AddForce(controller.followDirection * controller.dashForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.3f);

        controller.actionCoroutine = null;
    }
}
