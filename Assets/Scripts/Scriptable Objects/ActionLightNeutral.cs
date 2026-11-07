using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Player/Light Attacks/Neutral")]
public class ActionLightNeutral : IAction
{
    public override IEnumerator ActionRoutine(BaseController controller)
    {
        Debug.Log("Neutral light Attack started");
        yield return new WaitForSeconds(1f);
        Debug.Log("Neutral light Attack ended");
        controller.actionCoroutine = null;
        controller.isAttacking = false;
    }
}