using UnityEngine;
using System.Collections;

public class OrbShoot : MonoBehaviour {

	public GameObject shoot;
	private Vector3 angle;
    public float shootDamage = 5f;
    public float shootSpeed = 3f;

    [Tooltip("Time before attacking the player again")]
    public float m_attackingCooldown = 3f;

    protected float m_timeSinceLastAttack;

   
	// Update is called once per frame
	void Update () {
		//Button "Fire": ProjectSettings -> Input
		if (Input.GetButtonDown ("Fire")&& m_timeSinceLastAttack < 0) {
            m_timeSinceLastAttack = m_attackingCooldown;

			GameObject shootInstance = (GameObject) Instantiate (shoot, transform.position, Quaternion.identity);
            shootInstance.GetComponent<ShootMoment>().setDamage(shootDamage);
            shootInstance.GetComponent<ShootMoment>().setSpeed(shootSpeed);
        }
        m_timeSinceLastAttack -= Time.deltaTime;

	}


}
