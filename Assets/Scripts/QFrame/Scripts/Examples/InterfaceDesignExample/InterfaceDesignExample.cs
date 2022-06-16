using UnityEngine;

namespace FrameworkDesign.Example
{
    /// <summary>
    /// 1. 定义接口
    /// </summary>
    public interface ICanSayHello
    {
        void SayHello();
        void SayOther();
    }

    public class InterfaceDesignExample : MonoBehaviour, ICanSayHello
    {
        /// <summary>
        /// 接口的隐式实现
        /// </summary>
        public void SayHello()
        {
            Debug.Log("Hello");
        }

        /// <summary>
        /// 接口的显式实现
        /// </summary>
        void ICanSayHello.SayOther()
        {
            Debug.Log("Other");
        }

        // Start is called before the first frame update
        void Start()
        {
            // 隐式实现的方法可以直接通过对象调用
            this.SayHello();

            // 显式实现的接口不能通过对象调用
            // this.SayOther() // 会报编译错误

            // 显式实现的方法必须通过接口对象调用
            (this as ICanSayHello).SayOther();
        }
    }
}