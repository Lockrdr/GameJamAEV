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
    public float timeBetweenWaves = 3f;
	
    public int m_enemyNumberControler = 8;
    private bool watingNextWave = false;

    public float hpToBecomeAlive = 50f;

    public float HpForFullBody = 100f;
    public float HpForThreeQuarterBody = 75f;
    public float HpForHalfBody = 50f;
    public float HpForQuarterBody = 25f;
    
    public Texture2D newCursor;



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
        else if (playerHp > 105){
            changePlayerState(GameStates.PlayerState.Resurrected);
        }
        else if (playerHp > GameManager.getInstance().hpToBecomeAlive)
        {
            changePlayerState(GameStates.PlayerState.Alive);
        }
        
    }
        

	void Start () {

		Cursor.SetCursor (newCursor, new Vector2(64f,64f), CursorMode.Auto);

        Time.timeScale = 1;

		audioSource = gameObject.GetComponent<AudioSource> ();
        if (m_instance == null)
            m_instance = this;

        StartCoroutine(delayFirstWave(timeBetweenWaves));

	}



	void Update(){

        if (m_enemyNumberControler == 0 && !watingNextWave)
        {
            Debug.Log("Acabada");
            watingNextWave = true;
            GUIManager.getInstance().activeNexWaveText();
            StartCoroutine(delayNextWave(timeBetweenWaves));
		}
	}

    IEnumerator delayFirstWave(float inXSeconds)
    {
        yield return new WaitForSeconds(inXSeconds);
        GetComponent<EnemySpawner>().spawnWave(m_WaveNumber);
        GUIManager.getInstance().deactiveGetReadyText();
    }

    IEnumerator delayNextWave(float inXSeconds)
    {
		
        yield return new WaitForSeconds(inXSeconds);
        m_WaveNumber++;
		if (m_WaveNumber % 2 == 0) {
			GetComponent<TrapsSpawner>().spawnTramp();
		}
        GetComponent<EnemySpawner>().spawnWave(m_WaveNumber);
        audioSource.clip = SoundManager.getInstance().startWave();
        audioSource.Play();
        GUIManager.getInstance().updateWaveNumber(m_WaveNumber);
        watingNextWave = false;
        GUIManager.getInstance().deactiveNexWaveText();

    }

	void endGame()
    {
        Time.timeScale = 0;
        GUIManager.getInstance().getEndScreen().SetActive(true);
    }


}
