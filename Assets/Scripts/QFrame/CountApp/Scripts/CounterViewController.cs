using FrameworkDesign;
using UnityEngine;
using UnityEngine.UI;

namespace CounterApp
{
   /* public class CounterViewController : MonoObjController
    {
        private ICounterModel mCounterModel;

        void Start()
        {
            // 获取
            mCounterModel = this.GetModel<ICounterModel>(); // -+

            // 注册
            mCounterModel.Count.OnValueChanged += OnCountChanged;

            transform.Find("BtnAdd").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    // 交互逻辑
                    this.SendCommand<AddCountCommand>(); // -+
                });

            transform.Find("BtnSub").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    // 交互逻辑
                    this.SendCommand<SubCountCommand>(); // -+
                });

            OnCountChanged(mCounterModel.Count.Value);
        }

        // 表现逻辑
        private void OnCountChanged(int newValue)
        {
            transform.Find("CountText").GetComponent<Text>().text = newValue.ToString();
        }

        private void OnDestroy()
        {
            // 注销
            mCounterModel.Count.OnValueChanged -= OnCountChanged;

            mCounterModel = null;
        }

        public override IArchitecture GetArchitecture() // -+
        {
            return CounterApp.Interface;
        }
    }


    public interface ICounterModel : IModel
    {
        BindableProperty<int> Count { get; }
    }

    /// <summary>
    /// 不需要是单例了
    /// </summary>
    public class CounterModel : AbstractModel, ICounterModel
    {
        protected override void OnInit()
        {
            // 通过 Architrecture 获取
            var storage = this.GetUtility<IStorage>(); // 通过 this 调用

            Count.Value = storage.LoadInt("COUNTER_COUNT", 0);

            Count.OnValueChanged += count =>
            {
                storage.SaveInt("COUNTER_COUNT", count);
            };
        }

        public BindableProperty<int> Count { get; } = new BindableProperty<int>()
        {
            Value = 0
        };
    }*/
}