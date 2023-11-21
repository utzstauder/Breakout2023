using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    private const string SCORE_LABEL = "Score:";

    private void Awake()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        ScoreSystem.OnScoreChanged += OnScoreChanged;
    }

    private void Start()
    {
        SetScoreText(ScoreSystem.Instance.CurrentScore);
    }

    private void OnDisable()
    {
        ScoreSystem.OnScoreChanged -= OnScoreChanged;
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
