using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameKit.Runtime;

public class UIComponentTest : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Log.Info("Open UIFormTest");
            GameKitCenter.UI.OpenUIForm("UIFormTest", "Default");
        }
    }
}
