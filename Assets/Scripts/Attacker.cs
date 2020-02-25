using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Attacker : SerializedMonoBehaviour
{
    [PropertyRange(0f, 5f)]
    [OdinSerialize]
    public float MovementSpeed { get; set; } = 1f;

    private void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ => transform.Translate(MovementSpeed * Time.deltaTime * Vector2.left))
            .AddTo(this);
    }
}