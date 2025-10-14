using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private Plant currentPlant;

    [SerializeField] private TextMeshProUGUI plantLevelText;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI diamondsText;

    [Header("Menu Buttons")]
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button shopButton;
    [SerializeField] private Button gameButton;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;

        upgradeButton.onClick.AddListener(ShowUpgradePanel);
        shopButton.onClick.AddListener(ShowUpgradePanel);
        gameButton.onClick.AddListener(ShowGamePanel);
    }

    private void Update()
    {
        plantLevelText.text = "LVL: " + currentPlant.PlantLevel.ToString();
        moneyText.text = ValueManager.Instance.CurrentMoney.ToString();
        diamondsText.text = ValueManager.Instance.CurrentDiamonds.ToString();
    }

    private void ShowUpgradePanel()
    {
        Debug.Log("upgrade panel");
    }

    public void ShowShopPanel()
    {
        Debug.Log("Shop panel");

    }
    public void ShowGamePanel()
    {
        Debug.Log("Game panel");

    }
}
