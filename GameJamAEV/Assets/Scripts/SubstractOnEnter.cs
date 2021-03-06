﻿using UnityEngine;
using System.Collections;

public class SubstractOnEnter : MonoBehaviour {

    public float amountOfLife = 4;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
			if (coll.GetComponent<PlayerCombat> ().m_playerHealth > 0) {
				coll.GetComponent<PlayerCombat> ().substractLife (amountOfLife);
				Destroy (gameObject);
			}
        }
    }

}
