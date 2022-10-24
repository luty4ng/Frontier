using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(UI_LineRenderer))]
public class UI_Line : UIBehaviour
{
    public LineMode LineMode;
    public UI_LineRenderer Renderer;
    private UI_Node StartNode;
    private UI_Node EndNode;

    protected override void Start()
    {

    }

    public void SetStartNode(UI_Node node)
    {
        StartNode = node;
        Renderer.Points.Clear();
        Renderer.Points.Add(node.transform.position);
    }

    public void SetEndNode(UI_Node node)
    {
        EndNode = node;
        if (LineMode == LineMode.Direct)
        {
            Renderer.Points.Add(EndNode.transform.position);
        }
        else if (LineMode == LineMode.Deg90)
        {
            float disX = Mathf.Abs(StartNode.transform.position.x - EndNode.transform.position.x);
            float disY = Mathf.Abs(StartNode.transform.position.y - EndNode.transform.position.y);
            Vector3 turningPoint = disX >= disY ? new Vector3(StartNode.transform.position.x, EndNode.transform.position.y) : new Vector3(EndNode.transform.position.x, StartNode.transform.position.y);
            Renderer.Points.Add(turningPoint);
            Renderer.Points.Add(EndNode.transform.position);
        }
    }
}