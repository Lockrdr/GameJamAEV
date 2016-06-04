using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] spawnPoints;
	public GameObject[] enemies;
	public GameObject indicatorImage;
	public float waitEnemies = 1.0f;

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
							 4,4,4,5,5,5,5,5,6,6, //Rondas 10 a 19
							 6,6,6,6,7,7,7,7,7,7, //Rondas 20 a 29
							 7,8}; //Rondas 30 a infinito
		typeOfEnemiesToSpawn = new int[] 
								{1,1,1,1,2}; //Rondas 1 a infinito

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

			spawnEnemy = Random.Range (0, typeOfEnemiesInThisWave);
 
			if (spawnEnemy == 0) {
				spawnPosition = Random.Range (0, spawnPoints.Length);
				if (positionsOcupated [spawnPosition] != 1) {
					GameObject indicatorAux = (GameObject)Instantiate (indicatorImage, spawnPoints [spawnPosition].transform.position, Quaternion.identity);
					StartCoroutine(delayEnemySpawn(waitEnemies, indicatorAux, enemies [spawnEnemy],spawnPoints [spawnPosition].transform.position));
					positionsOcupated [spawnPosition] = 1;
					spawnedNumber++;
				}
			} else if (spawnEnemy == 1) {
				spawnPosition = Random.Range (8, 11); 
				if (positionsOcupated [spawnPosition] != 1) {
					GameObject indicatorAux = (GameObject)Instantiate (indicatorImage, spawnPoints [spawnPosition].transform.position, Quaternion.identity);
					StartCoroutine(delayEnemySpawn(waitEnemies, indicatorAux, enemies [spawnEnemy],spawnPoints [spawnPosition].transform.position));
					positionsOcupated [spawnPosition] = 1;
					spawnedNumber++;
				}
			}
		}
	}

	IEnumerator delayEnemySpawn(float inXSeconds, GameObject indicator, GameObject enemy, Vector3 position){
		yield return new WaitForSeconds(inXSeconds);
		Destroy (indicator);
		Instantiate (enemy, position, Quaternion.identity);
	}


}
