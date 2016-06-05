using UnityEngine;
using System.Collections;

public class FollowingEnemy : Enemy {


    public float movingSpeed = 2f;

    private Vector3 mDir;
    public Vector3 newPostionTransform;
    private GameObject playerGO;

	void Start () {
        base.Start();
        playerGO = GameObject.FindGameObjectWithTag("Player").gameObject;
	}
 
	
	void Update () {

        newPostionTransform = playerGO.transform.position;
        mDir = newPostionTransform - transform.localPosition;
        mDir.Normalize();
        mDir.z = 0;
        transform.localPosition += movingSpeed * Time.deltaTime * mDir;


        //Debug.Log(Mathf.Abs(Vector3.Distance(transform.position, newPostionTransform)));
        //if (Mathf.Abs(Vector3.Distance(transform.localPosition, newPostionTransform)) < Mathf.Abs(0.1f))
        //{

        //    //Debug.Log("llege a destino");
        //    changeDirection();
        //    //StartCoroutine(nextTarget());
        //}
	}
}
