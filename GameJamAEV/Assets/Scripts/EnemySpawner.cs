using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] spawnPoints;
	public GameObject[] enemies;
	int[] positions;
	int spawnPosition, spawnEnemy;

	// Use this for initialization
	void Start () {
		spawnWave (0);
	}
	
	// Update is called once per frame
	public void spawnWave(int wave){

		positions = new int[spawnPoints.Length];
		spawnPosition = Random.Range (0,spawnPoints.Length-1);
		spawnEnemy = Random.Range (0, enemies.Length - 1);
		Instantiate (enemies [spawnEnemy], spawnPoints [spawnPosition].transform.position, Quaternion.identity);
	}


}
