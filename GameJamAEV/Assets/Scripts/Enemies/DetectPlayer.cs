using UnityEngine;
using System.Collections;

public class DetectPlayer : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponentInParent<Enemy>().playerDetected();

        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponentInParent<Enemy>().playerLost();

        }
    }


   
}
