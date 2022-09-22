using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonEntity : Entity
{
    public Animator animator;
    protected override void OnStart()
    {
        animator = GetComponent<Animator>();
    }
    public override void OnEnterActivate()
    {

    }
    public override void OnExitActivate()
    {

    }
    public override void OnActivate()
    {

    }

    public override void BePressed()
    {
        animator.SetTrigger("Pressed");
        Trigger();
    }
    public override bool CanPress() => true;
    public override bool CanPick() => false;
    public override bool CanThrown() => false;
}