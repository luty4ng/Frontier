using UnityEngine;

namespace UnityGameKit.Runtime
{
    /// <summary>
    /// 游戏框架组件抽象类。
    /// </summary>
    public abstract class GameKitComponent : MonoBehaviour
    {
        /// <summary>
        /// 游戏框架组件初始化。
        /// </summary>
        protected virtual void Awake()
        {
            GameKitComponentCenter.RegisterComponent(this);
        }
    }
}
