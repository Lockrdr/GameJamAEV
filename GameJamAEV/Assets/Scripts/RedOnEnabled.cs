using UnityEngine;
using System.Collections;

public class RedOnEnabled : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private PlayerCombat playerCombatScript;

    public Color damageColor;

    void OnEnable()
    {
        playerCombatScript = GameObject.Find("Player").GetComponent<PlayerCombat>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = damageColor;
        Invoke("changeBackToNormalColor", playerCombatScript.m_invicibilityTime);
    }

    void changeBackToNormalColor()
    {
        spriteRenderer.color = Color.white;
    }

}
