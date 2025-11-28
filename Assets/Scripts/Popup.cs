using UnityEngine;
using TMPro;

public class Popup : MonoBehaviour
{
    [SerializeField] private TMP_Text messageText;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Open(string message)
    {
        if (messageText != null)
            messageText.text = message;

        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
