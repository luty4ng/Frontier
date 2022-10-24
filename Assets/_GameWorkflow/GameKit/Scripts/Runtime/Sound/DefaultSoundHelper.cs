namespace UnityGameKit.Runtime
{
    /// <summary>
    /// 默认声音辅助器。
    /// </summary>
    public class DefaultSoundHelper : SoundHelperBase
    {

        /// <summary>
        /// 释放声音资源。
        /// </summary>
        /// <param name="soundAsset">要释放的声音资源。</param>
        public override void ReleaseSoundAsset(object soundAsset)
        {
            // YooAsset UnloadAsset
        }

        private void Start()
        {

        }
    }
}
