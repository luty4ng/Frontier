using UnityEngine;

namespace UnityGameKit.Runtime
{
    public sealed partial class DebuggerComponent : GameKitComponent
    {
        private sealed class OperationsWindow : ScrollableDebuggerWindowBase
        {
            protected override void OnDrawScrollableWindow()
            {
                GUILayout.Label("<b>Operations</b>");
                GUILayout.BeginVertical("box");
                {
                    ObjectPoolComponent objectPoolComponent = GameKitComponentCenter.GetComponent<ObjectPoolComponent>();
                    if (objectPoolComponent != null)
                    {
                        if (GUILayout.Button("Object Pool Release", GUILayout.Height(30f)))
                        {
                            objectPoolComponent.Release();
                        }

                        if (GUILayout.Button("Object Pool Release All Unused", GUILayout.Height(30f)))
                        {
                            objectPoolComponent.ReleaseAllUnused();
                        }
                    }

                    if (GUILayout.Button("Unload Unused Assets", GUILayout.Height(30f)))
                    {
                        YooAsset.YooAssets.ForceUnloadAllAssets();       
                    }
                    
                    if (GUILayout.Button("Shutdown Game Kit (None)", GUILayout.Height(30f)))
                    {
                        GameKitComponentCenter.Shutdown(ShutdownType.None);
                    }
                    if (GUILayout.Button("Shutdown Game Kit (Restart)", GUILayout.Height(30f)))
                    {
                        GameKitComponentCenter.Shutdown(ShutdownType.Restart);
                    }
                    if (GUILayout.Button("Shutdown Game Kit (Quit)", GUILayout.Height(30f)))
                    {
                        GameKitComponentCenter.Shutdown(ShutdownType.Quit);
                    }
                }
                GUILayout.EndVertical();
            }
        }
    }
}
