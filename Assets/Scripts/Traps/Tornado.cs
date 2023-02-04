using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Tornado : MonoBehaviour
{
    [SerializeField] private List<Transform> _patrolPoints;
    [SerializeField] private float _arrivalTreshold = 0.1f;

    private NavMeshAgent _agent;
    private int _patrolPointIndex;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        if (_patrolPoints.Count == 0)
            return;

        _patrolPointIndex = 0;
        _agent.SetDestination(_patrolPoints[_patrolPointIndex].position);
    }

    private void Update()
    {
        // check if there is need to patrol
        if (_patrolPoints.Count == 0)
            return;

        if (CheckIfArrived())
        {
            _patrolPointIndex++;
            if (_patrolPointIndex >= _patrolPoints.Count)
                _patrolPointIndex = 0;

            _agent.SetDestination(_patrolPoints[_patrolPointIndex].position);
        }
    }

    private bool CheckIfArrived()
    {
        if (!_agent.pathPending)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance + _arrivalTreshold)
            {
                return true;
            }
        }

        return false;
    }
}
