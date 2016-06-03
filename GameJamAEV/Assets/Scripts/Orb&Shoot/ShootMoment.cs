using UnityEngine;
using System.Collections;

public class ShootMoment : MonoBehaviour {

	private Rigidbody2D rb;
	private Vector3 shootDirection;
	public float shootSpeed = 1f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		shootDirection = Input.mousePosition;
		shootDirection.z = 0.0f;
		shootDirection = Camera.main.ScreenToWorldPoint (shootDirection);
		shootDirection = shootDirection - transform.position;
		rb.AddForce (shootDirection.normalized*1000*shootSpeed);
	}

}
