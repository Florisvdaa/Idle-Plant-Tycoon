using MoreMountains.Feedbacks;
using UnityEngine;

public class FeedbackManager : MonoBehaviour
{
    public static FeedbackManager Instance { get; private set; }

    [SerializeField] private MMF_Player floatingTextFeedback;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    //public MMF_Player GetFloatingTextFeedback() => floatingTextFeedback; 

    public void SpawnFloatingTextFeedback(string value, Vector3 pos)
    {
        MMF_FloatingText floatingText = floatingTextFeedback.GetFeedbackOfType<MMF_FloatingText>();

        floatingText.Value = value;

        floatingTextFeedback.PlayFeedbacks(pos);
    }
}
