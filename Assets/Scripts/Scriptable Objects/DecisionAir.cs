using UnityEngine;

[CreateAssetMenu(menuName = "Decision/Player/Neutral Air")]
public class DecisionAir : IDecision
{
    public override int Check(BaseController controller)
    {
        if (!controller.isAirborne)
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
        else
        {
            return 3;
        }
    }
}
