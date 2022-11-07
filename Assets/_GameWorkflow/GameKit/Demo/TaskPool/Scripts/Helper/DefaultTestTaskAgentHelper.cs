using UnityEngine;
using UnityGameKit.Runtime;
namespace UnityGameKit.Demo
{
    public class DefaultTestTaskAgentHelper : TestTaskAgentHelperBase
    {
        public override void CallHelper(string arg)
        {
            Log.Info("Call Example Helper with Arg: {0}", arg);
        }
    }
}