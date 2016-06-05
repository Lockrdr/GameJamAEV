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

	public AudioSource audioSource;



	virtual public void Start(){
		audioSource = gameObject.GetComponent<AudioSource> ();
	}

    virtual public void receiveDamage(float damage)
    {

        m_enemyHP -= damage;

        if (m_enemyHP <= 0)
        {
			die();
        }

		//CAmbiar color y suena
		Color normalColor = transform.GetComponent<SpriteRenderer>().color;
		Color tempColor = normalColor;
		tempColor.b *= 0.7f;
		tempColor.g *= 0.7f;
		transform.GetComponent<SpriteRenderer> ().color = tempColor;
		StartCoroutine (colorController(normalColor));

		audioSource.clip = SoundManager.getInstance ().damageToEnemy ();
		audioSource.Play();
		//-------------
 
    }

    virtual internal void die()
    {
		audioSource.clip = SoundManager.getInstance ().enemyDeath ();
		audioSource.Play ();
		GameManager.getInstance ().m_enemyNumberControler--;
		StartCoroutine (delayEnemyDeath());
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
			m_timeSinceLastAttack = m_attackingCooldown + Random.Range(0f,0.5f);
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

	IEnumerator colorController(Color oldColor){
		yield return new WaitForSeconds (0.5f);
		transform.GetComponent<SpriteRenderer> ().color = oldColor;
	}

	IEnumerator delayEnemyDeath(){
		yield return new WaitForSeconds(0.35f);
		Destroy(gameObject);
	}

}
