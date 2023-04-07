using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    public Transform destination;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        //target = Waypoints.waypoints[0];
    }
    
    void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(destination.position);
        
        // Vector3 dir = target.position - transform.position;
        // transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        //
        // if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        // {
        //     GetNextWaypoint();
        // }
        //
        // enemy.speed = enemy.startSpeed;
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.waypoints.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.waypoints[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
