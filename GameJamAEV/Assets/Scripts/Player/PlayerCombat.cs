using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour {

    public float m_playerHealth = 0f;



    public void substractLife(float amount)
    {
        m_playerHealth -= amount;
        if (m_playerHealth <= GameManager.getInstance().hpToBecomeAlive)
        {
            if (m_playerHealth < 0)
                m_playerHealth = 0;

            GameManager.getInstance().changePlayerState(GameStates.PlayerState.Dead);
            Debug.Log("Jugador con menos de 0 de vida. Estado Dead");

        }
        GUIManager.getInstance().updateHP(m_playerHealth);

    }


    public void addLife(float amount)
    {
        m_playerHealth += amount;

        if (m_playerHealth >= 100)
        {
            GameManager.getInstance().changePlayerState(GameStates.PlayerState.Resurrected);

            Debug.Log("Jugador revivido");

        }else if(m_playerHealth > GameManager.getInstance().hpToBecomeAlive)
        {
            GameManager.getInstance().changePlayerState(GameStates.PlayerState.Alive);

            Debug.Log("Jugador con mas de 0 de vida. Estado Alive");
        }
        GUIManager.getInstance().updateHP(m_playerHealth);
        
        
    }
    
	void Start () {

        GUIManager.getInstance().updateHP(m_playerHealth);

	}
	
	
	void Update () {
	

	}
}
