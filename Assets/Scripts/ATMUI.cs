using UnityEngine;
using TMPro;

public class ATMUI : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI userNameText;
    [SerializeField] private TextMeshProUGUI cashText;
    [SerializeField] private TextMeshProUGUI balanceText;

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        var data = GameManager.Instance.userData;

        userNameText.text = data.UserName;

        cashText.text = string.Format("{0:N0}", data.Cash);
        balanceText.text = string.Format("{0:N0}", data.Balance);
    }
}
