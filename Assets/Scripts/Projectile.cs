using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UniRx;
using UniRx.Triggers;
using Unity.Linq;
using UnityEngine;

public class Projectile : SerializedMonoBehaviour
{
    [PropertyRange(0f, 5f)]
    [OdinSerialize]
    public float MovementSpeed { get; private set; } = 1f;

    [OdinSerialize] public float Damage { get; private set; } = 20f;

    private void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ => transform.Translate(MovementSpeed * Time.deltaTime * Vector2.right))
            .AddTo(this);
    }

    public void Hit()
    {
        gameObject.Destroy();
    }
}