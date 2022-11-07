using UnityEngine;
using UnityGameKit.Runtime;

public class UIFormTest : UIFormBase {
    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        Log.Info("Open Forms");
    }
}