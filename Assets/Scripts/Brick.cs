using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour
{
    private static int activeBricks = 0;

    private void Awake()
    {
        activeBricks++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        activeBricks--;

        if (activeBricks == 0)
        {
            print("All bricks destroyed!");
            LoadNextScene();
        }

        Destroy(gameObject);
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
