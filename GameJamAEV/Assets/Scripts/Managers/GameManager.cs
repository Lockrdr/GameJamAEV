using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static GameManager m_instance;

    public static GameManager getInstance()
    {
        return m_instance;
    }


    public int m_WaveNumber = 1;

	void Start () {
        if (m_instance == null)
            m_instance = this;
	}
	
	
	void Update () {
	
	}
}
