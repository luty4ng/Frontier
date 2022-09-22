using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lock : Entity
{
    public override void OnEnterActivate()
    {
        if(triggerTo.Count==0)
            return;
        for (int i = 0; i < triggerTo.Count; i++)
        {
            triggerTo[i].BeTrigger(this);
        }
    }
    public override void OnExitActivate()
    {
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
    public override bool CanPick() => false;
    public override bool CanThrown() => false;
}