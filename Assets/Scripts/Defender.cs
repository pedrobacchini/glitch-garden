using UnityEngine;

public class Defender : MonoBehaviour
{
    public int starCost;

    public void AddStars(int amount)
    {
        GameMaster.Instance.Starts.Value += amount;
    }
}
