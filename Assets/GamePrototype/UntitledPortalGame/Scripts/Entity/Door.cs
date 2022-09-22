using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Door : Entity
{
    Coroutine process;
    AudioSource audioSource;
    public Transform pointA;
    public Transform pointB;
    public float doorSpeed = 10f;
    public float doorSmoothDist = 0.1f;
    private void Awake()
    {
        pointA.transform.parent = transform.parent;
        pointB.transform.parent = transform.parent;
        audioSource = GetComponent<AudioSource>();
    }
    public override void OnEnterActivate()
    {
        if (process != null)
            StopCoroutine(process);
        
        process = StartCoroutine(Move(pointB.position));
        audioSource.Play();
    }
    public override void OnExitActivate()
    {
        if (process != null)
            StopCoroutine(process);
        process = StartCoroutine(Move(pointA.position));
        audioSource.Play();
    }
    public override void OnActivate()
    {
        
    }

    IEnumerator Move(Vector3 destination)
    {
        while ((destination - this.transform.position).magnitude > doorSmoothDist)
        {
            
            this.transform.Translate((destination - this.transform.position).normalized * doorSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public override bool CanPick() => false;
    public override bool CanThrown() => false;
}