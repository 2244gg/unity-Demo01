/*
--FileInfo:
--Author:
--CreateTime:2022-03-20-17:04:51
--Description:���ݵ���ط���
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign
{
    public class DataModelService: SingletonTool<DataModelService>
    {
        private Dictionary<EModuleState, CommonArchitecture> moduleCollection;
        // ����model��������
        public void Init()
        {
            moduleCollection = new Dictionary<EModuleState, CommonArchitecture>();

            CommonArchitecture loginArchitecture = new LoginArchitecture();

            RigisterModule(EModuleState.Login, loginArchitecture);

            CommonArchitecture lobbyArchiteture = new LobbyArchitecture();

            RigisterModule(EModuleState.Lobby, lobbyArchiteture);


        }
        /// <summary>
        /// ��ʼ��ʱʹ��
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void RigisterModule(EModuleState key, CommonArchitecture value)
        {
            if (moduleCollection.ContainsKey(key))
            {
                moduleCollection[key] = value;
            }
            else
            {
                moduleCollection.Add(key, value);
            }
        }
        public CommonArchitecture GetArchitectureByState(EModuleState moduleState)
        {
            CommonArchitecture architecture = null;
            if( moduleCollection.TryGetValue(moduleState, out architecture))
            {
                Debug.Log("��ȡ�ɹ�");
            }

            return architecture;
        }
    }
}