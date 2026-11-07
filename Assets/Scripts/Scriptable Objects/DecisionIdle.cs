using System;
using UnityEngine;
using UnityEngine.InputSystem.XR;

[CreateAssetMenu(menuName = "Decision/Player/Idle")]
public class DecisionIdle : IDecision
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

    public override void ActionCheck(BaseController controller, BaseController.AttackType attackType)
    {
        BaseController fsm = controller;

        if (fsm.actionCoroutine == null && fsm.isAttacking)
        {
            if (attackType == BaseController.AttackType.Light)
            {
                fsm.actionCoroutine = fsm.StartCoroutine(fsm.currentState.actionList[0].ActionRoutine(fsm));
            }
            else if (attackType == BaseController.AttackType.Heavy)
            {
                fsm.actionCoroutine = fsm.StartCoroutine(fsm.currentState.actionList[1].ActionRoutine(fsm));
            }
        }
    }
}
