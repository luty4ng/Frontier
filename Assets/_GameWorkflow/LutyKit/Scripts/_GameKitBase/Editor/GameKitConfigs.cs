using System;
using GameKit;
using System.IO;
using UnityEngine;
using UnityGameKit.Editor;
using UnityGameKit.Editor.ResourceTools;


public static class GameKitConfigs
{
    private const string WorkFlowPath = "/_GameWorkflow";
    [BuildSettingsConfigPath]
    public static string BuildSettingsConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath + WorkFlowPath, "/GameMain/Configs/BuildSettings.xml"));

    [ResourceCollectionConfigPath]
    public static string ResourceCollectionConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath + WorkFlowPath, "GameMain/Configs/ResourceCollection.xml"));

    [ResourceEditorConfigPath]
    public static string ResourceEditorConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath + WorkFlowPath, "GameMain/Configs/ResourceEditor.xml"));

    [ResourceBuilderConfigPath]
    public static string ResourceBuilderConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath + WorkFlowPath, "GameMain/Configs/ResourceBuilder.xml"));
}

