using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutoMenu : MonoBehaviour {

	public GameObject TutoScreen;

	void Start () {

		TutoScreen.SetActive(true);
	}

	public void playGame()
	{
		SceneManager.LoadScene("CombatScene");

	}


}
