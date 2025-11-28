using UnityEngine;
using TMPro;

public class DepositUI : MonoBehaviour
{
    [Header("Field")]
    [SerializeField] private TMP_InputField customInput;

    [Header("UI")]
    [SerializeField] private ATMUI atmUI; 

    [Header("Popup")]
    [SerializeField] private Popup alertPopup;

    private UserData Data =>
        GameManager.Instance != null ? GameManager.Instance.userData : null;

    private void OnEnable()
    {
        if (customInput != null)
            customInput.text = string.Empty;
    }

    private void Deposit(int amount)
    {
        if (Data == null) return;
        if (amount <= 0) return;

        if (Data.Cash < amount)
        {
            if (alertPopup != null)
                alertPopup.Open("현금이 부족합니다.");
            else
                Debug.Log("현금이 부족합니다.");
            return;
        }

        Data.Cash -= amount;
        Data.Balance += amount;

        if (atmUI != null)
            atmUI.Refresh();

        if (GameManager.Instance != null)
            GameManager.Instance.SaveUserData();
    }

    public void OnClickDeposit10K() => Deposit(10_000);
    public void OnClickDeposit30K() => Deposit(30_000);
    public void OnClickDeposit50K() => Deposit(50_000);

    public void OnClickCustomDeposit()
    {
        if (customInput == null)
        {
            Debug.LogWarning("customInput이 설정되지 않았습니다.");
            return;
        }

        string raw = customInput.text.Replace(",", "").Trim();

        if (!int.TryParse(raw, out int amount))
        {
            if (alertPopup != null)
                alertPopup.Open("Warning");
            else
                Debug.Log("올바른 숫자를 입력하세요.");
            return;
        }

        Deposit(amount);
    }

    public void OnClickBack()
    {
        gameObject.SetActive(false);
    }
}
