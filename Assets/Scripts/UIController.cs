using UnityEngine;

public class BankUIController : MonoBehaviour
{
    [Header("메인 패널")]
    [SerializeField] private GameObject mainPanel;

    [Header("입금 패널")]
    [SerializeField] private GameObject depositPanel;

    [Header("출금 패널")]
    [SerializeField] private GameObject withdrawPanel;

    private void Start()
    {
        ShowMain();
    }

    public void ShowMain()
    {
        if (mainPanel != null) mainPanel.SetActive(true);
        if (depositPanel != null) depositPanel.SetActive(false);
        if (withdrawPanel != null) withdrawPanel.SetActive(false);
    }

    public void ShowDeposit()
    {
        if (mainPanel != null) mainPanel.SetActive(false);
        if (depositPanel != null) depositPanel.SetActive(true);
        if (withdrawPanel != null) withdrawPanel.SetActive(false);
    }

    public void ShowWithdraw()
    {
        if (mainPanel != null) mainPanel.SetActive(false);
        if (depositPanel != null) depositPanel.SetActive(false);
        if (withdrawPanel != null) withdrawPanel.SetActive(true);
    }
}
