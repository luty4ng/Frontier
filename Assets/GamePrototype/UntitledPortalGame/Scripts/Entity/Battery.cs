using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Battery : Entity
{
    public GameObject indicator;
    protected override void OnStart()
    {
        base.OnStart();
        indicator.SetActive(false);
        if(isActivate)
            OnEnterActivate();
    }
    public override void OnEnterActivate()
    {
        indicator.SetActive(true);
        // isActivate = true;
        // if(triggerTo.Count==0)
        //     return;
        // for (int i = 0; i < triggerTo.Count; i++)
        // {
        //     triggerTo[i].BeTrigger(this);
        // }
    }
    public override void OnExitActivate()
    {
        indicator.SetActive(false);
        // isActivate = false;
        // if(triggerTo.Count==0)
        //     return;
        // for (int i = 0; i < triggerTo.Count; i++)
        // {
        //     triggerTo[i].BeTrigger(this);
        // }
    }
    public override void OnActivate()
    {

    }
    public override bool CanPick() => false;
    public override bool CanThrown() => false;
}