using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _fillBar;
    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    private void OnEnable()
    {
        _player.HealthChange += UpdateFill;
        UpdateFill(_player.Health, _player.MaxHealth);
    }

    private void OnDisable()
    {
        _player.HealthChange -= UpdateFill;
    }

    private void UpdateFill(float health, float maxHealth)
    {
        if (health <= 0)
            _fillBar.fillAmount = 0;
        else
            _fillBar.fillAmount = health/maxHealth;
    }
}