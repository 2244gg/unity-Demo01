/*
--FileInfo:
--Author:
--CreateTime:2022-03-20-17:04:51
--Description:数据的相关服务
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign
{
    public class DataModelService: SingletonTool<DataModelService>
    {
        private Dictionary<EModuleState, CommonArchitecture> moduleCollection;
        // 数据model服务启动
        public void Init()
        {
            moduleCollection = new Dictionary<EModuleState, CommonArchitecture>();

            CommonArchitecture loginArchitecture = new LoginArchitecture();

            RigisterModule(EModuleState.Login, loginArchitecture);

            CommonArchitecture lobbyArchiteture = new LobbyArchitecture();

            RigisterModule(EModuleState.Lobby, lobbyArchiteture);


        }
        /// <summary>
        /// 初始化时使用
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
                Debug.Log("获取成功");
            }

            return architecture;
        }
    }
}