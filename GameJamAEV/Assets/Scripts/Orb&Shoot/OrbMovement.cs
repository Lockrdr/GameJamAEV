using UnityEngine;
using System.Collections;

public class OrbMovement : MonoBehaviour {

	public float rotationSpeed = 1.75f;
	public float rotationRadius = 1.5f;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		if(player == null){
			Debug.Log ("Jugador no encontrado");
		}
		transform.position = player.transform.position + Vector3.right*rotationRadius;
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.RotateAround(player.transform.position, transform.forward, rotationSpeed);
		transform.rotation = Quaternion.identity;

	}
}
