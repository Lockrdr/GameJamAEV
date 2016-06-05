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

        updateAnimation(mDir);

        //Debug.Log(mDir);

        transform.localPosition += movingSpeed * Time.deltaTime * mDir;

    }

    void updateAnimation(Vector2 mDir)
    {
        if (mDir.x == 1 && mDir.y == 0)
        {
            GetComponent<Animator>().Play("Right");
        }
        else if (mDir.x == 0 && mDir.y == -1)
        {
            GetComponent<Animator>().Play("Down");
        }
        else if (mDir.x == -1 && mDir.y == 0)
        {
            GetComponent<Animator>().Play("Left");
        }
        else if (mDir.x == 0 && mDir.y == 1)
        {
            GetComponent<Animator>().Play("Up");

        }else if ((mDir.x > 0.5f && mDir.x < 0 && mDir.y >= 0.5f && mDir.y < 1) || (mDir.x > -0.5f && mDir.x < 0 && mDir.y > 0.5f && mDir.y < 1))
        {
            GetComponent<Animator>().Play("Up");
        }
        else if ((mDir.x < -0.5f && mDir.x > -1 && mDir.y >= 0 && mDir.y < 0.5f) || (mDir.x <= -0.5f && mDir.x > 1 && mDir.y >= -0.5f && mDir.y < 0))
        {
            //Left 
            GetComponent<Animator>().Play("Left");
        }
        else if ((mDir.x > -0.5f && mDir.x < 0 && mDir.y > -1 && mDir.y < -0.5f) || (mDir.x > 0f && mDir.x < 0.5f && mDir.y > -1f && mDir.y < -0.5f))
        {
            GetComponent<Animator>().Play("Down");
        }
        else
        {
            //Right
            GetComponent<Animator>().Play("Right");
        }

    }

}
