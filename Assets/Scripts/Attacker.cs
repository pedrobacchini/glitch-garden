using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)] 
    [SerializeField] private float walkSpeed = 1;

    private void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ => transform.Translate(walkSpeed * Time.deltaTime * Vector2.left))
            .AddTo(this);
    }
}