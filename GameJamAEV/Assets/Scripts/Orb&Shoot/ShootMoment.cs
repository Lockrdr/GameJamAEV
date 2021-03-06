﻿using UnityEngine;
using System.Collections;

public class ShootMoment : MonoBehaviour {

	private Rigidbody2D rb;
	private Vector3 shootDirection;
    private float shootSpeed = 1f;
    private float shootDamage = 5f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		shootDirection = Input.mousePosition;
		shootDirection.z = 0.0f;
		shootDirection = Camera.main.ScreenToWorldPoint (shootDirection);
        shootDirection.z = 0.0f;
		shootDirection = Vector3.Normalize(shootDirection - transform.position);
        shootDirection.z = 0.0f;
        
        //Debug.Log(shootDirection);

		rb.AddForce (shootDirection*500*shootSpeed);
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("Enemy"))
        {
            coll.gameObject.GetComponent<Enemy>().receiveDamage(shootDamage);
            //Debug.Log("Enemigo");
        }
        else if (coll.gameObject.CompareTag("ShootWall"))
        {
            //Debug.Log("Pared");
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
