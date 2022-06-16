using UnityEngine;

namespace FrameworkDesign.Example
{
    public class TypeEventSystemExample : MonoBehaviour
    {
        /// <summary>
        /// �¼� A
        /// </summary>
        public struct EventA
        {

        }

        /// <summary>
        /// �¼� B
        /// </summary>
        public struct EventB
        {
            public int ParamB;
        }

        /// <summary>
        /// ֧���¼��ļ̳�
        /// </summary>
        public interface IEventGroup
        {

        }

        public struct EventC : IEventGroup
        {

        }

        public struct EventD : IEventGroup
        {

        }

        private ITypeEventSystem mTypeEventSystem = null;

        void Start()
        {
            mTypeEventSystem = new TypeEventSystem();

            mTypeEventSystem.Register<EventA>(eA =>
            {
                Debug.Log("OnEventA");
            }).UnRegisterWhenGameObjectDestroyed(gameObject); // �� GameObject ����ʱ�Զ�����ע��

            mTypeEventSystem.Register<EventB>(OnEventB);

            mTypeEventSystem.Register<IEventGroup>(group =>
            {
                Debug.Log(group.GetType());

            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void OnEventB(EventB e)
        {
            Debug.Log("OnEventB:" + e.ParamB);
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                mTypeEventSystem.Send<EventA>();
            }

            if (Input.GetMouseButtonDown(1))
            {
                mTypeEventSystem.Send(new EventB()
                {
                    ParamB = 123
                });
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                mTypeEventSystem.Send<IEventGroup>(new EventC());
                mTypeEventSystem.Send<IEventGroup>(new EventD());
            }
        }

        private void OnDestroy()
        {
            mTypeEventSystem.UnRegister<EventB>(OnEventB);
            mTypeEventSystem = null;
        }
    }
}