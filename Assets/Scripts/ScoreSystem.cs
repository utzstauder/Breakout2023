using System;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private static ScoreSystem _instance;
    public static ScoreSystem Instance => _instance;


    private int _currentScore = 0;
    public int CurrentScore
    {
        get => _currentScore;
        private set
        {
            _currentScore = value;
            OnScoreChanged?.Invoke(CurrentScore);
        }
    }
    
    public static event Action<int> OnScoreChanged;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        Brick.OnBrickDestroyed += Brick_OnBrickDestroyed;
    }

    private void OnDisable()
    {
        Brick.OnBrickDestroyed -= Brick_OnBrickDestroyed;
    }

    private void Start()
    {
        CurrentScore = 0;
    }

    private void Brick_OnBrickDestroyed(Brick brickthatwashit)
    {
        CurrentScore++;
    }
}
