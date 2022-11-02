
using System.Transactions;
using UnityEngine;
using System.Collections.Generic;
using GameKit.Event;
using GameKit;
using GameKit.Element;
using UnityGameKit.Runtime;
using ProcedureOwner = GameKit.Fsm.IFsm<GameKit.Procedure.IProcedureManager>;


public class ProcedureChangeScene : ProcedureBase
{
    private Dictionary<string, bool> m_Flags = new Dictionary<string, bool>();
    private bool m_IsChangeSceneComplete = false;
    private ProcedureOwner m_CachedOwner;
    protected override void OnInit(ProcedureOwner procedureOwner)
    {
        base.OnInit(procedureOwner);
        m_CachedOwner = procedureOwner;
    }

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);
        m_IsChangeSceneComplete = false;
        GameKitCenter.Event.Subscribe(LoadSceneSuccessEventArgs.EventId, OnLoadSceneSuccess);
        GameKitCenter.Event.Subscribe(LoadSceneFailureEventArgs.EventId, OnLoadSceneFailure);

        // 停止所有声音
        GameKitCenter.Sound.StopAllLoadingSounds();
        GameKitCenter.Sound.StopAllLoadedSounds();

        // 隐藏所有实体
        GameKitCenter.Entity.HideAllLoadingEntities();
        GameKitCenter.Entity.HideAllLoadedEntities();

        // 还原游戏速度
        GameKitCenter.Core.ResetNormalGameSpeed();

        string sceneName = procedureOwner.GetData<VarString>(ProcedureStateUtility.NEXT_SCENE_NAME);
        int changeMode = procedureOwner.GetData<VarInt16>(ProcedureStateUtility.CHANGE_SCENE_MODE);

        switch (changeMode)
        {
            case 0:
                GameKitCenter.Scene.ChangeScene(sceneName);
                break;
            case 1:
                GameKitCenter.Scene.ChangeScene(sceneName);
                break;
            case 2:
                GameKitCenter.Scene.ChangeScene(sceneName);
                break;
            case 3:
                GameKitCenter.Scene.ChangeScene(sceneName);
                break;
            default:
                GameKitCenter.Scene.ChangeScene(sceneName);
                break;
        }

        string[] loadedSceneAssetNames = GameKitCenter.Scene.GetLoadedSceneAssetNames();
        for (int i = 0; i < loadedSceneAssetNames.Length; i++)
        {
            GameKitCenter.Scene.UnloadScene(loadedSceneAssetNames[i]);
        }

        // if (!m_IsScenePreloaded)
        // {
        //     GameKitCenter.Event.Fire(this, SaveSettingsEventArgs.Create(null));
        //     GameKitCenter.Setting.Save();
        //     if (GameKitCenter.Scheduler.MultiScene)
        //         GameKitCenter.Scheduler.DoTransition(AssetUtility.GetSceneAsset(sceneName));
        //     else
        //         GameKitCenter.Scheduler.LoadSceneAsyn(AssetUtility.GetSceneAsset(sceneName), onSuccess: OnSceneLoad);
        // }
        // else
        // {
        //     GameKitCenter.Scheduler.AddPreloadedScene(AssetUtility.GetSceneAsset(sceneName));
        //     procedureOwner.SetData<VarBoolean>(ProcedureStateUtility.IS_SCENE_PRELOADED, false);
        //     OnSceneLoad();
        // }
    }

    protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        GameKitCenter.Event.Unsubscribe(LoadSceneSuccessEventArgs.EventId, OnLoadSceneSuccess);
        GameKitCenter.Event.Unsubscribe(LoadSceneFailureEventArgs.EventId, OnLoadSceneFailure);
        m_Flags.Clear();
        base.OnLeave(procedureOwner, isShutdown);
    }

    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        if (!m_IsChangeSceneComplete)
        {
            return;
        }
        ChangeState<ProcedureMain>(procedureOwner);
    }

    public Transform GetEnterTransform()
    {
        // DoorElement element = (DoorElement)GameKitCenter.Element.GetElement(GameKitCenter.Procedure.CachedDoorName);
        // if (element == null)
        //     return null;
        // return element.EnterTranform;
        return null;
    }

    public Transform GetDefaultTransform()
    {
        return GameObject.Find("DefaultSpawnPoint").transform;
    }

    private void OnSceneLoad()
    {
        // GameKitCenter.Element.Clear();
        // GameKitCenter.Setting.Load();
        // GameKitCenter.Event.Fire(this, LoadSettingsEventArgs.Create(null));
        // Transform targetTrans = GetEnterTransform();
        // if (targetTrans == null)
        //     targetTrans = GetDefaultTransform();
        // AddressableManager.instance.GetAssetAsyn(AssetUtility.GetElementAsset("Player_Ethan"), (GameObject obj) =>
        // {
        //     GameObject realObj = GameObject.Instantiate(obj);
        //     m_Prototyper = realObj.GetComponent<Player>();
        //     m_Prototyper.transform.SetParent(GameKitCenter.Procedure.DynamicParent);
        //     m_Prototyper.SetTransform(targetTrans);
        //     QuickCinemachineCamera.current.SetFollowPlayer(m_Prototyper.transform);
        //     OnSceneLoadEnd();
        // });
    }

    private void OnSceneLoadEnd()
    {
        m_IsChangeSceneComplete = true;
    }

    private void OnLoadSceneSuccess(object sender, BaseEventArgs e)
    {
        LoadSceneSuccessEventArgs args = (LoadSceneSuccessEventArgs)e;
        if (args.UserData == null)
        {
            Log.Warning("DoTransitionCompleteEventArgs is null, procedure phase the load without transition.");
            OnSceneLoad();
            return;
        }

        // DoTransitionCompleteEventArgs transitionArgs = (DoTransitionCompleteEventArgs)args.UserData;
        // if (transitionArgs.UserData == null)
        // {
        //     Log.Warning("The transition is not fired by {0} when loading {1}", typeof(SchedulerComponent).Name, args.SceneAssetName);
        //     return;
        // }

        // if (transitionArgs.UserData.GetType() == typeof(SchedulerComponent))
        // {
        //     if (transitionArgs.TargetCount == 0)
        //     {
        //         OnSceneLoad();
        //     }
        // }
    }

    private void OnLoadSceneFailure(object sender, BaseEventArgs e)
    {
        LoadSceneFailureEventArgs ne = (LoadSceneFailureEventArgs)e;
        if (ne.UserData != this)
        {
            return;
        }

        Log.Error("Load scene '{0}' failure, error message '{1}'.", ne.SceneAssetName, ne.ErrorMessage);
    }


    private void OnUnloadSceneSuccess(object sender, BaseEventArgs e)
    {
        UnloadSceneSuccessEventArgs ne = (UnloadSceneSuccessEventArgs)e;
        // if (ne.UserData != this)
        // {
        //     return;
        // }

        // if (m_BackgroundMusicId > 0)
        // {
        //     GameKitCenter.Sound.PlayMusic(m_BackgroundMusicId);
        // }
        // m_IsChangeSceneComplete = true;
    }

    private void OnUnloadSceneFailure(object sender, BaseEventArgs e)
    {
        UnloadSceneFailureEventArgs ne = (UnloadSceneFailureEventArgs)e;
        if (ne.UserData != this)
        {
            return;
        }

        Log.Error("Load scene '{0}' failure, error message '{1}'.", ne.SceneAssetName, ne.SceneAssetName);
    }
}

