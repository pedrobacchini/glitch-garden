using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Random = UnityEngine.Random;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] private Attacker lizardPrefab = null;
    [SerializeField] private float minSpawnDelay = 1;
    [SerializeField] private float maxSpawnDelay = 5;
    private readonly CompositeDisposable _disposables = new CompositeDisposable();

    private void Start()
    {
        Observable.Return(Unit.Default)
            .SelectMany(_ => Observable.Timer(TimeSpan.FromSeconds(Random.Range(minSpawnDelay, maxSpawnDelay + 1))))
            .Do(_ => SpawnAttacker())
            .Repeat()
            .Subscribe()
            .AddTo(_disposables);

        this.OnDisableAsObservable()
            .Do(_ => _disposables.Clear())
            .Subscribe();
    }

    private void SpawnAttacker()
    {
        Instantiate(lizardPrefab, transform.position, Quaternion.identity);
    }
}