using UnityEngine;

public class BehaviourTreeController : MonoBehaviour
{
    private BehaviourTree _tree;

    private void Start()
    {
        _tree = ScriptableObject.CreateInstance<BehaviourTree>();
        var debug = ScriptableObject.CreateInstance<DebugLogNode>();
        debug.Message = "Hello";
        _tree.RootNode = debug;

    }

    private void Update()
    {
        _tree.Update();
    }
}