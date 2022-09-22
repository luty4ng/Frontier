using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnergyBall : Entity
{
    public List<GameObject> connectedEntity = new List<GameObject>();
    public Material activeMat;
    public Material deactiveMat;
    private MeshRenderer meshRenderer;

    protected override void OnStart()
    {
        base.OnStart();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }
    public override void OnEnterActivate()
    {
        if(connectedEntity.Count==0)
            return;
        for (int i = 0; i < connectedEntity.Count; i++)
        {
            connectedEntity[i].SetActive(false);
        }
        meshRenderer.material = activeMat;
    }
    public override void OnExitActivate()
    {
        if(connectedEntity.Count==0)
            return;
        for (int i = 0; i < connectedEntity.Count; i++)
        {
            connectedEntity[i].SetActive(true);
        }
        meshRenderer.material = deactiveMat;
    }
    public override void OnActivate()
    {
    }
    public override bool CanPick() => false;
    public override bool CanThrown() => false;
}