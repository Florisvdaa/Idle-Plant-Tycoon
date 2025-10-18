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
    [SerializeField] private TextMeshProUGUI moneyPerSecondText;
    [SerializeField] private TextMeshProUGUI diamondsText;

    [Header("Menu Buttons")]
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button shopButton;
    [SerializeField] private Button gameButton;

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

        //RefreshAllUpgradeButtons();
    }

    private void Update()
    {
        plantLevelText.text = "LVL: " + currentPlant.PlantLevel.ToString();
        diamondsText.text = ValueManager.Instance.CurrentDiamonds.ToString();
        moneyPerSecondText.text = currentPlant.BasePassiveMoneyValue.ToString() + "/s";
        moneyText.text = ValueManager.Instance.CurrentMoney.ToString();

       
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
