using UnityEngine;

public class ValueManager : MonoBehaviour
{
    public static ValueManager Instance { get; private set; }

    private int currentMoney;
    private int currentDiamonds;

    private int moneyMultiplier = 1;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    public void AddMoney(int amount)
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

    public int MultiplyMoney(int amount)
    {
        return amount * moneyMultiplier;
    }

    public int CurrentMoney => currentMoney;
    public int CurrentDiamonds => currentDiamonds;
    public int MoneyMultiplier => moneyMultiplier;
}
