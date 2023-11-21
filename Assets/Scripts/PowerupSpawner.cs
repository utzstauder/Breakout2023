using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerupSpawner : MonoBehaviour
{
    Brick brick;

    [Range(0, 1f)]
    public float spawnChance = 0.5f;
    
    public Powerup[] powerupPrefabs;

    private void Awake()
    {
        brick = GetComponent<Brick>();
        Brick.OnBrickHit += Brick_OnBrickHit;
    }

    private void Brick_OnBrickHit(Brick brickThatWasHit)
    {
        if (brickThatWasHit != brick) return;
        
        bool willSpawnPowerup = Random.Range(0, 1f) <= spawnChance;
        if (willSpawnPowerup) SpawnPowerup();
    }

    void SpawnPowerup()
    {
        //print("Powerup spawned.");
        int randomIndex = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[randomIndex], transform.position, Quaternion.identity);
    }
}
