using System.Collections.Generic;
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

    [Header("Upgrade Buttons")]
    [SerializeField] private Button idleMoneyIncreaseButton;
    [SerializeField] private Button wateringMoneyIncreaseButton;
    [SerializeField] private Button doubleClickChanceButton;
    [SerializeField] private Button waterQualityUpgradeButton;

    // Debug
    private int idleMoneyIncreaseCost = 10;


    [Header("Panels")]
    [SerializeField] private List<UIPanelEntry> panels = new List<UIPanelEntry>();


    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;

        upgradeButton.onClick.AddListener(() => ShowPanel("Upgrade"));
        shopButton.onClick.AddListener(() => ShowPanel("Shop"));
        gameButton.onClick.AddListener(() => ShowPanel("Game"));

        // Upgrade Buttons
        idleMoneyIncreaseButton.onClick.AddListener(() =>
        {
            if (ValueManager.Instance.CurrentMoney >= idleMoneyIncreaseCost)
            {
                ValueManager.Instance.PayForUpgrade(idleMoneyIncreaseCost);
                currentPlant.UpgradePassiveIncome();
            }
            else
            {
                Debug.Log("Not enough money");
                return;
            }


        });
        wateringMoneyIncreaseButton.onClick.AddListener(() => currentPlant.UpgradeClickIncome());
        waterQualityUpgradeButton.onClick.AddListener(() => ValueManager.Instance.IncreaseMultiplier());
        //doubleClickChanceButton.onClick.AddListener(() => UpgradeDoubleClickChance());
    }

    private void Update()
    {
        plantLevelText.text = "LVL: " + currentPlant.PlantLevel.ToString();
        diamondsText.text = ValueManager.Instance.CurrentDiamonds.ToString();
        
        if(ValueManager.Instance.CurrentMoney <= 999)
        {
            moneyText.text = ValueManager.Instance.CurrentMoney.ToString("F1");
        }
        else if( ValueManager.Instance.CurrentMoney >= 1000 && ValueManager.Instance.CurrentMoney <= 9999)
        {
            moneyText.text = ValueManager.Instance.CurrentMoney.ToString("F0");
        }
    }

    public void ShowPanel(string panelName)
    {
        foreach (var entry in panels)
        {
            entry.panelObject.SetActive(entry.panelName == panelName);
        }

        Debug.Log($"Switched to panel: {panelName}");
    }
}

[System.Serializable]
public class UIPanelEntry
{
    public string panelName;
    public GameObject panelObject;
}
