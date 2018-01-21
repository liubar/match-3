namespace Domain
{
    public class GenerationGridState : StateGame
    {
        protected override void ChangeState(GameContext context, object[] additionalParams)
        {
            context.pieceGenerator.GenerateGrid(context.grid);
            context.State = new CheckMatchState();
        }
    }
}
