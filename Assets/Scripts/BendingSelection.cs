using UnityEngine;

public class BendingSelection : MonoBehaviour
{
    public void SetAirBending()
    {
        UserState.Instance.bendingState = BendingState.AirBending;
    }

    public void SetWaterBending()
    {
        UserState.Instance.bendingState = BendingState.WaterBending;
    }

    public void SetEarthBending()
    {
        UserState.Instance.bendingState = BendingState.EarthBending;
    }

    public void SetFireBending()
    {
        UserState.Instance.bendingState = BendingState.FireBending;
    }
}
