using UnityEngine;
using System.Collections;

public class PatrollingEnemy : Enemy {

    [Header("Patrolling variables")]
    public Transform waypoint1;
    public Transform waypoint2;
    private Vector3 mDir;
    public Transform currentWaypoint;

	void Start () {
        currentWaypoint = waypoint2;	
	}


    void Update()
    {
        if (m_playerDetected)
        {
            attackPlayer();
        }
        m_timeSinceLastAttack -= Time.deltaTime;
        
        //mDir = newPostionTransform - transform.position;
        //mDir.Normalize();
        //mDir.x = 0;
        //transform.position += m_elevatorSpeed * Time.deltaTime * mDir;

        ////Debug.Log(Mathf.Abs(Vector3.Distance(transform.position, newPostionTransform)));
        //if (elevatorMoving && Mathf.Abs(Vector3.Distance(transform.position, newPostionTransform)) < Mathf.Abs(0.01f))
        //{

        //    Debug.Log("llege a destino");

        //    elevatorMoving = false;
        //    StartCoroutine(nextTarget());
        //}
    }
}
