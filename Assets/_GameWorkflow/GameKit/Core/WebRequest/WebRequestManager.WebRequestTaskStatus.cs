﻿namespace GameKit.WebRequest
{
    internal sealed partial class WebRequestManager : GameKitModule, IWebRequestManager
    {
        /// <summary>
        /// Web 请求任务的状态。
        /// </summary>
        private enum WebRequestTaskStatus : byte
        {
            /// <summary>
            /// 准备请求。
            /// </summary>
            Todo = 0,

            /// <summary>
            /// 请求中。
            /// </summary>
            Doing,

            /// <summary>
            /// 请求完成。
            /// </summary>
            Done,

            /// <summary>
            /// 请求错误。
            /// </summary>
            Error
        }
    }
}
