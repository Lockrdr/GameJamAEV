using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class TutoMenu : MonoBehaviour {

	public GameObject TutoScreen;

    private float tutoStartTime;

	void Start () {

        tutoStartTime = Time.time;

		TutoScreen.SetActive(true);
	}

	public void playGame()
	{
		SceneManager.LoadScene("CombatScene");

        Analytics.CustomEvent("LookAtTutorial", new Dictionary<string, object>
        {
            { "Time looking at tutorial", Time.time - tutoStartTime},
        });

	}


}
