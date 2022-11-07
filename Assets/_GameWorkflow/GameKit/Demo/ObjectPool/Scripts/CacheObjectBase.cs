using UnityEngine;
using GameKit;
using GameKit.ObjectPool;

namespace UnityGameKit.Demo
{
    public class CacheObjectBase : ObjectBase
    {
        public static CacheObjectBase Create(object target)
        {
            CacheObjectBase baseObject = ReferencePool.Acquire<CacheObjectBase>();
            baseObject.Initialize(target);
            return baseObject;
        }

        protected override void Release(bool isShutdown)
        {
            CacheComponent monoObject = (CacheComponent)Target;
            if (monoObject == null)
                return;
            Object.Destroy(monoObject.gameObject);
        }

        protected override void OnSpawn()
        {
            base.OnSpawn();
            CacheComponent monoObject = (CacheComponent)Target;
            monoObject.gameObject.SetActive(true);
        }

        protected override void OnUnspawn()
        {
            base.OnUnspawn();
            CacheComponent monoObject = (CacheComponent)Target;
            monoObject.gameObject.SetActive(false);
        }
    }

}

