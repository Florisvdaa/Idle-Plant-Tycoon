using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private Plant currentPlant;

    [SerializeField] private TextMeshProUGUI plantLevelText;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI diamondsText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    private void Update()
    {
        plantLevelText.text = "Plant Lvl: " + currentPlant.PlantLevel.ToString();
        moneyText.text = "Coins: " + ValueManager.Instance.CurrentMoney.ToString();
        diamondsText.text = "Diamonds: " + ValueManager.Instance.CurrentDiamonds.ToString();
    }
}
