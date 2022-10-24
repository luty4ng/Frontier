using UnityEngine;
using GameKit;

[System.Serializable]
public class NodeConnectCommand : CommandBase<NodeConnectCommand>
{
    public UI_Line Line;
    public UI_Node StartNode;
    public UI_Node EndNode;
    public override void Excute()
    {
        StartNode.Connect(EndNode, Line);
        EndNode.Connect(StartNode, Line);
        // Line.SetStartNode();
    }

    public override void Revoke()
    {

    }
}