namespace Domain
{
    public class WaitingState : StateGame
    {
        protected override void ChangeState(GameContext context, object[] additionalParams)
        {
            context.moveController.Update();
        }
    }
}
