using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance { get; private set; }

    [SerializeField] private Plant plant;

    public List<UpgradeSO> allUpgrades;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;

        foreach (var upgrade in allUpgrades)
        {
            upgrade.currentLevel = 0;
        }

    }
    public void TryApplyUpgrade(UpgradeSO upgrade)
    {
        float cost = upgrade.CurrentCost;

        if(ValueManager.Instance.CurrentMoney >= cost)
        {
            ValueManager.Instance.PayForUpgrade(cost);
            upgrade.ApplyUpgrade();
            switch (upgrade.upgradeType)
            {
                case Upgrade.IdleMoney:
                    plant.UpgradePassiveIncome(upgrade.upgradeMultiplier);
                    break;
                case Upgrade.ClickMoney:
                    plant.UpgradeClickIncome(upgrade.upgradeMultiplier);
                    break;
                case Upgrade.WaterQuality:
                    ValueManager.Instance.IncreaseMultiplier();
                    break;
                    // Add more cases as needed
            }

            Debug.Log($"Applied upgrade: {upgrade.upgradeName}, new cost: {upgrade.CurrentCost}");
        }
        else
        {
            Debug.Log("Not enough money for upgrade");
        }

    }
}
