using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshFollow : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
       // destination = GameObject.FindWithTag("Player").transform;
        target = PlayerManager.instance.player.transform;
        
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }
}

