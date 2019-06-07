using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBehaviour : MonoBehaviour
{
    public NavMeshAgent AgentRef;
    public GameObject[] WayPoints;
    public Transform CurrentDestination;

    public GameObject PlayerRef;

    public float TrackingDistance;

    bool PlayerInSight
    {
        get
        {
            RaycastHit rayhit;
            if (Physics.Raycast(transform.position, PlayerRef.transform.position - transform.position, out rayhit, Mathf.Infinity))
            {
                return true;
            }
            return false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        AgentRef = GetComponent<NavMeshAgent>();
        WayPoints = GameObject.FindGameObjectsWithTag("Waypoint");
        CurrentDestination = WayPoints[Random.Range(0, WayPoints.Length - 1)].transform;
        AgentRef.SetDestination(CurrentDestination.position);
        PlayerRef = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, CurrentDestination.position) < 0.1f)
        {
            CurrentDestination = WayPoints[Random.Range(0, WayPoints.Length - 1)].transform;
            AgentRef.SetDestination(CurrentDestination.position);
        }

        if(PlayerInSight)
        {
            if(Vector3.Distance(transform.position, PlayerRef.transform.position) >= TrackingDistance)
            {
                AgentRef.SetDestination(PlayerRef.transform.position);
            }
        }
    }
}
