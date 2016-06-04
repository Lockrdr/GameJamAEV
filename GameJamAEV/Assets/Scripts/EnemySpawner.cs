using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] spawnPoints;
	public GameObject[] enemies;
	int[] positionsOcupated;
	int spawnPosition, spawnEnemy, spawnedNumber, enemiesToSpawn;

	// Use this for initialization
	void Start () {
		spawnWave (1);
	}
	
	// Update is called once per frame
	public void spawnWave(int wave){

		enemiesToSpawn = wave * 2;

		spawnedNumber = 0;
		positionsOcupated = new int[spawnPoints.Length];
		foreach(int i in positionsOcupated){
			positionsOcupated [i] = 0;
		}
		while(spawnedNumber < enemiesToSpawn){

			spawnEnemy = Random.Range (0, enemies.Length);

			if (spawnEnemy == 0) {
				spawnPosition = Random.Range (0, spawnPoints.Length);
				if (positionsOcupated [spawnPosition] != 1) {
					Instantiate (enemies [spawnEnemy], spawnPoints [spawnPosition].transform.position, Quaternion.identity);
					positionsOcupated [spawnPosition] = 1;
					spawnedNumber++;
				}
			} else if (spawnEnemy == 1) {
				spawnPosition = Random.Range (8, 11); 
				if (positionsOcupated [spawnPosition] != 1) {
					Instantiate (enemies [spawnEnemy], spawnPoints [spawnPosition].transform.position, Quaternion.identity);
					positionsOcupated [spawnPosition] = 1;
					spawnedNumber++;
				}
			}
		}
	}


}
