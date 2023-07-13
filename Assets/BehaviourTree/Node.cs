using UnityEngine;

public abstract class Node : ScriptableObject
{

    public enum NodeState
    { 
        Running,
        Failure,
        Success,
    }

    private NodeState _state = NodeState.Running;

    public NodeState State => _state;

    private bool _isStart = false;

    public NodeState Update()
    {
        if(!_isStart)
        {
            OnStart();
            _isStart = true;
        }

        _state = OnUpdate();

        if(_state == NodeState.Failure || _state == NodeState.Success)
        {
            OnStop();
            _isStart = false;
        }

        return _state;
    }

    protected abstract void OnStart();
    protected abstract void OnStop();
    protected abstract NodeState OnUpdate();

}