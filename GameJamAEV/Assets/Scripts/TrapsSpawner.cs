using UnityEngine;
using System.Collections;

public class TrapsSpawner : MonoBehaviour {

	public GameObject[] traps;
	private int trapType;

	// Use this for initialization
	void Start () {

	}
	
	public void spawnTramp(){
		trapType = Random.Range (0,traps.Length);

		if (trapType == 0) {
			Instantiate (traps[0], new Vector3(Random.Range(-8f,8f),4f,0f), Quaternion.identity);
		}else if(trapType == 1){
			Instantiate (traps[1], new Vector3(8f,Random.Range(-4f,3.5f),0f), Quaternion.Euler(new Vector3(0,0,-90)));
		}else if(trapType == 2){
			Instantiate (traps[2], new Vector3(Random.Range(-8f,8f),-4.3f,0f), Quaternion.Euler(new Vector3(0,0,180)));
		}else if(trapType == 3){
			Instantiate (traps[3], new Vector3(-8f,Random.Range(-4f,3.5f),0f), Quaternion.Euler(new Vector3(0,0,90)));
		}else if(trapType == 4){
			Instantiate (traps[4], new Vector3(Random.Range(-7f,7f),Random.Range(-3f,3f),0f), Quaternion.identity);
		}
	}
}
