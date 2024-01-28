using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SadZombieController : MonoBehaviour
{
    private NavMeshAgent agent = null;
   [SerializeField] private Transform target;
    public float speed;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
        RotateToTarget();

    }

    private void RotateToTarget()
    {
        transform.LookAt(target);

        //Option 2 (doesn't let player get behind)
        //Vector3 direction = target.position - transform.position;
        //Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        //transform.rotation = rotation;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "NoneShallPass")
        {
            GetComponent<NavMeshAgent>().isStopped = true;
        }
        else
        {
            GetComponent<NavMeshAgent>().isStopped = false;
        }
        }
    }
