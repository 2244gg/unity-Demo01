using UnityEngine;

namespace FrameworkDesign.Example
{
    public class IOCExample : MonoBehaviour
    {
        void Start()
        {
            // ����һ�� IOC ����
            var container = new IOCContainer();

            // ���ݽӿ�ע��ʵ��
            container.Register<IBluetoothManager>(new BluetoothManager());

            // ���ݽӿڻ�ȡ������������ʵ��
            var bluetoothManager = container.Get<IBluetoothManager>();

            //��������
            bluetoothManager.Connect();
        }

        /// <summary>
        /// ����ӿ�
        /// </summary>
        public interface IBluetoothManager
        {
            void Connect();
        }

        /// <summary>
        /// ʵ�ֽӿ�
        /// </summary>
        public class BluetoothManager : IBluetoothManager
        {
            public void Connect()
            {
                Debug.Log("�������ӳɹ�");
            }
        }
    }
}