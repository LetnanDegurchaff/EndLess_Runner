using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    private PauseMenu _menu;
    private Button _button;

    private void Awake()
    {
        _menu = FindObjectOfType<PauseMenu>();
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        Time.timeScale = 0;
        _menu.gameObject.SetActive(true);
    }
}