using UnityEngine;
using System.Collections;

public class PatrollingEnemy : Enemy {

    [Header("Patrolling variables")]
    public Transform waypoint1;
    public Transform waypoint2;

    public float patrolSpeed = 2f;

    private Vector3 mDir;
    public Vector3 newPostionTransform;

	void Start () {
		base.Start ();
        GetComponent<SpriteRenderer>().flipX = true;
        newPostionTransform = waypoint2.localPosition;	
	}


    void Update()
    {
        if (m_playerDetected)
        {
            attackPlayer();
        }
        m_timeSinceLastAttack -= Time.deltaTime;

        mDir = newPostionTransform - transform.localPosition;
        mDir.Normalize();
        mDir.z = 0;
        transform.localPosition += patrolSpeed * Time.deltaTime * mDir;

        //Debug.Log(Mathf.Abs(Vector3.Distance(transform.position, newPostionTransform)));
        if (Mathf.Abs(Vector3.Distance(transform.localPosition, newPostionTransform)) < Mathf.Abs(0.1f))
        {

            //Debug.Log("llege a destino");
            changeDirection();
            //StartCoroutine(nextTarget());
        }
    }

    void changeDirection()
    {
        if (newPostionTransform == waypoint2.localPosition)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            newPostionTransform = waypoint1.localPosition;

        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
            newPostionTransform = waypoint2.localPosition;

        }
    }
}
