

using System.Collections.Generic;
using UnityGameKit.Runtime;
using ProcedureOwner = GameKit.Fsm.IFsm<GameKit.Procedure.IProcedureManager>;


public class ProcedureMain : ProcedureBase
{
    private ProcedureOwner m_CachedOwner;
    private bool m_CanChangeScene;
    protected override void OnInit(ProcedureOwner procedureOwner)
    {
        base.OnInit(procedureOwner);
        m_CachedOwner = procedureOwner;
    }
    protected override void OnDestroy(ProcedureOwner procedureOwner)
    {
        base.OnDestroy(procedureOwner);
    }

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);
        m_CanChangeScene = false;
    }

    protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        base.OnLeave(procedureOwner, isShutdown);
    }

    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        if (m_CanChangeScene)
            ChangeState<ProcedureChangeScene>(m_CachedOwner);
    }

    public void SetNextSceneName(string sceneName) => m_CachedOwner.SetData<VarString>(ProcedureStateUtility.NEXT_SCENE_NAME, sceneName);
    public void SetCachedDoorName(string doorName) => m_CachedOwner.SetData<VarString>(ProcedureStateUtility.CACHED_DOOR_NAME, doorName);
    public void EnableChangeScene() => m_CanChangeScene = true;
}

