using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public abstract class Entity : MonoBehaviour, IInteractable, ITriggerable
{
    public List<Entity> triggerTo = new List<Entity>();
    public List<Entity> triggerBy = new List<Entity>();
    public float followSpeed = 10;
    public float throwSpeed = 10;
    public float smoothDist = 0.1f;
    public bool isPicked = false;
    public bool isActivate = false;
    private Transform original;
    private Transform followTarget;
    private Rigidbody rb;
    private Collider coll;

    public abstract void OnEnterActivate();
    public abstract void OnExitActivate();
    public abstract void OnActivate();
    public virtual bool CanThrown() => true;
    public virtual bool CanPick() => true;
    public virtual bool CanPress() => false;
    public virtual void BeTrigger(Entity entity)
    {
        if (!triggerBy.Contains(entity))
            return;
        if (!isActivate)
            OnEnterActivate();
        else
            OnExitActivate();
        isActivate = !isActivate;
    }
    public virtual void Trigger()
    {
        for (int i = 0; i < triggerTo.Count; i++)
        {
            if (!triggerTo[i].isActivate)
                triggerTo[i].OnEnterActivate();
            else
                triggerTo[i].OnExitActivate();
            triggerTo[i].isActivate = !triggerTo[i].isActivate;
        }
    }
    public void BePicked(Transform targetTrans)
    {
        isPicked = true;
        followTarget = targetTrans;
        rb.useGravity = false;
        rb.isKinematic = true;
        this.transform.parent = Camera.main.transform;
    }

    public void BeDropped()
    {
        isPicked = false;
        followTarget = null;
        rb.useGravity = true;
        rb.isKinematic = false;
        this.transform.parent = original;
    }

    public void BeThrown(Vector3 direction)
    {
        BeDropped();
        StartCoroutine(ThrowNextFrame(direction));
    }

    public virtual void BePressed() { }
    private void Start()
    {
        original = this.transform.parent;
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        LevelManager.instance.AddEntity(this);
        OnStart();
    }
    private void Update()
    {
        if (isPicked)
        {
            Vector3 thisPos = this.transform.position;
            Vector3 dir = followTarget.position - transform.position;
            if ((followTarget.position - transform.position).magnitude >= smoothDist)
            {
                transform.Translate(dir.normalized * followSpeed * Time.deltaTime, Space.World);
            }
        }
        OnUpdate();
    }

    protected virtual void OnUpdate()
    {

    }

    protected virtual void OnStart()
    {

    }

    IEnumerator ThrowNextFrame(Vector3 direction)
    {
        yield return null;
        rb.AddForce(direction.normalized * throwSpeed);
    }





}