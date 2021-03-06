﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private static GameManager m_instance;

    public static GameManager getInstance()
    {
        return m_instance;
    }
    
    
    private GameObject playerOrb;
    
    public int m_WaveNumber = 0;
    public float timeBetweenWaves = 3f;
	
    public int m_enemyNumberControler = 0;
    private bool watingNextWave = false;


    public float hpToBecomeAlive = 50f;

    public float HpForFullBody = 100f;
    public float HpForThreeQuarterBody = 75f;
    public float HpForHalfBody = 50f;
    public float HpForQuarterBody = 25f;

    public float hpEndGame = 125f;

	public float timeToSpawn = 30f;
	public float lastSpawnTime;

    private bool isFirstWave = true;

    public Texture2D newCursor;
    private GameObject WallFloors;

	public GameObject floor;
	public Sprite newFloor;

	public AudioSource audioSource;


    //public enum PlayerState { Alive = 0, Dead = 1, Resurrected = 2 };
    public GameStates.PlayerState m_playerState;

    public void changePlayerState(GameStates.PlayerState state)
    {
        m_playerState = state;

        if (playerOrb == null)
        {
            playerOrb = GameObject.FindGameObjectWithTag("Player").transform.Find("Orb").gameObject;

        }

        if (state == GameStates.PlayerState.Resurrected)
        {
            endGame();

        }else if(state == GameStates.PlayerState.Alive)
        {
            //playerOrb.SetActive(false);

        }else if(state == GameStates.PlayerState.Dead){        
            //playerOrb.SetActive(true);        
        }
    }

    public void checkState(float playerHp)
    {
       
        if (playerHp <= hpToBecomeAlive){

            changePlayerState(GameStates.PlayerState.Dead);
        }
        else if (playerHp > hpEndGame)
        {
            changePlayerState(GameStates.PlayerState.Resurrected);
        }
        else if (playerHp > GameManager.getInstance().hpToBecomeAlive)
        {
            changePlayerState(GameStates.PlayerState.Alive);
        }
        
    }
        

	void Start () {

		Cursor.SetCursor (newCursor, new Vector2(64f,64f), CursorMode.Auto);
        WallFloors = GameObject.Find("Walls&Floor").gameObject;

        Time.timeScale = 1;

		audioSource = gameObject.GetComponent<AudioSource> ();
        if (m_instance == null)
            m_instance = this;

 

		lastSpawnTime = Time.time;

	}



	void Update(){

		if ((m_enemyNumberControler == 0 || Time.time - lastSpawnTime >= 30 ) && !watingNextWave)
        {
            if(isFirstWave)
            {
                GUIManager.getInstance().activeGetReadyText();
                isFirstWave = false;

            }else
            {
                GUIManager.getInstance().activeNexWaveText();

            }
            watingNextWave = true;
			lastSpawnTime = Time.time + timeBetweenWaves;
            StartCoroutine(delayNextWave(timeBetweenWaves));
		}
	}

    IEnumerator delayFirstWave(float inXSeconds)
    {
        yield return new WaitForSeconds(inXSeconds);
        GetComponent<EnemySpawner>().spawnWave(m_WaveNumber);
    }

    IEnumerator delayNextWave(float inXSeconds)
    {
		m_WaveNumber++;
		if (m_WaveNumber == 10) {
			floor.GetComponent<SpriteRenderer> ().sprite = newFloor;
		}   
		yield return new WaitForSeconds(inXSeconds);
        
		if (m_WaveNumber % 2 == 0) {
			GetComponent<TrapsSpawner>().spawnTramp();
		}
        GetComponent<EnemySpawner>().spawnWave(m_WaveNumber);
        audioSource.clip = SoundManager.getInstance().startWave();
        audioSource.Play();
        GUIManager.getInstance().updateWaveNumber(m_WaveNumber);
        watingNextWave = false;
        GUIManager.getInstance().deactiveNexWaveText();
        GUIManager.getInstance().deactiveGetReadyText();


    }

	void endGame()
    {
        WallFloors.GetComponent<CameraShakeEffects>().CancelShake();
        Time.timeScale = 0;

        GUIManager.getInstance().getEndScreen().SetActive(true);
    }


}
