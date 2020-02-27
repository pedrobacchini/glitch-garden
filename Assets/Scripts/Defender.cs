using JetBrains.Annotations;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

public class Defender : SerializedMonoBehaviour
{
    [OdinSerialize] public int StarCost { get; private set; }

    [UsedImplicitly]
    public void AddStars(int amount)
    {
        GameMaster.Instance.Starts.Value += amount;
    }
}
