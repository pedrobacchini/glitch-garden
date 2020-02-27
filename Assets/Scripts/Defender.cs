using Sirenix.OdinInspector;
using Sirenix.Serialization;

public class Defender : SerializedMonoBehaviour
{
    [OdinSerialize] public int StarCost { get; private set; }

    public void AddStars(int amount)
    {
        GameMaster.Instance.Starts.Value += amount;
    }
}
