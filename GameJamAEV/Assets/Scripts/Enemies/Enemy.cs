using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


    public bool m_playerDetected = false;

    public GameObject projectile;

    public float m_enemyHP = 50f;

    [Tooltip("Time before attacking the player again")]
    public float m_attackingCooldown = 3f;

    protected float m_timeSinceLastAttack;


    public float shootDamage = 5f;
    public float shootSpeed = 3f;


    virtual public void receiveDamage(float damage)
    {
        if(GameManager.getInstance().m_playerState == GameStates.PlayerState.Dead)
        {
            m_enemyHP -= damage;

            if (m_enemyHP <= 0)
            {
                die();
            }
        }
        
    }

    virtual internal void die()
    {
		GameManager.getInstance ().m_enemyNumberControler--;
		Destroy(gameObject);
    }

    void Update()
    {
	
        if(m_playerDetected)
        {
            attackPlayer();
        }

        m_timeSinceLastAttack -= Time.deltaTime;
	}

    protected virtual void attackPlayer()
    {
       if (m_timeSinceLastAttack < 0)
        {
            //Debug.Log("Te ataco");
            GameObject shootInstance = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
            shootInstance.GetComponent<EnemyProjectile>().setDamage(shootDamage);
            shootInstance.GetComponent<EnemyProjectile>().setSpeed(shootSpeed);
            m_timeSinceLastAttack = m_attackingCooldown;
        }
    }

    virtual public void playerDetected()
    {
        m_playerDetected = true;
        //Debug.Log("Te veo");
    }

    virtual public void playerLost()
    {
        m_playerDetected = false;
        //Debug.Log("No te veo");

    }


}
