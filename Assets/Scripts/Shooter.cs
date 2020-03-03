using System;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Shooter : MonoBehaviour
{
    [SerializeField] private Projectile projectile = null;
    [SerializeField] private GameObject gun = null;

    private AttackerSpawner _lane = null;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        //Set Lane
        _lane = FindObjectsOfType<AttackerSpawner>()
            .First(position => Math.Abs(position.transform.position.y - transform.position.y) < Mathf.Epsilon);
    }

    private void Update()
    {
        _animator.SetBool("Shooting", AttackerInLane());
    }

    [UsedImplicitly]
    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, Quaternion.identity);
    }

    private bool AttackerInLane()
    {
        return _lane && _lane.gameObject.transform.childCount > 0;
    }
}