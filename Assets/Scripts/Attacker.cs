using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Attacker : SerializedMonoBehaviour
{
    [PropertyRange(0f, 5f)] 
    [OdinSerialize] public float WalkSpeed { get; set; }

    private void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ => transform.Translate(WalkSpeed * Time.deltaTime * Vector2.left))
            .AddTo(this);
    }
}