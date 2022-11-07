using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityGameKit.Runtime;
using GameKit.ObjectPool;
using YooAsset;
using Cysharp.Threading.Tasks;

namespace UnityGameKit.Demo
{
    public class ObjectPoolDemo : MonoBehaviour
    {
        private const int POOL_SIZE = 16;
        public CacheComponent monoObject_Prototype;
        public Queue<CacheObjectBase> baseObject_Tests;
        private IObjectPool<CacheObjectBase> baseObjectPool = null;
        void Start()
        {
            baseObject_Tests = new Queue<CacheObjectBase>();
            baseObjectPool = GameKitComponentCenter.GetComponent<ObjectPoolComponent>().CreateSingleSpawnObjectPool<CacheObjectBase>("Cache ObjectPool", POOL_SIZE);
        }

        private async void CreateObject()
        {
            CacheComponent monoObject = null;
            CacheObjectBase baseObject = baseObjectPool.Spawn();
            if (baseObject != null)
            {
                monoObject = (CacheComponent)baseObject.Target;
            }
            else
            {
                AssetOperationHandle handle = YooAsset.YooAssets.LoadAssetAsync<CacheComponent>("CubeForObjectPool");
                // Assets/_GameWorkflow/GameKit/Demo/ObjectPool/Prefab/CubeForObjectPool.prefab
                await handle.ToUniTask();
                monoObject_Prototype = handle.AssetObject as CacheComponent;
                monoObject = Instantiate(monoObject_Prototype);
                Transform transform = monoObject.GetComponent<Transform>();
                transform.localScale = Vector3.one;
                baseObject = CacheObjectBase.Create(monoObject);
                baseObjectPool.Register(baseObject, true);
            }

            StartCoroutine(DelayedExcute(() =>
            {
                baseObjectPool.Unspawn(baseObject);
            }, 1f));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CreateObject();
            }

            // if (Input.GetKeyDown(KeyCode.Q))
            // {
            //     baseObjectPool.Unspawn(baseObject_Tests.Dequeue());
            // }


        }

        private IEnumerator DelayedExcute(UnityAction action, float t)
        {
            yield return new WaitForSeconds(t);
            action?.Invoke();
        }

        private void UnspawnObject(CacheObjectBase baseObject1)
        {
            baseObjectPool.Unspawn(baseObject1);
        }
    }

}

