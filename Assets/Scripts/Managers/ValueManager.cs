using UnityEngine;

public class ValueManager : MonoBehaviour
{
    public static ValueManager Instance { get; private set; }

    private float currentMoney;
    private int currentDiamonds;

    private float moneyMultiplier = 1;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    public void AddMoney(float amount)
    {
        currentMoney += amount;

        Vector3 randFloatingTextPos = new Vector3(Random.Range(-1, 2), Random.Range(0, 1));

        string valueString = "+ " + amount.ToString();

        FeedbackManager.Instance.SpawnFloatingTextFeedback(valueString, randFloatingTextPos);
        Debug.Log($"Current Money: {currentMoney}");
    }

    public void AddDiamonds(int amount)
    {
        currentDiamonds += amount;
    }

    public float MultiplyMoney(int amount)
    {
        return amount * moneyMultiplier;
    }

    public void PayForUpgrade(int cost)
    {
        currentMoney -= cost;
    }

    // Upgrades
    public void IncreaseMultiplier() // Overall Money upgrade
    {
        moneyMultiplier += 0.5f;
    }

    public float CurrentMoney => currentMoney;
    public int CurrentDiamonds => currentDiamonds;
    public float MoneyMultiplier => moneyMultiplier;
}
