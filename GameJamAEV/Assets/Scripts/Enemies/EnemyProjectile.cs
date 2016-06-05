using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {

    private Rigidbody2D rb;
    private Vector3 shootDirection;
    private float shootSpeed = 1f;
    private float shootDamage = 5f;
    private Transform playerTransform;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        shootDirection = playerTransform.position;
        shootDirection = Vector3.Normalize(shootDirection - transform.position);

        rb.AddForce(shootDirection * 1000 * shootSpeed);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            coll.gameObject.GetComponent<PlayerCombat>().addLife(shootDamage);
            //Debug.Log("Enemigo");
        }
        else if (coll.gameObject.CompareTag("Enemy"))
        {
            return;
        }


        Destroy(gameObject);

    }

    public void setDamage(float damage)
    {
        shootDamage = damage;
    }
    public void setSpeed(float speed)
    {
        shootSpeed = speed;
    }
}
