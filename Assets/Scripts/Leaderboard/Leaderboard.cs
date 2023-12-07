using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    private const string LeaderboardDataPlayerPrefsKey = "LeaderboardData";
    public LeaderboardData leaderboardData;

    private void Awake()
    {
        // load leaderboard
        string json = PlayerPrefs.GetString(LeaderboardDataPlayerPrefsKey, null);

        if (string.IsNullOrEmpty(json))
        {
            leaderboardData = new LeaderboardData();
        }
        else
        {
            leaderboardData = LeaderboardData.FromJson(json);
        }
    }

    private void OnApplicationQuit()
    {
        // store leaderboard
        string json = leaderboardData.ToJson();
        PlayerPrefs.SetString(LeaderboardDataPlayerPrefsKey, json);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            leaderboardData.LeaderboardDataEntries.Add(new LeaderboardData.LeaderboardDataEntry("Utz", 0));
            leaderboardData.LeaderboardDataEntries.Add(new LeaderboardData.LeaderboardDataEntry("Alan", 100));
        }
    }
}
