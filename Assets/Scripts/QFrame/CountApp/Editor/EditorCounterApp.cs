/*using FrameworkDesign;
using UnityEditor;
using UnityEngine;

namespace CounterApp
{
    public class EditorCounterApp : EditorWindow, IController
    {
        /// <summary>
        /// 打开窗口
        /// </summary>
        [MenuItem("EditorCounterApp/Open")]
        static void Open()
        {
            // 需要在这里切换一下 Storage 的实现
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

            //  由于实时刷新 所以直接就就渲染数据即可
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