using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Analytics;

public class PlayerCombat : MonoBehaviour {

    public float m_playerHealth = 0f;

    [Tooltip("Invencibility time after taking damage")]
    public float m_invicibilityTime = 3f;

    protected float m_timeInvicible;


    private GameObject NoBodyGO;
    private GameObject QuarterBodyGO;
    private GameObject HalfBodyGO;
    private GameObject ThreeQuarterBodyGO;
    private GameObject FullBodyGO;

    private SpriteRenderer spriteRenderer;
    private GameObject WallFloors ;

	private AudioSource audioSource;

    public Animator currentAnimController;

    void Start()
    {
 
        GUIManager.getInstance().updateHP(m_playerHealth);
        NoBodyGO = gameObject.transform.Find("NoBody").gameObject;
        QuarterBodyGO = gameObject.transform.Find("QuarterBody").gameObject;
        
        HalfBodyGO = gameObject.transform.Find("HalfBody").gameObject;
        ThreeQuarterBodyGO = gameObject.transform.Find("ThreeQuarterBody").gameObject;

        FullBodyGO = gameObject.transform.Find("FullBody").gameObject;
        updateSprite();
        GameManager.getInstance().checkState(m_playerHealth);

        WallFloors = GameObject.Find("Walls&Floor").gameObject;

		audioSource = gameObject.GetComponent<AudioSource> ();

    }

    public void substractLife(float amount)
    {
        m_playerHealth -= amount;
		audioSource.clip = SoundManager.getInstance ().damageToThePlayer ();
		audioSource.Play ();

        if (m_playerHealth <= GameManager.getInstance().hpToBecomeAlive)
        {
			if (m_playerHealth < 0) {
				m_playerHealth = 0;

			}
            GameManager.getInstance().changePlayerState(GameStates.PlayerState.Dead);
            //Debug.Log("Jugador con menos de 0 de vida. Estado Dead");

        }
        GUIManager.getInstance().updateHP(m_playerHealth);
        updateSprite();

    }

    void Update()
    {
        m_timeInvicible -= Time.deltaTime;

    }


    IEnumerator stopDamageAnim(float inXSeconds)
    {

        yield return new WaitForSeconds(inXSeconds);
        currentAnimController.Play("Idle");
    }

  

    public void addLife(float amount)
    {
        if (m_timeInvicible < 0)
        {
            m_timeInvicible = m_invicibilityTime;

            //currentAnimController.Play("EnemyShootMe");
            //playDamageAnim();
            //StartCoroutine(stopDamageAnim(m_invicibilityTime));

            m_playerHealth += amount;
            audioSource.clip = SoundManager.getInstance().healthToThePlayer();
            audioSource.Play();

            WallFloors.GetComponent<CameraShakeEffects>().ShakeCamera();

            if (m_playerHealth >= GameManager.getInstance().hpEndGame)
            {
                GameManager.getInstance().changePlayerState(GameStates.PlayerState.Resurrected);
                audioSource.clip = SoundManager.getInstance().playerDeath();
                audioSource.Play();
                Debug.Log("Jugador revivido");

                Analytics.CustomEvent("gameOver", new Dictionary<string, object>
                {
                    { "Wave", GameManager.getInstance().m_WaveNumber},
                });



            }
            else if (m_playerHealth > GameManager.getInstance().hpToBecomeAlive)
            {
                GameManager.getInstance().changePlayerState(GameStates.PlayerState.Alive);

                //Debug.Log("Jugador con mas de 0 de vida. Estado Alive");
            }
            GUIManager.getInstance().updateHP(m_playerHealth);
            updateSprite();
        }
    }
    
	
	
    
    void updateSprite()
    {
        if(m_playerHealth < GameManager.getInstance().HpForQuarterBody)
        {
            NoBodyGO.SetActive(true);
            QuarterBodyGO.SetActive(false);
            ThreeQuarterBodyGO.SetActive(false);
            HalfBodyGO.SetActive(false);
            FullBodyGO.SetActive(false);
            currentAnimController = NoBodyGO.GetComponent<Animator>();
        }
        else if(m_playerHealth < GameManager.getInstance().HpForHalfBody)
        {
            NoBodyGO.SetActive(false);
            QuarterBodyGO.SetActive(true);
            ThreeQuarterBodyGO.SetActive(false);
            HalfBodyGO.SetActive(false);
            FullBodyGO.SetActive(false);
            currentAnimController = QuarterBodyGO.GetComponent<Animator>();
        }
        else if (m_playerHealth < GameManager.getInstance().HpForThreeQuarterBody)
        {
            NoBodyGO.SetActive(false);
            QuarterBodyGO.SetActive(false);
            ThreeQuarterBodyGO.SetActive(false);
            HalfBodyGO.SetActive(true);
            FullBodyGO.SetActive(false);
            currentAnimController = HalfBodyGO.GetComponent<Animator>();
        }
        else if (m_playerHealth < GameManager.getInstance().HpForFullBody)
        {
            NoBodyGO.SetActive(false);
            QuarterBodyGO.SetActive(false);
            ThreeQuarterBodyGO.SetActive(true);
            HalfBodyGO.SetActive(false);
            FullBodyGO.SetActive(false);
            currentAnimController = ThreeQuarterBodyGO.GetComponent<Animator>();
        }
        else
        {
            NoBodyGO.SetActive(false);
            QuarterBodyGO.SetActive(false);
            ThreeQuarterBodyGO.SetActive(false);
            HalfBodyGO.SetActive(false);
            FullBodyGO.SetActive(true);
            currentAnimController = FullBodyGO.GetComponent<Animator>();
        }
    }
}
