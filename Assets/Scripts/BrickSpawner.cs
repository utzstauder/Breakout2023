using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrickSpawner : MonoBehaviour
{
    public Brick brickPrefab;

    public Vector2Int amount;
    public Vector2 padding;

    private List<Brick> bricks;

    
    private void Start()
    {
        SpawnBricks();
    }

    private void OnEnable()
    {
        Brick.OnBrickHit += Brick_OnBrickHit;
    }

    private void OnDisable()
    {
        Brick.OnBrickHit -= Brick_OnBrickHit;
    }

    void SpawnBricks()
    {
        bricks = new List<Brick>();

        for (int y = 0; y < amount.y; y++)
        {
            for (int x = 0; x < amount.x; x++)
            {
                Brick newBrick = Instantiate(brickPrefab);

                newBrick.transform.position = transform.position
                    + (Vector3.right * x * newBrick.transform.localScale.x)
                    + (Vector3.right * x * padding.x)
                    + (Vector3.up * y * newBrick.transform.localScale.y)
                    + (Vector3.up * y * padding.y);

                bricks.Add(newBrick);
            }
        }
    }

    private void Brick_OnBrickHit(Brick brick)
    {
        print($"Brick {brick.gameObject.name} was hit.");

        if (AreAnyBricksActive() == false)
        {
            LoadNextScene();
        }
    }

    bool AreAnyBricksActive()
    {
        foreach (Brick brick in bricks)
        {
            if (brick.gameObject.activeSelf) return true;
        }

        return false;
    }

    // TODO: move this somewhere else?
    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int targetSceneIndex = currentSceneIndex + 1;

        // [insert reason why we wrap back to scene 0]
        if (targetSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            targetSceneIndex = 0;
        }

        SceneManager.LoadScene(targetSceneIndex);
    }
}
