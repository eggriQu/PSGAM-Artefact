using System;
using UnityEngine;

public abstract class IDecision : ScriptableObject
{
    public abstract int Check(BaseController fsm);
    public abstract void ActionCheck(BaseController fsm, BaseController.AttackType attackType);
}

[System.Serializable]
public class Transition
{
    public IDecision decision;
    public BaseState[] potentialStates;
}
