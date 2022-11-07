using GameKit.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityGameKit.Runtime;
using ProcedureOwner = GameKit.Fsm.IFsm<GameKit.Procedure.IProcedureManager>;

public static class ProcedureExtension
{    
    public static void ChangeSceneByDoor(this ProcedureComponent procedureComponent, string sceneName, string doorName)
    {
        ProcedureMain mainProcedure = (ProcedureMain)procedureComponent.GetProcedure<ProcedureMain>();
        mainProcedure.SetNextSceneName(sceneName);
        mainProcedure.SetCachedDoorName(doorName);
        mainProcedure.EnableChangeScene();
    }

    public static void ChangeScene(this ProcedureComponent procedureComponent, string sceneName)
    {
        ProcedureMain mainProcedure = (ProcedureMain)procedureComponent.GetProcedure<ProcedureMain>();
        mainProcedure.SetNextSceneName(sceneName);
        mainProcedure.EnableChangeScene();
    }
}