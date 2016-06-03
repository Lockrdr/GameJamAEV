using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


    public bool m_playerDetected = false;

    public float m_enemyHP = 50f;
    

	void Start () {
	
	}
	
	
	void Update () {
	
        if(m_playerDetected)
        {
            attackPlayer();
        }
	}

    void attackPlayer()
    {
        //if(m_cooldownBetwe)
        //{

        //}
    }

    public void playerDetected()
    {
        m_playerDetected = true;
        Debug.Log("Te veo");
    }

    public void playerLost()
    {
        m_playerDetected = false;
        Debug.Log("No te veo");

    }


}
