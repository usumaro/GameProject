using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.position;
    }
}
