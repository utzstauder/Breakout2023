using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleSystemController : MonoBehaviour
{
    private static ParticleSystemController _instance;
    public static ParticleSystemController Instance => _instance;

    private ParticleSystem _particleSystem;
    
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        Brick.OnBrickHit += Brick_OnBrickHit;
    }

    private void OnDisable()
    {
        Brick.OnBrickHit -= Brick_OnBrickHit;
    }

    private void Brick_OnBrickHit(Brick brickthatwashit)
    {
        transform.position = brickthatwashit.transform.position;
        _particleSystem.Emit(100);
    }
}
