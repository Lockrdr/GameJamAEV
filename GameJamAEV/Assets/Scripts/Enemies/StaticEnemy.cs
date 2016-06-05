using UnityEngine;
using System.Collections;

public class StaticEnemy : Enemy {

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
}
