using UnityEngine;
using System.Collections;

public class AddLifeOnEnter : MonoBehaviour {

    public float amountOfLife = 4;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            coll.GetComponent<PlayerCombat>().addLife(amountOfLife);
        }
    }

}
