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
        plantLevelText.text = "LVL: " + currentPlant.PlantLevel.ToString();
        moneyText.text = ValueManager.Instance.CurrentMoney.ToString();
        diamondsText.text = ValueManager.Instance.CurrentDiamonds.ToString();
    }
}
