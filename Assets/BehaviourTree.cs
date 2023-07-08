using UnityEngine;

[CreateAssetMenu]
public class BehaviourTree : ScriptableObject
{
    private Node _rootNode;

    public Node RootNode => _rootNode;

    private Node.NodeState _treeNode = Node.NodeState.Running;

    public Node.NodeState TreeNode => _treeNode;

    public Node.NodeState Update()
    {
        return _rootNode.Update();
    }

}