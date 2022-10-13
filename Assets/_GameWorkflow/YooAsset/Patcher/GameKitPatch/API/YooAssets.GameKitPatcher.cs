using System.ComponentModel;
using System.Diagnostics;
using Cysharp.Threading.Tasks;
using YooAsset;
using System;

namespace YooAsset.GameKitPatcher
{
    public static partial class Entry
    {
        private static async UniTask InternalLoadAsset(string assetName, Type assetType, int priority, LoadAssetCallbacks loadAssetCallbacks, object userData)
        {
            AssetOperationHandle handle = YooAssets.LoadAssetAsync(assetName, assetType);
            UniTask uniTask = handle.ToUniTask();
            await uniTask;
            if (handle.Status == EOperationStatus.Succeed)
            {
                loadAssetCallbacks.LoadAssetSuccessCallback.Invoke(assetName, handle.AssetObject, 0, userData);
            }
            else if (handle.Status == EOperationStatus.Failed)
            {
                loadAssetCallbacks.LoadAssetFailureCallback.Invoke(assetName, LoadResourceStatus.AssetError, "YooAsset Load Asset Fail.", userData);
            }
        }

        public static async void LoadAsset(string assetName, int priority, LoadAssetCallbacks loadAssetCallbacks, object userData)
        {
            await InternalLoadAsset(assetName, typeof(UnityEngine.Object), priority, loadAssetCallbacks, userData);
        }

        public static async void LoadAsset(string assetName, Type assetType, int priority, LoadAssetCallbacks loadAssetCallbacks, object userData)
        {
            await InternalLoadAsset(assetName, assetType, priority, loadAssetCallbacks, userData);
        }

        public static async void LoadScene(string sceneAssetName, int priority, LoadSceneCallbacks loadSceneCallbacks, object userData)
        {
            SceneOperationHandle handle = YooAssets.LoadSceneAsync(sceneAssetName);
            await handle.ToUniTask();
            if (handle.Status == EOperationStatus.Succeed)
            {
                loadSceneCallbacks.LoadSceneSuccessCallback.Invoke(sceneAssetName, 0, userData);
            }
            else if (handle.Status == EOperationStatus.Failed)
            {
                loadSceneCallbacks.LoadSceneFailureCallback.Invoke(sceneAssetName, LoadResourceStatus.AssetError, "YooAsset Load Scene Fail.", userData);
            }
        }

        public static async void UnloadScene(string sceneAssetName, UnloadSceneCallbacks m_UnloadSceneCallbacks, object userData)
        {
            try
            {
                UnityEngine.AsyncOperation handle = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneAssetName);
                await handle.ToUniTask();
                if (handle.isDone)
                {
                    m_UnloadSceneCallbacks.UnloadSceneSuccessCallback.Invoke(sceneAssetName, userData);
                }
            }
            catch (System.Exception)
            {
                m_UnloadSceneCallbacks.UnloadSceneFailureCallback.Invoke(sceneAssetName, userData);
            }
        }

        public static async void LoadBinary(string binaryAssetName, LoadBinaryCallbacks loadBinaryCallbacks, object userData)
        {
            AssetOperationHandle handle = YooAssets.LoadAssetAsync<UnityEngine.TextAsset>(binaryAssetName);
            await handle.ToUniTask();
            if (handle.Status == EOperationStatus.Succeed)
            {
                byte[] rawData = ((UnityEngine.TextAsset)handle.AssetObject).bytes;
                loadBinaryCallbacks.LoadBinarySuccessCallback.Invoke(binaryAssetName, rawData, 0, userData);
            }
            else if (handle.Status == EOperationStatus.Failed)
            {
                loadBinaryCallbacks.LoadBinaryFailureCallback.Invoke(binaryAssetName, LoadResourceStatus.TypeError, "YooAsset Load Binary Fail.", userData);
            }
        }
    }
}





