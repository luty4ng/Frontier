using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EndingButton : Entity
{
    public Animator animator;
    public GameObject video;
    public GameObject hintPanel;
    public GameObject enddingDoor;
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
        video.SetActive(true);
        enddingDoor.SetActive(true);
        hintPanel.SetActive(false);
    }
    public override bool CanPress() => true;
    public override bool CanPick() => false;
    public override bool CanThrown() => false;
}