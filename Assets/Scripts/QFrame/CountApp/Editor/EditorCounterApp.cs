/*using FrameworkDesign;
using UnityEditor;
using UnityEngine;

namespace CounterApp
{
    public class EditorCounterApp : EditorWindow, IController
    {
        /// <summary>
        /// �򿪴���
        /// </summary>
        [MenuItem("EditorCounterApp/Open")]
        static void Open()
        {
            // ��Ҫ�������л�һ�� Storage ��ʵ��
            CounterApp.OnRegisterPatch += architecture =>
            {
                architecture.RegisterUtility<IStorage>(new EditorPrefsStorage());
            };

            var editorCounterApp = GetWindow<EditorCounterApp>();
            editorCounterApp.name = nameof(EditorCounterApp);
            editorCounterApp.position = new Rect(100, 100, 400, 600);
            editorCounterApp.Show();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("+"))
            {
                this.SendCommand<AddCountCommand>(); //-+
            }

            //  ����ʵʱˢ�� ����ֱ�Ӿ;���Ⱦ���ݼ���
            GUILayout.Label(CounterApp.Get<ICounterModel>().Count.Value.ToString());

            if (GUILayout.Button("-"))
            {
                this.SendCommand<SubCountCommand>(); //-+
            }
        }

        IArchitecture IBelongToArchitecture.GetArchitecture() // -+
        {
            return CounterApp.Interface;
        }

        string IController.PrefabPath()
        {
            throw new System.NotImplementedException();
        }
    }
}*/