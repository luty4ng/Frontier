using UnityEngine;

public class SolarPlane : Entity
{
    public Animator animator;
    AudioSource audioSource;
    protected override void OnStart()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
    }
    public override void OnEnterActivate()
    {
        animator.SetTrigger("Activate");
        audioSource.Play();
        if(triggerTo.Count==0)
            return;
        for (int i = 0; i < triggerTo.Count; i++)
        {
            triggerTo[i].BeTrigger(this);
        }
    }
    public override void OnExitActivate()
    {
        animator.SetTrigger("Deactivate");
        audioSource.Play();
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