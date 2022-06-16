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
            // ��ȡ
            mCounterModel = this.GetModel<ICounterModel>(); // -+

            // ע��
            mCounterModel.Count.OnValueChanged += OnCountChanged;

            transform.Find("BtnAdd").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    // �����߼�
                    this.SendCommand<AddCountCommand>(); // -+
                });

            transform.Find("BtnSub").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    // �����߼�
                    this.SendCommand<SubCountCommand>(); // -+
                });

            OnCountChanged(mCounterModel.Count.Value);
        }

        // �����߼�
        private void OnCountChanged(int newValue)
        {
            transform.Find("CountText").GetComponent<Text>().text = newValue.ToString();
        }

        private void OnDestroy()
        {
            // ע��
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
    /// ����Ҫ�ǵ�����
    /// </summary>
    public class CounterModel : AbstractModel, ICounterModel
    {
        protected override void OnInit()
        {
            // ͨ�� Architrecture ��ȡ
            var storage = this.GetUtility<IStorage>(); // ͨ�� this ����

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