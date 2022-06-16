/*using UnityEngine;

namespace FrameworkDesign.Example
{
    public class Game : MonoObjController // +
    {
        void Start()
        {
            this.RegisterEvent<GameStartEvent>(OnGameStart); // -+
        }

        private void OnGameStart(GameStartEvent e) // +
        {
            transform.Find("Enemies").gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            this.UnRegisterEvent<GameStartEvent>(OnGameStart); // -+
        }

        public IArchitecture GetArchitecture() // +
        {
            return PointGame.Interface;
        }
    }
}*/