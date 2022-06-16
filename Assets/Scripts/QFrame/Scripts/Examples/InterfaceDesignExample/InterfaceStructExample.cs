//��һ�־��ǱȽϳ����� �ӿ�-������-ʵ����Ľṹ��ʾ���������£�
using UnityEngine;

namespace FrameworkDesign.Example
{
    public class InterfaceStructExample : MonoBehaviour
    {
        /// <summary>
        /// �ӿ�
        /// </summary>
        public interface ICustomScript
        {
            void Start();
            void Update();
            void Destroy();
        }

        /// <summary>
        /// ������
        /// </summary>
        public abstract class CustomScript : ICustomScript
        {
            protected bool mStarted { get; private set; }
            protected bool mDestroyed { get; private set; }

            /// <summary>
            /// ��ϣ��������� Start ��������Ϊ�п����ƻ�״̬
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
            /// ϣ������ʵ�� OnStart ����
            /// </summary>
            protected abstract void OnStart();
            protected abstract void OnUpdate();
            protected abstract void OnDestroy();
        }

        /// <summary>
        /// ���û���չ����
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
        /// ���Խű�
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