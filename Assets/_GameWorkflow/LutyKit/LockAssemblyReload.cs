using UnityEditor;
using UnityEngine;
using System;

[InitializeOnLoad]
internal class SetReloadAssemblies
{
    static SetReloadAssemblies()
    {
        EditorApplication.playModeStateChanged += LogPlayModeState;
    }

    private static void LogPlayModeState(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredPlayMode && EditorPrefs.GetBool(KEY, false))
        {
            EditorApplication.isPlaying = false;
            Debug.LogWarning("重新加载程序集已被锁定。");
            EditorUtility.DisplayDialog("注意", "已锁定重新加载程序集，可按F1进行解锁", "知道后果");
        }
    }

    private const string MENUKEY = "Tools/Lock Reload Assemblies _F1";
    private const string KEY = "LockReloadAssemblies";

    [MenuItem(MENUKEY, priority = int.MaxValue)]
    private static void SetLockReloadAssemblies()
    {

        if (EditorPrefs.GetBool(KEY, false))
        {
            Debug.Log("重新加载程序集已解锁。");
            EditorApplication.UnlockReloadAssemblies();
            EditorPrefs.SetBool(KEY, false);
            Menu.SetChecked(MENUKEY, false);
        }
        else
        {
            Debug.Log("重新加载程序集已锁定。");
            EditorApplication.LockReloadAssemblies();
            EditorPrefs.SetBool(KEY, true);
            Menu.SetChecked(MENUKEY, true);
        }
    }
}