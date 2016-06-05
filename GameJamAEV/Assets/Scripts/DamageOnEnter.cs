using UnityEngine;
using System.Collections;

public class DamageOnEnter : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            coll.gameObject.GetComponent<PlayerCombat>().addLife(25f);
        }
    }
}
