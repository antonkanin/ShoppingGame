using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform destination;

    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        Vector3 targetVector = destination.transform.position;
        navMeshAgent.SetDestination(targetVector);
    }
}