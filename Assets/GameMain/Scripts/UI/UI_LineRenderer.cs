using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRenderer))]
public class UI_LineRenderer : Graphic
{
    public Vector2Int UnitGridSize;
    [Range(5f, 20f)] public float Thickness = 10f;
    [Range(16, 64)] public int CircleDetail = 32;
    public List<Vector2> Points = new List<Vector2>();

    private float width = 1;
    private float height = 1;
    private float unitWidth;
    private float unitHeight;
    private float Radius;
    private int m_VerticeIndexOffset;

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();
        m_VerticeIndexOffset = 0;
        Radius = Thickness / 2;
        // width = rectTransform.rect.width;
        // height = rectTransform.rect.height;
        unitWidth = width / (float)UnitGridSize.x;
        unitHeight = height / (float)UnitGridSize.y;

        if (Points.Count < 2)
            return;

        DrawCircle(0, Points[0], vh);
        for (int i = 0; i < Points.Count - 1; i++)
        {
            DrawVerticesForPoint(Points[i], Points[i + 1], vh);
            DrawTriangleForLine(i * 4 + m_VerticeIndexOffset, vh);
            DrawCircle(i * 4, Points[i + 1], vh);
        }
    }

    private void DrawVerticesForPoint(Vector2 point, Vector2 nextPoint, VertexHelper vh)
    {
        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;
        float angle = Mathf.Atan2(nextPoint.y - point.y, nextPoint.x - point.x);
        float offsetedX = Radius * Mathf.Cos(angle + Mathf.PI / 2);
        float offsetedY = Radius * Mathf.Sin(angle + Mathf.PI / 2);

        vertex.position = new Vector3(point.x * unitWidth + offsetedX, point.y * unitHeight + offsetedY);
        vh.AddVert(vertex);

        vertex.position = new Vector3(point.x * unitWidth - offsetedX, point.y * unitHeight - offsetedY);
        vh.AddVert(vertex);

        vertex.position = new Vector3(nextPoint.x * unitWidth + offsetedX, nextPoint.y * unitHeight + offsetedY);
        vh.AddVert(vertex);

        vertex.position = new Vector3(nextPoint.x * unitWidth - offsetedX, nextPoint.y * unitHeight - offsetedY);
        vh.AddVert(vertex);
    }

    private void DrawCircle(int lineIndex, Vector2 point, VertexHelper vh)
    {
        float unitRadians = 360f / CircleDetail * Mathf.Deg2Rad;
        int centerIndex, lastIndex, startIndex;
        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        vertex.position = new Vector3(point.x * unitWidth, point.y * unitHeight, 0f);
        vh.AddVert(vertex);
        centerIndex = vh.currentVertCount - 1;

        vertex.position = new Vector3(Radius + point.x * unitWidth, point.y * unitHeight, 0f);
        vh.AddVert(vertex);
        lastIndex = startIndex = vh.currentVertCount - 1;

        m_VerticeIndexOffset += 2;

        for (int i = 1; i < CircleDetail; i++)
        {
            float radians = i * unitRadians;

            vertex.position = new Vector3(Mathf.Cos(radians) * Radius + point.x * unitWidth, Mathf.Sin(radians) * Radius + point.y * unitHeight, 0f);
            vh.AddVert(vertex);

            vh.AddTriangle(centerIndex, lastIndex, vh.currentVertCount - 1);
            lastIndex = vh.currentVertCount - 1;
            m_VerticeIndexOffset++;
        }
        vh.AddTriangle(centerIndex, lastIndex, startIndex);
    }

    private void DrawTriangleForLine(int lineIndex, VertexHelper vh)
    {
        vh.AddTriangle(lineIndex + 0, lineIndex + 1, lineIndex + 2);
        vh.AddTriangle(lineIndex + 1, lineIndex + 3, lineIndex + 2);
    }
}
