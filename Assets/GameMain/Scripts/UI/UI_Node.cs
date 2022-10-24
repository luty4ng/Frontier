using System.Collections;
using System.Collections.Generic;
using GameKit;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;

public class UI_Node : UIBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerDownHandler
{
    public Image NodeImage;
    [SerializeField] private float m_ScaleMultipier = 1.5f;
    [SerializeField] private float m_ScacleTime = 0.2f;
    private List<UI_Node> m_ConnectNodes;
    private List<UI_Line> m_ConnectLines;
    private UI_Graph m_Graph;

    private Vector3 m_DefaultScale = Vector3.one;
    private Sequence m_TweenSeq;

    protected override void Start()
    {
        Debug.Log("UI Node Init.");
        m_TweenSeq = DOTween.Sequence();
        m_ConnectNodes = new List<UI_Node>();
        m_ConnectLines = new List<UI_Line>();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_TweenSeq.Complete();
        m_TweenSeq.OnStart(() => { this.transform.localScale = m_DefaultScale / m_ScaleMultipier; }).Append(this.transform.DOScale(m_DefaultScale, m_ScacleTime));
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_TweenSeq.Complete();
        m_TweenSeq.OnStart(() => { this.transform.localScale = m_DefaultScale; }).Append(this.transform.DOScale(m_DefaultScale * m_ScaleMultipier, m_ScacleTime));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerId == -1)
        {

        }
        else if (eventData.pointerId == -2)
        {

        }
    }

    public void Connect(UI_Node node, UI_Line line)
    {
        if(!m_ConnectNodes.Contains(node))
            m_ConnectNodes.Add(node);
        if(!m_ConnectLines.Contains(line))
            m_ConnectLines.Add(line);
    }

    public void Disconnect(UI_Node node, UI_Line line)
    {
        if(m_ConnectNodes.Contains(node))
            m_ConnectNodes.Remove(node);
        if(m_ConnectLines.Contains(line))
            m_ConnectLines.Remove(line);
    }
}
