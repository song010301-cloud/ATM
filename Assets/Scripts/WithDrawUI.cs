using UnityEngine;
using TMPro;

public class WithdrawUI : MonoBehaviour
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

    private void Withdraw(int amount)
    {
        if (Data == null) return;
        if (amount <= 0) return;

        if (Data.Balance < amount)
        {
            if (alertPopup != null)
                alertPopup.Open("잔액이 부족합니다.");
            else
                Debug.Log("잔액이 부족합니다.");
            return;
        }

        Data.Balance -= amount;
        Data.Cash += amount;

        if (atmUI != null)
            atmUI.Refresh();

        if (GameManager.Instance != null)
            GameManager.Instance.SaveUserData();
    }


    public void OnClickWithdraw10K() => Withdraw(10_000);
    public void OnClickWithdraw30K() => Withdraw(30_000);
    public void OnClickWithdraw50K() => Withdraw(50_000);

    public void OnClickCustomWithdraw()
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

        Withdraw(amount);
    }
}
