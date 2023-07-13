using UnityEngine;

public abstract class DecoratorNode : Node
{
    [SerializeField]
    private Node _child;

    public Node Child => _child;
}