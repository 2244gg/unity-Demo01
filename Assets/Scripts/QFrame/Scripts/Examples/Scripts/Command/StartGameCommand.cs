namespace FrameworkDesign.Example
{
    public class StartGameCommand : AbstractCommand, ICommand
    {
        protected override void OnExecute()
        {
            this.SendEvent<GameStartEvent>(); // -+
        }
    }
}