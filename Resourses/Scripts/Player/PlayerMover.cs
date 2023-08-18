using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _maxRight = 30;
    private float _minRight = -30;

    private PlayerInput _input = new PlayerInput();

    private void OnEnable()
    {
        _input.InputLeft += MoveLeft;
        _input.InputRight += MoveRight;
    }

    private void OnDisable()
    {
        _input.InputLeft -= MoveLeft;
        _input.InputRight -= MoveRight;
    }

    private void Update() => _input.ReadKeysInput();

    private void MoveLeft()
    {
        if (transform.position.x > _minRight)
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }

    private void MoveRight()
    {
        if (transform.position.x < _maxRight)
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }
}