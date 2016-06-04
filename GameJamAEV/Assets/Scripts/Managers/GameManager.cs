﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static GameManager m_instance;

    public static GameManager getInstance()
    {
        return m_instance;
    }
    
    public int m_WaveNumber = 1;
	public int m_enemyNumberControler = 2;

    public float hpToBecomeAlive = 50f;

    public float HpForFullBody = 50f;
    public float HpForHalfBody = 25f;

	public AudioSource audioSource;


    //public enum PlayerState { Alive = 0, Dead = 1, Resurrected = 2 };
    public GameStates.PlayerState m_playerState;

    public void changePlayerState(GameStates.PlayerState state)
    {
        m_playerState = state;

        if (state == GameStates.PlayerState.Resurrected)
        {
            endGame();
        }
    }

    public void checkState(float playerHp)
    {
        if (playerHp <= hpToBecomeAlive)
           changePlayerState(GameStates.PlayerState.Dead);
        else if (playerHp >= 100)        
           changePlayerState(GameStates.PlayerState.Resurrected);
        else if(playerHp > GameManager.getInstance().hpToBecomeAlive)
           changePlayerState(GameStates.PlayerState.Alive);         
        
    }


	void Start () {
        Time.timeScale = 1;

		audioSource = gameObject.GetComponent<AudioSource> ();
        if (m_instance == null)
            m_instance = this;


	}

	void Update(){

		if (m_enemyNumberControler == 0) {
			Debug.Log ("Acabada");
			GetComponent<EnemySpawner>().spawnWave (m_WaveNumber++);
			audioSource.clip = SoundManager.getInstance ().startWave ();
			audioSource.Play ();
			GUIManager.getInstance ().updateWaveNumber (m_WaveNumber);
		}
	}

	void endGame()
    {
        Time.timeScale = 0;
        GUIManager.getInstance().getEndScreen().SetActive(true);
    }
}
