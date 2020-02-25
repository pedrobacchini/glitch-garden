using UniRx;
using UniRx.Triggers;
using Unity.Collections;
using Unity.Linq;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startHealth = 100f;
    [SerializeField] [ReadOnly] private float _currentHealth;
    [SerializeField] private GameObject deathVFX = null;

    private void Start()
    {
        _currentHealth = startHealth;

        this.OnTriggerEnter2DAsObservable()
            .Select(otherCollider => otherCollider.gameObject.GetComponent<Projectile>())
            .Where(projectile => projectile != null)
            .Subscribe(projectile =>
            {
                projectile.Hit();
                DealDamage(projectile.Damage);
            })
            .AddTo(this);
    }

    private void DealDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0) Die();
    }

    private void Die()
    {
        GameMaster.Instance.Starts.Value += 20;
        gameObject.Destroy();
        TriggerDeathEffect();
    }

    private void TriggerDeathEffect()
    {
        if (!deathVFX) return;
        var instantiate = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(instantiate, 1f);
    }
}