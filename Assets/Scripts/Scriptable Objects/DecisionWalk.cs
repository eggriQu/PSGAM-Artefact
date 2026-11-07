using UnityEngine;

[CreateAssetMenu(menuName = "Decision/Player/Walk")]
public class DecisionWalk : IDecision
{
    public override int Check(BaseController controller)
    {
        if (controller.followDirection.x == 0)
        {
            return 0;
        }
        else
        {
            if (!controller.isDashing)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}
