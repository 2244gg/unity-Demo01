namespace FrameworkDesign.Example
{
    public class PointGame : Architecture<PointGame>
    {
        // ����ע��ģ��
        protected override void Init()
        {
            Register<IGameModel>(new GameModel());
        }
    }
}