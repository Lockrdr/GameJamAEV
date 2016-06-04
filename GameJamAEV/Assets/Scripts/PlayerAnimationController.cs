using UnityEngine;
using System.Collections;

public class PlayerAnimationController : MonoBehaviour {

    private GameObject NoBodyGO;
    private GameObject HalfBodyGO;
    private GameObject FullBodyGO;

    private PlayerCombat playerCombatScript;

    private static PlayerAnimationController m_instance;

    public static PlayerAnimationController getInstance()
    {
        return m_instance;
    }
    

	void Start () {
        if (m_instance == null)
            m_instance = this;

        NoBodyGO = gameObject.transform.Find("NoBody").gameObject;
        HalfBodyGO = gameObject.transform.Find("HalfBody").gameObject;
        FullBodyGO = gameObject.transform.Find("FullBody").gameObject;
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
