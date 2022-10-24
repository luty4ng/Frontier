using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class UI_Graph : UIBehaviour
{
    public GraphState Status;
    public LineMode DefaultLineMode;
    public List<UI_Line> ui_lines;
    public List<UI_Node> ui_nodes;
    public Transform UILineInstances;
    public Transform UINodeInstances;
    private List<NodeConnectCommand> m_HistoricalCommand;
    protected override void Awake()
    {
        base.Awake();
        m_HistoricalCommand = new List<NodeConnectCommand>();
        UI_Node[] nodeComps = UINodeInstances.GetComponentsInChildren<UI_Node>();
        ui_nodes = new List<UI_Node>(nodeComps);
        ui_lines = new List<UI_Line>();
        Status = GraphState.Idle;
    }

    private void Update()
    {
        // if (Input.GetMouseButtonDown(1) && tmpUI_Line != null)
        // {
        //     tmpUI_Line.SelfDestroy();
        //     tmpUI_Line = null;
        //     Status = NodeState.Idle;
        // }


        if (Input.GetKeyDown(KeyCode.Z))
        {
            RemoveLastUI_Line();
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            RemoveAllLine();
            ResetAllNode();
        }
    }

    public void AddLine(UI_Line line)
    {
        if (!ui_lines.Contains(line))
            ui_lines.Add(line);
    }

    public void RemoveLastUI_Line()
    {
        if (ui_lines.Count == 0)
            return;
        UI_Line removeUI_Line = ui_lines[ui_lines.Count - 1];
        ui_lines.Remove(removeUI_Line);
    }
    public void RemoveAllLine()
    {
        while (ui_lines.Count != 0)
            RemoveLastUI_Line();
    }

    public void ResetAllNode()
    {
        // for (int i = 0; i < ui_nodes.Count; i++)
        // {
        //     ui_nodes[i].nodeImg.color = Color.white;
        // }
    }

    public bool CheckAvailableUI_Node(UI_Node node)
    {
        // if (tmpUI_Line != null)
        // {
        //     if (tmpUI_Line.CheckUI_Node(node))
        //         return false;
        // }
        // for (int i = 0; i < ui_lines.Count; i++)
        // {
        //     if (ui_lines[i].CheckUI_Node(node))
        //         return false;
        // }
        return true;
    }

    public List<UI_Line> GetSortedUI_Lines(UI_Node node)
    {
        // List<UI_Line> sortedUI_Lines = new List<UI_Line>();
        // List<UI_Line> tmpLines = new List<UI_Line>(ui_lines);
        // while (tmpLines.Count != 0)
        // {
        //     float minDis = 999;
        //     UI_Line tmpUI_Line = tmpLines.FirstOrDefault();
        //     foreach (var line in tmpLines)
        //     {
        //         float distance = CoordUtillity.GetDistanceFromUI_Line((Vector2)node.transform.position, line.lineDef);

        //         if (distance < minDis)
        //         {
        //             minDis = distance;
        //             tmpUI_Line = line;
        //         }
        //     }
        //     tmpLines.Remove(tmpUI_Line);
        //     sortedUI_Lines.Add(tmpUI_Line);
        // }
        // return sortedUI_Lines;
        return null;
    }
}