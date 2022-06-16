/*using UnityEngine;
using UnityEngine.UI;

// 写命名空间是个好习惯
namespace FrameworkDesign.Example
{
    public class Enemy : MonoObjController
    {
        /// <summary>
        /// 点击自己则销毁
        /// </summary>
        private void OnMouseDown()
        {
            Destroy(gameObject);

            this.SendCommand<KillEnemyCommand>(); // -+
        }

        public override IArchitecture GetArchitecture() // -+
        {
            return PointGame.Interface;
        }
    }
}*/