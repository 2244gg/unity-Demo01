//第一种就是比较常见的 接口-抽象类-实现类的结构，示例代码如下：
using UnityEngine;

namespace FrameworkDesign.Example
{
    public class InterfaceStructExample : MonoBehaviour
    {
        /// <summary>
        /// 接口
        /// </summary>
        public interface ICustomScript
        {
            void Start();
            void Update();
            void Destroy();
        }

        /// <summary>
        /// 抽象类
        /// </summary>
        public abstract class CustomScript : ICustomScript
        {
            protected bool mStarted { get; private set; }
            protected bool mDestroyed { get; private set; }

            /// <summary>
            /// 不希望子类访问 Start 方法，因为有可能破坏状态
            /// </summary>
            void ICustomScript.Start()
            {
                OnStart();
                mStarted = true;
            }

            void ICustomScript.Update()
            {
                OnUpdate();
            }

            void ICustomScript.Destroy()
            {
                OnDestroy();
                mDestroyed = true;
            }

            /// <summary>
            /// 希望子类实现 OnStart 方法
            /// </summary>
            protected abstract void OnStart();
            protected abstract void OnUpdate();
            protected abstract void OnDestroy();
        }

        /// <summary>
        /// 由用户扩展的类
        /// </summary>
        public class MyScript : CustomScript
        {
            protected override void OnStart()
            {
                Debug.Log("MyScript:OnStart");
            }

            protected override void OnUpdate()
            {
                Debug.Log("MyScript:OnUpdate");
            }

            protected override void OnDestroy()
            {
                Debug.Log("MyScript:OnDestroy");
            }
        }

        /// <summary>
        /// 测试脚本
        /// </summary>
        private void Start()
        {
            ICustomScript script = new MyScript();
            script.Start();
            script.Update();
            script.Destroy();
        }
    }
}