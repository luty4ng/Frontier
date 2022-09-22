using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Laser : Entity
{
    public GameObject line;
    public List<Battery> batteries = new List<Battery>();
    protected override void OnStart()
    {
        base.OnStart();
        line.SetActive(false);
        if(batteries.Count == 0)
            Debug.LogWarning("No Battery for Laser");
    }
    public override void OnEnterActivate()
    {
        line.SetActive(true);
        if(triggerTo.Count==0)
            return;
        for (int i = 0; i < triggerTo.Count; i++)
        {
            triggerTo[i].BeTrigger(this);
        }
    }
    public override void OnExitActivate()
    {
        line.SetActive(false);
        if(triggerTo.Count==0)
            return;
        for (int i = 0; i < triggerTo.Count; i++)
        {
            triggerTo[i].BeTrigger(this);
        }
    }
    public override void OnActivate()
    {

    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        if(!CheckActive() && isActivate)
        {
            OnExitActivate();
            isActivate = false;
        }
        else if(CheckActive() && !isActivate)
        {
            OnEnterActivate();
            isActivate = true;
        }
    }
    public override bool CanPick() => false;
    public override bool CanThrown() => false;

    private bool CheckActive()
    {
        for (int i = 0; i < batteries.Count; i++)
        {
            if(!batteries[i].isActivate)
                return false;
        }
        return true;
    }

}