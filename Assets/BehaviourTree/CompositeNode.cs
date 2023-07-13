using UnityEngine;
using System.Collections.Generic;

public abstract class CompositeNode : Node
{
    private List<Node> _children = new List<Node>();
}