using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] spawnPoints;
	public GameObject[] enemies;
	int[] positionsOcupated;
	int spawnPosition, spawnEnemy, spawnedNumber;
	private int[] enemiesToSpawn, typeOfEnemiesToSpawn;
	int enemiesInThisWave, typeOfEnemiesInThisWave;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	public void spawnWave(int wave){

		enemiesToSpawn = new int[]
							{2,2,2,3,3,3,4,4,4, //Rondas 1 a 9
							 4,4,4,5,5,5,5,6,6,6}; //Rondas 10 a 19
		typeOfEnemiesToSpawn = new int[] 
								{1,1,1,1,1,1,1,1,1, //Rondas 1 a 9
								 2,2,2,2,2,2,2,2,2,2}; //Rondas 10 a 19

		Debug.Log (wave - 1);

		if (enemiesToSpawn.Length < wave) {
			enemiesInThisWave = enemiesToSpawn [enemiesToSpawn.Length-1];
		} else {
			enemiesInThisWave = enemiesToSpawn [wave - 1];
		}

		GameManager.getInstance().m_enemyNumberControler = enemiesInThisWave;

		if (typeOfEnemiesToSpawn.Length < wave) {
			typeOfEnemiesInThisWave = typeOfEnemiesToSpawn [typeOfEnemiesToSpawn.Length-1];
		} else {
			typeOfEnemiesInThisWave = typeOfEnemiesToSpawn [wave-1];
		}



		spawnedNumber = 0;
		positionsOcupated = new int[spawnPoints.Length];
		foreach(int i in positionsOcupated){
			positionsOcupated [i] = 0;
		}

		while(spawnedNumber < enemiesInThisWave){

			spawnEnemy = Random.Range (0, typeOfEnemiesInThisWave-1);

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
