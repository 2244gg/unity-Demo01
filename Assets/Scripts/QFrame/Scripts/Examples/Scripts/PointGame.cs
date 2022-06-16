namespace FrameworkDesign.Example
{
    public class PointGame : Architecture<PointGame>
    {
        // ÕâÀï×¢²áÄ£¿é
        protected override void Init()
        {
            Register<IGameModel>(new GameModel());
        }
    }
}