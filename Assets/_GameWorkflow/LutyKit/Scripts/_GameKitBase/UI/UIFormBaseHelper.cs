using GameKit.UI;
using GameKit;
using UnityEngine;
using UnityGameKit.Runtime;

public class UIFormBaseHelper : UIFormHelperBase
{
    public override object InstantiateUIForm(object uiFormAsset)
    {
        GameObject uIInstance = Instantiate((GameObject)uiFormAsset); 
        UIFormBase uiForm = uIInstance.GetComponent<UIFormBase>();
        uiForm.OnInstantiate();       
        return uIInstance;
    }

    public override IUIForm CreateUIForm(object uiFormInstance, IUIGroup uiGroup, object userData)
    {
        GameObject gameObject = uiFormInstance as GameObject;
        
        if (gameObject == null)
        {
            Log.Error("UI form instance is invalid.");
            return null;
        }

        // RectTransform transform = gameObject.GetOrAddComponent<RectTransform>();
        Transform transform = gameObject.transform;
        transform.SetParent(((MonoBehaviour)uiGroup.Helper).transform);
        transform.localScale = Vector3.one;


        return gameObject.GetOrAddComponent<UIForm>();
    }

    public override void ReleaseUIForm(object uiFormAsset, object uiFormInstance)
    {
        // YooAsset UnloadAsset
        Destroy((Object)uiFormInstance);
    }

    private void Start()
    {

    }
}

