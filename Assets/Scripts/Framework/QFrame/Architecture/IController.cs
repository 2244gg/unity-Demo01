using UnityEngine;
namespace FrameworkDesign
{
    public interface IController : IBelongToArchitecture, ICanGetSystem, ICanGetModel, ICanSendCommand, ICanRegisterEvent // +
    {
        /*string PrefabPath();
        void Recycle();
        GameObject CreateObj(Transform parent);

        void Destroy();*/
    }
}