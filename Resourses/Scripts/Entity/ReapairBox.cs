using UnityEngine;

public class ReapairBox : Entity
{
    public float Heal { get; private set; }

    private void Awake()
    {
        Heal = 10;
        Direction = Vector3.back;
    }
}