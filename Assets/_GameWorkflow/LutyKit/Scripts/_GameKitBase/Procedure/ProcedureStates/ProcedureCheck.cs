// using UnityGameKit.Runtime;
using ProcedureOwner = GameKit.Fsm.IFsm<GameKit.Procedure.IProcedureManager>;

// 决定资源加载模式
public class ProcedureCheck : ProcedureBase
{
    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        if (GameKitCenter.EditorResourceMode)
        {
            // 编辑器模式
            ChangeState<ProcedurePreload>(procedureOwner);
        }
        // else if (GameKitCenter.Resource.ResourceMode == ResourceMode.Package)
        // {
        //     // 单机模式
        //     Log.Info("Package resource mode detected.");
        //     ChangeState<ProcedureInitResources>(procedureOwner);
        // }
    }
}

