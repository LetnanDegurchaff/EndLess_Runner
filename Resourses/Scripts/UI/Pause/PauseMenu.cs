using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void Awake()
    {
        Time.timeScale = 0f;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }
}