using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScriptMainMenu : MonoBehaviour {

    public GameObject MainMenuScreen;

	void Start () {

        MainMenuScreen.SetActive(true);
	}

    public void playGame()
    {
        SceneManager.LoadScene("CombatScene");

    }
	
    public void Credits()
    {

    }


    public void Quit()
    {
        Application.Quit();
    }

}
