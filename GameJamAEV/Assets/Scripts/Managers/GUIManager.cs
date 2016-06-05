using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GUIManager : MonoBehaviour {

    private static GUIManager m_instance;

    public static GUIManager getInstance()
    {
        return m_instance;
    }

    private GameObject nextWaveIncomingGO;
    private GameObject getReadyGO;

    private Text m_lifeNumber;
    private Text m_waveNumber;

    
    private Image m_healthBar;

    private PlayerMovement m_playerMovement;
    private PlayerCombat m_playerCombat;

    private Button botonPlayAgain;
    private Button botonMainMenu;

	public string[] deathText = 	{"Now you have to clean your room",
									 "And tomorrow is monday"};

    //private GameObject endScreen;


    //private bool paused = false;

	void OnEnable(){
		
		transform.Find ("EndScreen/Text").GetComponent<Text> ().text = returnText();

	}

    void Awake()
    {
        m_lifeNumber = transform.Find("UI/Life/LifeNumber").GetComponent<Text>();
        m_waveNumber = transform.Find("UI/Wave/WaveNumber").GetComponent<Text>();

    }

    void Start()
    {
        if (m_instance == null)
            m_instance = this;

        updateWaveNumber(GameManager.getInstance().m_WaveNumber);

        //endScreen = transform.Find("EndScreen").gameObject;

        m_lifeNumber = transform.Find("UI/Life/LifeNumber").GetComponent<Text>();
        botonPlayAgain = transform.Find("EndScreen/PlayAgainButton").GetComponent<Button>();
        botonMainMenu = transform.Find("EndScreen/BackToMenuButton").GetComponent<Button>();
        setButtonAutomatically();
        
    }

    public void activeNexWaveText()
    {
        if(nextWaveIncomingGO==null)
        {
            nextWaveIncomingGO = transform.Find("UI/NextWaveIncoming").gameObject;
        }

        nextWaveIncomingGO.SetActive(true);
    }

    public void deactiveNexWaveText()
    {
        if (nextWaveIncomingGO == null)
        {
            nextWaveIncomingGO = transform.Find("UI/NextWaveIncoming").gameObject;
        }

        nextWaveIncomingGO.SetActive(false);
    }


    public void deactiveGetReadyText()
    {
        if (getReadyGO == null)
        {
            getReadyGO = transform.Find("UI/GetReady").gameObject;
        }

        getReadyGO.SetActive(false);
    }

    public void activeGetReadyText()
    {
        if (getReadyGO == null)
        {
            getReadyGO = transform.Find("UI/GetReady").gameObject;
        }

        getReadyGO.SetActive(true);
    }


    void setButtonAutomatically()
    {
        botonPlayAgain.onClick.RemoveAllListeners();
        botonPlayAgain.onClick.SetPersistentListenerState(0, UnityEngine.Events.UnityEventCallState.Off);
        botonPlayAgain.onClick.AddListener(() =>playAgain());

        botonMainMenu.onClick.RemoveAllListeners();
        botonMainMenu.onClick.SetPersistentListenerState(0, UnityEngine.Events.UnityEventCallState.Off);
        botonMainMenu.onClick.AddListener(() => MainMenu());

    }
     

    public void updateWaveNumber(int wave)
    {
        m_waveNumber.text = "" + wave;
    }

    /// <summary>
    /// Update hp points
    /// </summary>
    /// <param name="hp">The amount of hp the player has</param>
    /// <returns> </returns>
    public void updateHP(float hp)
    {
        m_lifeNumber.text = "" + hp;
    }

    void Update()
    {
        //if (Input.GetButtonDown("Pausa"))
        //{
        //    paused = !paused;
        //    if (paused)
        //        Time.timeScale = 0;
        //    else
        //        Time.timeScale = 1;

        //}
    }        
    void playAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");

    }

    public void Quit()
    {
        Application.Quit();
    }


    public GameObject getEndScreen()
    {
        return transform.Find("EndScreen").gameObject;
    }

	public string returnText(){
	
		return deathText[Random.Range(0,deathText.Length)];

	}
}
