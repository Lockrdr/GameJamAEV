using UnityEngine;
using System.Collections;

public class TripleEnemy : Enemy {


	void Update()
	{
		if (m_playerDetected)
		{
			if (Time.time - spawnTime > startShootTime) {
				attackPlayer ();
			}
		}

		m_timeSinceLastAttack -= Time.deltaTime;
	}

	protected override void attackPlayer(){
		if (m_timeSinceLastAttack < 0){
			//Debug.Log("Te ataco");
			audioSource.clip = SoundManager.getInstance ().enemyShoot();
			audioSource.Play ();
			GameObject shootInstance1 = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
			shootInstance1.GetComponent<EnemyProjectile>().setDamage(shootDamage);
			shootInstance1.GetComponent<EnemyProjectile>().setSpeed(shootSpeed);
			shootInstance1.GetComponent<EnemyProjectile>().setAttackDirection(1);

			GameObject shootInstance2 = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
			shootInstance2.GetComponent<EnemyProjectile>().setDamage(shootDamage);
			shootInstance2.GetComponent<EnemyProjectile>().setSpeed(shootSpeed);
			shootInstance2.GetComponent<EnemyProjectile>().setAttackDirection(2);

			GameObject shootInstance3 = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
			shootInstance3.GetComponent<EnemyProjectile>().setDamage(shootDamage);
			shootInstance3.GetComponent<EnemyProjectile>().setSpeed(shootSpeed);
			shootInstance3.GetComponent<EnemyProjectile>().setAttackDirection(3);

			GameObject shootInstance4 = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
			shootInstance4.GetComponent<EnemyProjectile>().setDamage(shootDamage);
			shootInstance4.GetComponent<EnemyProjectile>().setSpeed(shootSpeed);
			shootInstance4.GetComponent<EnemyProjectile>().setAttackDirection(4);

	
			m_timeSinceLastAttack = m_attackingCooldown + Random.Range(0f,0.5f);
		}
	}
}
