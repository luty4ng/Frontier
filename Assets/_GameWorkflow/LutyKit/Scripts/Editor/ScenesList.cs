using UnityEditor;
using UnityEditor.SceneManagement;
namespace UnityGameKit.Editor
{
    public static class ScenesList
    {
        [MenuItem("Scenes/Default")]
        public static void Assets_GameMain_Scenes_Default_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/Default.unity"); }
    }
}
