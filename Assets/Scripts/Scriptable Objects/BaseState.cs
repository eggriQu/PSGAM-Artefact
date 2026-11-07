using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public abstract class IAction : ScriptableObject
{
    public abstract IEnumerator ActionRoutine(BaseController fsm);
}

public abstract class BaseState : ScriptableObject
{
    public Transition transition;
    public List<IAction> actionList;

    public abstract void Entry(BaseController controller);
    public abstract void UpdateLogic(BaseController controller);
    public abstract void UpdatePhysics(BaseController controller);
    public abstract void Exit(BaseController controller);
}
