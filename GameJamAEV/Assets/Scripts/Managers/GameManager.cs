using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static GameManager m_instance;

    public static GameManager getInstance()
    {
        return m_instance;
    }
    
    
    private GameObject playerOrb;
    
    public int m_WaveNumber = 1;
	public int m_enemyNumberControler = 8;

    public float hpToBecomeAlive = 50f;

    public float HpForFullBody = 50f;
    public float HpForHalfBody = 25f;

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
            playerOrb.SetActive(false);

        }else if(state == GameStates.PlayerState.Dead){        
            playerOrb.SetActive(true);        
        }
    }

    public void checkState(float playerHp)
    {
       


        if (playerHp <= hpToBecomeAlive){

            changePlayerState(GameStates.PlayerState.Dead);
        }
        else if (playerHp >= 100){
            changePlayerState(GameStates.PlayerState.Resurrected);
        }
        else if (playerHp > GameManager.getInstance().hpToBecomeAlive)
        {
            changePlayerState(GameStates.PlayerState.Alive);
        }
        
    }
        

	void Start () {
        Time.timeScale = 1;

		audioSource = gameObject.GetComponent<AudioSource> ();
        if (m_instance == null)
            m_instance = this;

		GetComponent<EnemySpawner>().spawnWave (m_WaveNumber);

	}

	void Update(){

		if (m_enemyNumberControler == 0) {
			Debug.Log ("Acabada");
			m_WaveNumber++;
			GetComponent<EnemySpawner>().spawnWave (m_WaveNumber);
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
