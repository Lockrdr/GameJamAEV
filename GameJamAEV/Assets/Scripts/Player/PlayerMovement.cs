using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    
    
    public float m_playerSpeed = 5;
    Vector2 wallUpPosition;
    Vector2 wallLeftPosition;
    Vector2 wallRightPosition;
    Vector2 wallDownPosition;
    private PlayerCombat playerCombatScript;
    //private SpriteRenderer spriteRenderer;

	void Start () {

        wallUpPosition = GameObject.Find("WallUp").transform.position;
        wallLeftPosition = GameObject.Find("WallLeft").transform.position;
        wallRightPosition = GameObject.Find("WallRight").transform.position;
        wallDownPosition = GameObject.Find("WallDown").transform.position;
        playerCombatScript = GetComponent<PlayerCombat>();
        //spriteRenderer = playerCombatScript.currentAnimController.GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && transform.position.y < wallUpPosition.y)
        {
            transform.Translate(0, Time.deltaTime * m_playerSpeed, 0);
            PlayerAnimationController.getInstance().playUp();
            playerCombatScript.currentAnimController.GetComponent<SpriteRenderer>().flipX = false;

        }

        if (Input.GetKey(KeyCode.S) && transform.position.y > wallDownPosition.y)
        {
            transform.Translate(0, Time.deltaTime * -m_playerSpeed, 0);
            PlayerAnimationController.getInstance().playDown();

            playerCombatScript.currentAnimController.GetComponent<SpriteRenderer>().flipX = false;

        }

        if (Input.GetKey(KeyCode.A) && transform.position.x > wallLeftPosition.x)
        {
            PlayerAnimationController.getInstance().playLeft();
            transform.Translate(Time.deltaTime * -m_playerSpeed, 0, 0);
            playerCombatScript.currentAnimController.GetComponent<SpriteRenderer>().flipX = false;

        }
      
        if (Input.GetKey(KeyCode.D) && transform.position.x < wallRightPosition.x)
        {
            PlayerAnimationController.getInstance().playRight();
            playerCombatScript.currentAnimController.GetComponent<SpriteRenderer>().flipX = true;
            transform.Translate(Time.deltaTime * m_playerSpeed, 0, 0);

        }
    }
}
