namespace AI
{
    public class FSMAI
    {
        IState currentState;

        public FSMAI(IState startingState)
        {
            currentState = startingState;
        }

        public void Update()
        {
            currentState = currentState.Process();
        }
    }
}