using UnityEngine;

public abstract class IDecision : ScriptableObject
{
    public abstract int Check(BaseController fsm);
}

[System.Serializable]
public class Transition
{
    public IDecision decision;
    public BaseState[] potentialStates;
}
