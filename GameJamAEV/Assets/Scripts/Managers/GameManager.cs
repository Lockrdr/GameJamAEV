using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static GameManager m_instance;

    public static GameManager getInstance()
    {
        return m_instance;
    }

    //public enum PlayerState { Alive = 0, Dead = 1, Resurrected = 2 };
    public GameStates.PlayerState m_playerState;

    public void changePlayerState(GameStates.PlayerState state)
    {
        m_playerState = state;
    }

    public int m_WaveNumber = 1;
    public float hpToBecomeAlive = 50f;


	void Start () {
        if (m_instance == null)
            m_instance = this;
	}
	
	
	void Update () {
	
	}
}
