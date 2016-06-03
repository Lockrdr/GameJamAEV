using UnityEngine;
using System.Collections;

public class OrbShoot : MonoBehaviour {

	public GameObject shoot;
	private Vector3 angle;
    public float shootDamage = 5f;
    public float shootSpeed = 3f;

	// Use this for initialization
	void Start () {
		
	}	
	
	// Update is called once per frame
	void Update () {
		//Button "Fire": ProjectSettings -> Input
		if (Input.GetButtonDown ("Fire")) {
			GameObject shootInstance = (GameObject) Instantiate (shoot, transform.position, Quaternion.identity);
            shootInstance.GetComponent<ShootMoment>().setDamage(shootDamage);
            shootInstance.GetComponent<ShootMoment>().setSpeed(shootSpeed);
        }
	}


}
