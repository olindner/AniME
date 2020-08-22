public class UserState
{
    private static UserState _instance;
    private static readonly object Padlock = new object();
    public BendingState bendingState = BendingState.AirBending;

    public static UserState Instance
    {
        get
        {
            lock (Padlock)
            {
                if (_instance == null)
                {
                    _instance = new UserState();
                }
                return _instance;
            }
        }
    }

}
