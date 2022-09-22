using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class InteractControl : MonoBehaviour
{
    public float rayLength = 4;
    public bool isHolding = false;
    public IInteractable handObj;
    public Transform pickUpPoint;
    private Ray hitRay;
    private void Update()
    {
        hitRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        bool isDetect = Physics.Raycast(hitRay, out RaycastHit rayInfo, rayLength);
        Debug.DrawRay(this.transform.position, Camera.main.transform.forward, Color.red);
        // if (isDetect)
        //     Debug.Log(rayInfo.transform.gameObject.name);

        if (isHolding && handObj != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isHolding = false;
                if (handObj != null)
                {
                    handObj.BeDropped();
                    handObj = null;
                }
            }
            else if (Input.GetMouseButton(0))
            {
                if (!handObj.CanThrown())
                    return;
                handObj.BeThrown(Camera.main.transform.forward);
                handObj = null;
                isHolding = false;
            }
        }
        else if (!isHolding && isDetect)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                IInteractable hitObj = rayInfo.transform.gameObject.GetComponent<IInteractable>();
                if (hitObj == null)
                    return;

                if(hitObj.CanPress())
                {
                    hitObj.BePressed();
                    return;
                }

                if (!hitObj.CanPick())
                    return;
                isHolding = true;
                hitObj.BePicked(pickUpPoint);
                handObj = hitObj;
            }
        }
    }

}
