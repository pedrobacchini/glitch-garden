using Sirenix.OdinInspector;
using Sirenix.Serialization;

public class DefenderButton : SerializedMonoBehaviour
{
    [OdinSerialize] public Defender Defender { get; private set; }
}