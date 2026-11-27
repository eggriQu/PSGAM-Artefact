using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Rendering;
using static UnityEngine.Rendering.DebugUI;

public abstract class IAction : ScriptableObject
{
    [SerializeField] protected float startupFrames;
    [SerializeField] protected float activeFrames;
    [SerializeField] protected float recoveryFrames;
    protected float frameMultiplier = 0.01666666667f;
    protected float startup;
    protected float active;
    protected float recovery;

    [SerializeField] protected float hitboxOffsetX;
    [SerializeField] protected float hitboxOffsetY;
    [SerializeField] protected float hitboxSizeX;
    [SerializeField] protected float hitboxSizeY;

    public abstract IEnumerator ActionRoutine(BaseController fsm);
    public abstract void UpdateActionPhysics(BaseController fsm);
    public void SetActionTime()
    {
        startup = startupFrames * frameMultiplier;
        active = activeFrames * frameMultiplier;
        recovery = recoveryFrames * frameMultiplier;
    }
}

public abstract class BaseState : ScriptableObject
{
    public Transition transition;
    public IAction dashAction;
    public IAction currentAction;
    public List<IAction> actionList;

    public virtual void Awake() { currentAction = null; }
    public abstract void Entry(BaseController controller);
    public abstract void UpdateLogic(BaseController controller);
    public abstract void UpdatePhysics(BaseController controller);
    public abstract void Exit(BaseController controller);
}
