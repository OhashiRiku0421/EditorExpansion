using UnityEngine;

[CreateAssetMenu()]
public class BehaviourTree : ScriptableObject
{
    private Node _rootNode;

    public Node RootNode { get => _rootNode; set => _rootNode = value; }

    private Node.NodeState _treeNode = Node.NodeState.Running;

    public Node.NodeState TreeNode => _treeNode;

    public Node.NodeState Update()
    {
        if(_rootNode.State == Node.NodeState.Running)
        {
            _treeNode = _rootNode.Update();
        }

        return _treeNode;
    }

}