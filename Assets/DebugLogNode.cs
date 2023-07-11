using UnityEngine;

public class DebugLogNode : ActionNode
{

    private string _message;

    public string Message { get => _message; set => _message = value; }

    protected override void OnStart()
    {
        Debug.Log($"Start{_message}");
    }

    protected override void OnStop()
    {
        Debug.Log($"Stop{_message}");
    }

    protected override NodeState OnUpdate()
    {
        Debug.Log($"update{_message}");
        return NodeState.Success;
    }
}