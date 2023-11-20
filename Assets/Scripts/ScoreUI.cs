using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    private const string SCORE_LABEL = "Score:";
    
    public BrickSpawner brickSpawner;

    private void Awake()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        
        brickSpawner.OnScoreChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int newScore)
    {
        SetScoreText(newScore);
    }

    void SetScoreText(int score)
    {
        textComponent.text = SCORE_LABEL + " " + score;
    }
}
