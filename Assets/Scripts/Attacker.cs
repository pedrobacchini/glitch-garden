using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Attacker : SerializedMonoBehaviour
{
    [Range(0f, 5f)] [SerializeField] private float movementSpeed = 1f;
    private float _stopSpeed;

    private void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ => transform.Translate(movementSpeed * Time.deltaTime * Vector2.left))
            .AddTo(this);
    }

    [UsedImplicitly]
    public void StopMovement()
    {
        _stopSpeed = movementSpeed;
        movementSpeed = 0;
    }

    [UsedImplicitly]
    public void ContinueMovement()
    {
        movementSpeed = _stopSpeed;
    }
}