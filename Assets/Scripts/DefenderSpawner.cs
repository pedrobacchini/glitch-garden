using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] private GameObject defender = null;

    private void Start()
    {
        this.OnMouseDownAsObservable()
            .Subscribe(_ => Instantiate(defender, transform.position, Quaternion.identity));
    }
}