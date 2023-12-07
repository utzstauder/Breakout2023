using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavPlayerController : MonoBehaviour
{
    private Camera camera;

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldSpaceClick = camera.ScreenToWorldPoint(Input.mousePosition);

            
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                print(hit.point);

                navMeshAgent.SetDestination(hit.point);
            }
        }
    }
}
