using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour {

    public float m_playerHealth = 0f;

    public enum PlayerState { Alive = 0, Dead = 1, Resurrected = 2};
    public PlayerState m_playerState = 0;


    public void substractLife(float amount)
    {
        m_playerHealth -= amount;
        if(m_playerHealth <= 0)
        {
            if (m_playerHealth < 0)
                m_playerHealth = 0;

            m_playerState = PlayerState.Dead;
            Debug.Log("Jugador con menos de 0 de vida. Estado Dead");
        }
    }


    public void addLife(float amount)
    {
        m_playerHealth += amount;

        if (m_playerHealth >= 100)
        {
            m_playerState = PlayerState.Resurrected;
            Debug.Log("Jugador revivido");

        }else if(m_playerHealth > 0)
        {
            m_playerState = PlayerState.Alive;
            Debug.Log("Jugador con mas de 0 de vida. Estado Alive");
        }
        
        
    }
    
	void Start () {
	
	}
	
	
	void Update () {
	

	}
}
