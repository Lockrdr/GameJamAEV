using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {

    private Rigidbody2D rb;
    private Vector3 shootDirection, v, pointDirection;
    private float shootSpeed = 1f;
    private float shootDamage = 5f;
	public int shootType = 0;
    private Transform playerTransform;
	public AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		audioSource = gameObject.GetComponent<AudioSource> ();
		audioSource.clip = SoundManager.getInstance ().enemyShoot();
		audioSource.Play ();
        //playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
		if(shootType == 0){
			shootDirection = Vector3.Normalize(GameObject.FindGameObjectWithTag("Player").transform.position - transform.position);
		}
		if (shootType == 1) {

			pointDirection = transform.position + Vector3.up*10;
			shootDirection = Vector3.Normalize(pointDirection - transform.position);
		}

		if (shootType == 2 ) {

			pointDirection = transform.position + Vector3.right*10;
			shootDirection = Vector3.Normalize(pointDirection - transform.position);
		}

		if (shootType == 3) {

			pointDirection = transform.position + Vector3.down*10;
			shootDirection = Vector3.Normalize(pointDirection - transform.position);
		}

		if (shootType == 4) {

			pointDirection = transform.position + Vector3.left*10;
			shootDirection = Vector3.Normalize(pointDirection - transform.position);
		}




        rb.AddForce(shootDirection * 1000 * shootSpeed);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            coll.gameObject.GetComponent<PlayerCombat>().addLife(shootDamage);
            Destroy(gameObject);


            //Debug.Log("Enemigo");
        }
        else if (coll.gameObject.CompareTag("Enemy"))
        {
            return;
        }
        else if (coll.gameObject.CompareTag("ShootWall"))
        {
            Destroy(gameObject);
        }
    }

    public void setDamage(float damage)
    {
        shootDamage = damage;
    }
    public void setSpeed(float speed)
    {
        shootSpeed = speed;
    }
	public void setAttackDirection(int type){
		
		shootType = type;
	}
}

