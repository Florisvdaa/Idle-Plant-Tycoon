using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI upgradeNameText;
    [SerializeField] private TextMeshProUGUI upgradeIncreaseText;
    [SerializeField] private TextMeshProUGUI upgradeCostText;
    [SerializeField] private Button upgradeButton;

    [Header("Upgrade Data")]
    [SerializeField] private UpgradeSO upgradeData;

    private void Start()
    {
        if (UpgradeManager.Instance != null)
        {
            UpdateUI();
            upgradeButton.onClick.AddListener(() => ApplyUpgrade());
        }    
    }

    public void UpdateUI()
    {
        upgradeNameText.text = upgradeData.upgradeName;
        upgradeIncreaseText.text = $"+{upgradeData.upgradeMultiplier}";
        upgradeCostText.text = $"Cost: {upgradeData.CurrentCost:F0}";
    }

    private void ApplyUpgrade()
    {
        UpgradeManager.Instance.TryApplyUpgrade(upgradeData);
        UpdateUI();
    }
}
