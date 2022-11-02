using UnityEngine;
using UnityEngine.SceneManagement;
using UnityGameKit.Runtime;
using System.Collections;

public static class SceneExtension
{
    // public static void UnloadAllScenes(this SceneComponent sceneComponent)
    // {
    //     string[] loadedSceneAssetNames = sceneComponent.GetLoadedSceneAssetNames();
    //     for (int i = 0; i < loadedSceneAssetNames.Length; i++)
    //     {
    //         sceneComponent.UnloadScene(loadedSceneAssetNames[i]);
    //     }
    // }

    // public static void ChangeScene(this SceneComponent sceneComponent, string name, int priority, object userData)
    // {
    //     sceneComponent.UnloadAllScenes();
    //     StartCoroutine(LoadSceneProcess(name, priority, userData));
    // }

    // private static IEnumerator LoadSceneProcess(string name, int priority, object userData)
    // {
    //     while (m_SceneManager.LoadedScenesCount > 1)
    //     {
    //         yield return null;
    //     }
    //     LoadScene(name, priority, userData);
    // }
}