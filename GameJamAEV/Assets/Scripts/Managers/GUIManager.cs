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



    private Text m_lifeNumber;
    private Text m_waveNumber;

    
    private Image m_healthBar;

    private PlayerMovement m_playerMovement;
    private PlayerCombat m_playerCombat;



    //private bool paused = false;

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
}
