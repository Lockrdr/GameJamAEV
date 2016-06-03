using UnityEngine;
using System.Collections;

public class OrbShoot : MonoBehaviour {

	public GameObject shoot;
	private Vector3 angle;

	// Use this for initialization
	void Start () {
		
	}	
	
	// Update is called once per frame
	void Update () {

	}

	void OnClick(){
		Instantiate (shoot, transform.position, Quaternion.identity);
	}
}
