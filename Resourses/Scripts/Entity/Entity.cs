using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public abstract class Entity : MonoBehaviour
{
    [SerializeField] private float _speed;

    protected Vector3 Direction;
    public event UnityAction<Entity> Died;

    private void Update() => 
        transform.Translate(Direction * _speed * Time.deltaTime);

    private void OnDisable() => Died?.Invoke(this);
}