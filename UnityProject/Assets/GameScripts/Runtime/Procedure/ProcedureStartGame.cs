using System;
using Cysharp.Threading.Tasks;
using GameFramework.Fsm;
using GameFramework.Procedure;
using GameFramework.Resource;
using UnityEngine;

namespace GameMain
{
    public class ProcedureStartGame : ProcedureBase
    {
        public override bool UseNativeDialog { get; }

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            StartGame().Forget();
            //GameModule.Resource.LoadAsset<GameObject>("Assets/AssetRaw/Actor/Cube", LoadAsset);
            LoadCubeTest().Forget();
        }

        public  async UniTaskVoid LoadCubeTest()
        {
            GameObject objTmp = await GameModule.Resource.LoadAssetAsync<GameObject>("Assets/AssetRaw/Actor/Cube.prefab");
            if (objTmp == null)
            {
                Debug.LogError("加载不到");
                return;
            }
            GameObject gameObject = AssetsReference.Instantiate(objTmp as GameObject, null, null).gameObject;
        }

        public void LoadAsset(GameObject obj)
        {
            GameObject gameObject = AssetsReference.Instantiate(obj as GameObject, null,null).gameObject;
        }
        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
        }

        private async UniTaskVoid StartGame()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            UILoadMgr.HideAll();
            
        }
    }
}