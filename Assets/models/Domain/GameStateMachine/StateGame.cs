namespace Domain
{
    public abstract class StateGame
    {
        public virtual void HandleState(GameContext context, object[] additionalParams = null)
        {
            ChangeState(context, additionalParams);
        }

        protected abstract void ChangeState(GameContext context, object[] additionalParams);
    }
}
