using System;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign
{
    public interface IArchitecture
    {
        /// <summary>
        /// ע��ϵͳ
        /// </summary>
        void RegisterSystem<T>(T instance) where T : ISystem;

        /// <summary>
        /// ע�� Model
        /// </summary>
        void RegisterModel<T>(T instance) where T : IModel;


        /// <summary>
        /// ע�� Utility
        /// </summary>
        void RegisterUtility<T>(T instance) where T : IUtility;


        /// <summary>
        /// ��ȡ System
        /// </summary>
        T GetSystem<T>() where T : class, ISystem;

        /// <summary>
        /// ��ȡ Model
        /// </summary>
        T GetModel<T>() where T : class, IModel;

        /// <summary>
        /// ��ȡ����
        /// </summary>
        T GetUtility<T>() where T : class, IUtility;

        /// <summary>
        /// ��������
        /// </summary>
        void SendCommand<T>() where T : ICommand, new();

        /// <summary>
        /// ��������
        /// </summary>
        void SendCommand<T>(T command) where T : ICommand;


        /// <summary>
        /// �����¼�
        /// </summary>
        void SendEvent<T>() where T : new(); // +

        /// <summary>
        /// �����¼�
        /// </summary>
        void SendEvent<T>(T e); // +

        /// <summary>
        /// ע���¼�
        /// </summary>
        IUnRegister RegisterEvent<T>(Action<T> onEvent); // +

        /// <summary>
        /// ע���¼�
        /// </summary>
        void UnRegisterEvent<T>(Action<T> onEvent); // +

        void OnEnter();
        void OnExit();

    }
    /// <summary>
    /// �ܹ�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Architecture<T> : IArchitecture where T : Architecture<T>, new()
    {
        /// <summary>
        /// �Ƿ��Ѿ���ʼ�����
        /// </summary>
        private bool mInited = false;

        /// <summary>
        /// ���ڳ�ʼ���� Systems �Ļ���
        /// </summary>
        private List<ISystem> mSystems = new List<ISystem>();

        // �ṩһ��ע�� Model �� API
        public void RegisterSystem<T>(T instance) where T : ISystem
        {
            // ��Ҫ�� Model ��ֵһ��
            instance.SetArchitecture(this);

            mContainer.Register<T>(instance);

            // �����ʼ������
            if (mInited)
            {
                instance.Init();
            }
            else
            {
                // ��ӵ� Model �����У����ڳ�ʼ��
                mSystems.Add(instance);
            }
        }

        /// <summary>
        /// ���ڳ�ʼ���� Models �Ļ���
        /// </summary>
        private List<IModel> mModels = new List<IModel>();

        public void RegisterModel<T>(T instance) where T : IModel
        {
            // ��Ҫ�� Model ��ֵһ��
            instance.SetArchitecture(this);
            mContainer.Register<T>(instance);

            // �����ʼ������
            if (mInited)
            {
                instance.Init();
            }
            else
            {
                // ��ӵ� Model �����У����ڳ�ʼ��
                mModels.Add(instance);
            }
        }

        #region ���Ƶ���ģʽ ���ǽ����ڲ��η���-----------------------�˴�ʹ�õ���û�㶮------------------

        /// <summary>
        /// ע�Ჹ��
        /// </summary>
        public static Action<T> OnRegisterPatch = architecture => { };

        private static T mArchitecture = null;

        /// <summary>
        /// �ӿ�
        /// </summary>
        public static IArchitecture Interface
        {
            get
            {
                if (mArchitecture == null)
                {
                    MakeSureArchitecture();
                }

                return mArchitecture;
            }
        }

        // ȷ�� Container ����ʵ����
        static void MakeSureArchitecture()
        {
            if (mArchitecture == null)
            {
                mArchitecture = new T();
                mArchitecture.Init();

                // ����
                OnRegisterPatch?.Invoke(mArchitecture);

                // ��ʼ�� Model
                foreach (var architectureModel in mArchitecture.mModels)
                {
                    architectureModel.Init();
                }

                // ��� Model
                mArchitecture.mModels.Clear();

                // ��ʼ�� System

                foreach (var architectureSystem in mArchitecture.mSystems)
                {
                    architectureSystem.Init();
                }

                // ��� System
                mArchitecture.mSystems.Clear();

                mArchitecture.mInited = true;
            }
        }

        #endregion

        private IOCContainer mContainer = new IOCContainer();

        // ��������ע��ģ��
        protected abstract void Init();

        // �ṩһ��ע��ģ��� API
        public static void Register<T>(T instance)
        {
            MakeSureArchitecture();
            mArchitecture.mContainer.Register<T>(instance);
        }

        public void RegisterUtility<T>(T instance) where T : IUtility
        {
            mContainer.Register<T>(instance);
        }

        public T GetSystem<T>() where T : class, ISystem
        {
            return mContainer.Get<T>();
        }

        public T GetModel<T>() where T : class, IModel
        {
            return mContainer.Get<T>();
        }

        public T GetUtility<T>() where T : class, IUtility
        {
            return mContainer.Get<T>();
        }

        public void SendCommand<T>() where T : ICommand, new()
        {
            var command = new T();
            command.SetArchitecture(this);
            command.Execute();
        }

        public void SendCommand<T>(T command) where T : ICommand
        {
            command.SetArchitecture(this);
            command.Execute();
        }

        private ITypeEventSystem mTypeEventSystem = new TypeEventSystem(); // +

        public void SendEvent<T>() where T : new() // +
        {
            mTypeEventSystem.Send<T>();
        }

        public void SendEvent<T>(T e) // +
        {
            mTypeEventSystem.Send<T>(e);
        }

        public IUnRegister RegisterEvent<T>(Action<T> onEvent) // +
        {
            return mTypeEventSystem.Register<T>(onEvent);
        }

        public void UnRegisterEvent<T>(Action<T> onEvent) // +
        {
            mTypeEventSystem.UnRegister<T>(onEvent);
        }

        // �ṩһ����ȡģ��� API
        public static T Get<T>() where T : class
        {
            MakeSureArchitecture();
            return mArchitecture.mContainer.Get<T>();
        }


        #region ϵͳ��
        public virtual void OnEnter()
        {

        }
        public virtual void OnExit()
        {

        }
        #endregion



    }

    /// <summary>
    /// �Լܹ����һ��ʵ��ʹ֮�ܹ�������������
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CommonArchitecture : Architecture<CommonArchitecture>
    {
        protected MonoObjController monoObjController;
        public CommonArchitecture()
        {
            this.Init();
        }
       //  protected List<IController> controllers = new List<IController>();
        /*/// <summary>
        /// ��������
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objController"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public GameObject CreateObj<T>(T objController, Transform parent) where T : MonoObjController
        {
            GameObject obj = null;
            if (objController != null)
            {
                obj = objController.CreateObj(parent);
            }
            return obj;
        }
        public void DestoryController(MonoObjController objController)
        {
            if (objController != null)
            {
                if (controllers.Contains(objController))
                {
                    objController.Destroy();
                    controllers.Remove(objController);
                    objController = null;
                }
            }
        }*/
        protected override void Init()
        {

        }
        public override void OnEnter()
        {
            base.OnEnter();
        }
        public override void OnExit()
        {
            base.OnExit();
            if (monoObjController != null)
            {
                monoObjController.OnExit();
            }
        }
    }
}