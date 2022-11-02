using GameKit;
using GameKit.Event;
using System.Collections.Generic;
using UnityEngine;
using UnityGameKit.Runtime;
using SceneManager = UnityEngine.SceneManagement.SceneManager;
using ProcedureOwner = GameKit.Fsm.IFsm<GameKit.Procedure.IProcedureManager>;

// 加载预制资源
public class ProcedurePreload : ProcedureBase
{
    private Dictionary<string, bool> m_LoadedFlag = new Dictionary<string, bool>();
    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);
        m_LoadedFlag.Clear();
        PreloadResources();
        PreloadScenes();
    }

    protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        base.OnLeave(procedureOwner, isShutdown);
    }

    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        foreach (KeyValuePair<string, bool> loadedFlag in m_LoadedFlag)
        {
            if (!loadedFlag.Value)
            {
                return;
            }
        }
        ChangeState<ProcedureChangeScene>(procedureOwner);
    }

    private void PreloadResources()
    {

    }

    private void PreloadScenes()
    {
        if(SceneManager.sceneCount > 1)
        {
            UnityEngine.SceneManagement.Scene preloadScene = SceneManager.GetSceneAt(1);
            GameKitCenter.Scene.PreloadScene(preloadScene.name);
        }
    }
}

