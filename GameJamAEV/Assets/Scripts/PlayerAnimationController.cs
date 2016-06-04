using UnityEngine;
using System.Collections;

public class PlayerAnimationController : MonoBehaviour {


    private PlayerCombat playerCombatScript;

    private static PlayerAnimationController m_instance;

    public static PlayerAnimationController getInstance()
    {
        return m_instance;
    }
    

	void Start () {
        if (m_instance == null)
            m_instance = this;

        playerCombatScript = GetComponent<PlayerCombat>();
    }
	
	
    public void playIdle()
    {
        if(!playerCombatScript.currentAnimController.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            playerCombatScript.currentAnimController.Play("Idle");
    }
    public void playLeft()
    {
        if (!playerCombatScript.currentAnimController.GetCurrentAnimatorStateInfo(0).IsName("Left"))
            playerCombatScript.currentAnimController.Play("Left");
    }
    public void playRight()
    {
        if (!playerCombatScript.currentAnimController.GetCurrentAnimatorStateInfo(0).IsName("Right"))
            playerCombatScript.currentAnimController.Play("Right");
    }
    public void playUp()
    {
        if (!playerCombatScript.currentAnimController.GetCurrentAnimatorStateInfo(0).IsName("Up"))
            playerCombatScript.currentAnimController.Play("Up");
    }
    public void playDown()
    {
        if (!playerCombatScript.currentAnimController.GetCurrentAnimatorStateInfo(0).IsName("Down"))
            playerCombatScript.currentAnimController.Play("Down");
    }
	
}
