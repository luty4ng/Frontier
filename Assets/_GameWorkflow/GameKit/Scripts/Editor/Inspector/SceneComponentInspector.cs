﻿using UnityEditor;
using UnityEngine;
using UnityGameKit.Runtime;

namespace UnityGameKit.Editor
{
    [CustomEditor(typeof(SceneComponent))]
    internal sealed class SceneComponentInspector : GameKitInspector
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            serializedObject.Update();

            SceneComponent t = (SceneComponent)target;

            EditorGUI.BeginDisabledGroup(EditorApplication.isPlayingOrWillChangePlaymode);
            {
                
            }
            EditorGUI.EndDisabledGroup();

            serializedObject.ApplyModifiedProperties();

            if (EditorApplication.isPlaying && IsPrefabInHierarchy(t.gameObject))
            {
                EditorGUILayout.LabelField("Loaded Scene Asset Names", GetSceneNameString(t.GetLoadedSceneAssetNames()));
                EditorGUILayout.LabelField("Loading Scene Asset Names", GetSceneNameString(t.GetLoadingSceneAssetNames()));
                EditorGUILayout.LabelField("Unloading Scene Asset Names", GetSceneNameString(t.GetUnloadingSceneAssetNames()));
                EditorGUILayout.ObjectField("Main Camera", t.MainCamera, typeof(Camera), true);

                Repaint();
            }
        }

        private void OnEnable()
        {
            
        }

        private string GetSceneNameString(string[] sceneAssetNames)
        {
            if (sceneAssetNames == null || sceneAssetNames.Length <= 0)
            {
                return "<Empty>";
            }

            string sceneNameString = string.Empty;
            foreach (string sceneAssetName in sceneAssetNames)
            {
                if (!string.IsNullOrEmpty(sceneNameString))
                {
                    sceneNameString += ", ";
                }

                sceneNameString += SceneComponent.GetSceneName(sceneAssetName);
            }

            return sceneNameString;
        }
    }
}
