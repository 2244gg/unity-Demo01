using UnityEngine;

namespace FrameworkDesign.Example
{
    /// <summary>
    /// 1. ����ӿ�
    /// </summary>
    public interface ICanSayHello
    {
        void SayHello();
        void SayOther();
    }

    public class InterfaceDesignExample : MonoBehaviour, ICanSayHello
    {
        /// <summary>
        /// �ӿڵ���ʽʵ��
        /// </summary>
        public void SayHello()
        {
            Debug.Log("Hello");
        }

        /// <summary>
        /// �ӿڵ���ʽʵ��
        /// </summary>
        void ICanSayHello.SayOther()
        {
            Debug.Log("Other");
        }

        // Start is called before the first frame update
        void Start()
        {
            // ��ʽʵ�ֵķ�������ֱ��ͨ���������
            this.SayHello();

            // ��ʽʵ�ֵĽӿڲ���ͨ���������
            // this.SayOther() // �ᱨ�������

            // ��ʽʵ�ֵķ�������ͨ���ӿڶ������
            (this as ICanSayHello).SayOther();
        }
    }
}