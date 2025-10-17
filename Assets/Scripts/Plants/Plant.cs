using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    [Header("Visuals")]
    [SerializeField] private Sprite[] growthStages;

    [Header("Interaction")]
    [SerializeField] private Button plantButton;

    [Header("Economy")]
    [SerializeField] private int basePassiveMoneyValue = 1;
    [SerializeField] private int baseClickMoneyValue = 1;
    [SerializeField] private float passiveIncomeInterval = 2f;

    private float passiveTimer;
    private int plantLevel = 0;

    private void Start()
    {
        if (plantButton != null)
            plantButton.onClick.AddListener(OnPlantClicked);

        ResetPassiveTimer();
        UpdateVisualState();
    }

    private void Update()
    {
        passiveTimer -= Time.deltaTime;
        if (passiveTimer <= 0f)
        {
            GeneratePassiveIncome();
            ResetPassiveTimer();
        }
    }

    private void OnPlantClicked()
    {
        float earnedMoney = ValueManager.Instance.MultiplyMoney(baseClickMoneyValue);
        ValueManager.Instance.AddMoney(earnedMoney);

        // Optional: Level up plant or trigger animation
        // plantLevel = Mathf.Min(plantLevel + 1, growthStages.Length - 1);
        // UpdateVisualState();

        ResetPassiveTimer();
    }

    private void GeneratePassiveIncome()
    {
        float earnedMoney = ValueManager.Instance.MultiplyMoney(basePassiveMoneyValue + 1);
        ValueManager.Instance.AddMoney(earnedMoney);
    }

    private void ResetPassiveTimer()
    {
        passiveTimer = passiveIncomeInterval;
    }

    private void UpdateVisualState()
    {
        if (plantButton != null && growthStages.Length > 0)
        {
            plantButton.image.sprite = growthStages[Mathf.Clamp(plantLevel, 0, growthStages.Length - 1)];
        }
    }

    public void UpgradePassiveIncome()
    {
        basePassiveMoneyValue += 1;
    }

    public void UpgradeClickIncome()
    {
        baseClickMoneyValue += 1;
    }

    // References
    public int PlantLevel => plantLevel;

}