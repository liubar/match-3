using System.Linq;

namespace Domain
{
    public class CheckMatchState : StateGame
    {
        protected override void ChangeState(GameContext context, object[] additionalParams)
        {
            var findMatchs = context.matchChecker.CheckMatch(context.grid);
            
            if (findMatchs.Any())
            {
                context.State = new MatchState(findMatchs);
            }
            else
            {
                context.State = new CheckChanceMacthState();
            }
        }
    }
}
