using UnityEngine;
using UnityEngine.Events;

public class PlayerInput
{
    public event UnityAction InputLeft;
    public event UnityAction InputRight;

    public void ReadKeysInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            InputLeft?.Invoke();

        if (Input.GetKey(KeyCode.RightArrow))
            InputRight?.Invoke();
    }
}