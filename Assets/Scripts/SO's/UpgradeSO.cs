using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeSO", menuName = "Scriptable Objects/UpgradeSO")]
public class UpgradeSO : ScriptableObject
{
    public Upgrade upgradeType;
    public string upgradeName;
    public float baseCost;
    public float costMultiplier = 1.5f; // Cost increases by 50% each time
    public float upgradeMultiplier;

    [HideInInspector] public int currentLevel = 0;

    public float CurrentCost => baseCost * Mathf.Pow(costMultiplier, currentLevel);

    public void ApplyUpgrade()
    {
        currentLevel++;
    }

}
public enum Upgrade { IdleMoney, ClickMoney, WaterQuality }
