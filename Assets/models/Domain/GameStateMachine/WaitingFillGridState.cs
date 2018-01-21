namespace Domain
{
    public class WaitingFillGridState : StateGame
    {
        protected override void ChangeState(GameContext context, object[] additionalParams)
        {
            if (context.grid.IsFull)
            {
                context.State = new CheckMatchState();
            }
        }
    }
}
