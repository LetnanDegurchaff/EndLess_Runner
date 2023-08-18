using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private Health _health = new Health(100);

    public event UnityAction<float, float> HealthChange;

    private void OnEnable()
    {
        _health = new Health(100);
        _health.HealthChange += OnHealthChange;
        _health.Died += Die;

        if (_health.IsAlive == false)
            Die();
    }

    private void OnDisable()
    {
        _health.HealthChange -= OnHealthChange;
        _health.Died -= Die;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _health.TakeDamage(enemy.Damage);
            enemy.gameObject.SetActive(false);
        }

        if (other.TryGetComponent<ReapairBox>(out ReapairBox reapairBox))
        {
            _health.TakeHealth(reapairBox.Heal);
            reapairBox.gameObject.SetActive(false);
        }
    }

    public float Health => _health.Value;
    public float MaxHealth => _health.MaxValue;

    public void OnHealthChange(float health, float maxHealth)
    {
        HealthChange?.Invoke(health, maxHealth);
    }

    private void Die() => gameObject.SetActive(false);
}