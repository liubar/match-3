namespace Domain
{
    public class CheckChanceMacthState : StateGame
    {
        protected override void ChangeState(GameContext context, object[] additionalParams)
        {
            if(context.matchChecker.CheckChanceMacth(context.grid))
            {
                context.State = new WaitingState();
            }
            else
            {
                context.pieceGenerator.GenerateGrid(context.grid);
            }
        }
    }
}
