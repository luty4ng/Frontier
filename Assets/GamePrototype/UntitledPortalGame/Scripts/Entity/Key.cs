using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Key : Entity
{
    public Vector3 size = Vector3.one;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Entity"))
        {
            ITriggerable entityTrigger = other.gameObject.GetComponent<ITriggerable>();
            entityTrigger.BeTrigger(this);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Entity"))
        {
            ITriggerable entityTrigger = other.gameObject.GetComponent<ITriggerable>();
            entityTrigger.BeTrigger(this);
        }
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

}