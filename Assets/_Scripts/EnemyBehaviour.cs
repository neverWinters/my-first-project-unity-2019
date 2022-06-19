using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField]
    private Transform patrolRoute;
    private List<Transform> waypoints = new List<Transform>();
    private int locationIndex = 0;
    private NavMeshAgent _agent;
    [SerializeField]
    private Transform player;
    private int _enemyHP = 100;
    public int EnemyHP
    {
        get { return _enemyHP; }
        private set
        {
            _enemyHP = value;
            if(_enemyHP <= 0) { Destroy(this.gameObject); }
        }
    }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        InitializeWaypoints();
        MoveToNextWaypoint();
    }

    private void Update()
    {
        if(_agent.remainingDistance < 0.5f && !_agent.pathPending)
        {
            MoveToNextWaypoint();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        if(other.gameObject.name == "Player")
        {

            Debug.Log("Jugador detectado");
            _agent.SetDestination(player.position);

        }

    }

    private void OnTriggerExit(Collider other)
    {
        
        if(other.gameObject.name == "Player")
        {

            Debug.Log("Jugador fuera de rango");

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            EnemyHP = EnemyHP - 15;
        }
    }

    private void InitializeWaypoints()
    {
        foreach (Transform wp in patrolRoute)
        {
            waypoints.Add(wp);
        }
    }

    private void MoveToNextWaypoint()
    {
        if (waypoints.Count == 0) return;
        _agent.SetDestination(waypoints[locationIndex].position);
        //Se indica el siguiente waypoint teniendo en cuenta la cantidad de waypoints existente
        //locationIndex = (locationIndex + 1)%waypoints.Count;
        //Se indica el siguiente waypoint de manera aleatoria dentreo de un rango de numeros
        locationIndex = Random.Range(0, waypoints.Count);
    }

}
