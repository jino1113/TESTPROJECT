using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Transform EnemyPos;

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float visionRange = 10f;
    [SerializeField] private Vector3 homePosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        homePosition = EnemyPos.transform.position;
    }

   
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= visionRange && !PlayerStatus.IsSafe)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            agent.SetDestination(homePosition);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }
}
