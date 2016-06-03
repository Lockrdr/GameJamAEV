using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    
    
    public float m_playerSpeed = 5;


	void Start () {
	
	}

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, Time.deltaTime * m_playerSpeed, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Time.deltaTime * -m_playerSpeed, 0, 0);

        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, Time.deltaTime * -m_playerSpeed, 0);

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Time.deltaTime * m_playerSpeed, 0, 0);

        }
    }
}
