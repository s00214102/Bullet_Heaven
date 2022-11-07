using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class NavMeshMover : MonoBehaviour
{
    protected NavMeshAgent agent;
    bool isMoving;
    UnityEvent OnReachedDestination;

    public virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
       if(isMoving)
        {
            if(HasReachedDestination())
            {
                OnReachedDestination?.Invoke();
                isMoving = false;
            }
        }
    }

    public void MoveTo(Vector3 position)
    {
        isMoving = true;
        agent.SetDestination(position);
    }

    public void MoveTo(GameObject target)
    {
        if(target!=null)
        MoveTo(target.transform.position);
    }

    public bool HasReachedDestination()
    {
        float distance = Vector3.Distance(transform.position, agent.destination);
        return distance <= agent.stoppingDistance;
    }
}
