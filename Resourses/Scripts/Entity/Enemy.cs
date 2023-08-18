using UnityEngine;

public class Enemy : Entity
{
    public float Damage { get; private set; }

    private void Awake()
    {
        Damage = 10;
        Direction = Vector3.up;
    }
}