using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


    public bool m_playerDetected = false;

    public float m_enemyHP = 50f;

    [Tooltip("Time before attacking the player again")]
    public float m_attackingCooldown = 3f;

    private float m_timeSinceLastAttack;

	void Start () {
	
	}
	
	
	void Update () {
	
        if(m_playerDetected)
        {
            attackPlayer();
        }

        m_timeSinceLastAttack -= Time.deltaTime;
	}

    void attackPlayer()
    {
       if (m_timeSinceLastAttack < 0)
        {
            Debug.Log("Te ataco");
            m_timeSinceLastAttack = m_attackingCooldown;
        }
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
