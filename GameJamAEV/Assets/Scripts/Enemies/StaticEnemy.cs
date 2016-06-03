using UnityEngine;
using System.Collections;

public class StaticEnemy : Enemy {

    void Update()
    {
        if (m_playerDetected)
        {
            attackPlayer();
        }

        m_timeSinceLastAttack -= Time.deltaTime;
    }
}
