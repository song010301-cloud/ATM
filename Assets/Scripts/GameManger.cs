using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("User Data")]
    [SerializeField] private string defaultName = "JeongMin";
    [SerializeField] private int defaultCash = 100_000;
    [SerializeField] private int defaultBalance = 50_000;

    public UserData userData;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        LoadUserData();
    }

    public void SaveUserData()
    {
        if (userData == null) return;

        PlayerPrefs.SetString("UserName", userData.UserName);
        PlayerPrefs.SetInt("UserCash", userData.Cash);
        PlayerPrefs.SetInt("UserBalance", userData.Balance);
        PlayerPrefs.Save();
    }

    public void LoadUserData()
    {
        if (PlayerPrefs.HasKey("UserCash"))
        {
            string name = PlayerPrefs.GetString("UserName", defaultName);
            int cash = PlayerPrefs.GetInt("UserCash", defaultCash);
            int balance = PlayerPrefs.GetInt("UserBalance", defaultBalance);
            userData = new UserData(name, cash, balance);
        }
        else
        {
            userData = new UserData(defaultName, defaultCash, defaultBalance);
            SaveUserData();
        }
    }
}
