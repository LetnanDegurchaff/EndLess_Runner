using UnityEngine.Events;

public class Health
{
    private float _value;

    public Health(float value)
    {
        Value = value;
        MaxValue = value;
    }

    public event UnityAction<float,float> HealthChange;
    public event UnityAction Died; 

    public float Value 
    {
        get
        {
            return _value;
        }
        private set
        {
            _value = value;
            HealthChange?.Invoke(_value, MaxValue);
        }
    }
    public float MaxValue { get; private set; }

    public bool IsAlive => Value > 0;

    public void TakeDamage(float damage)
    {
        Value -= damage;

        if (IsAlive == false)
            Died?.Invoke();
    }

    public void TakeHealth(float health)
    {
        Value += health;

        if (Value > MaxValue)
            Value = MaxValue;
    }
}