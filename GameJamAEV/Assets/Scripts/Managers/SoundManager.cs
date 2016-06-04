using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	private static SoundManager m_instance;

	public AudioClip[] audioClips;

	public static SoundManager getInstance()
	{
		return m_instance;
	}
		
	void Start () {

		if (m_instance == null)
			m_instance = this;
	}

	public AudioClip damageToThePlayer(){
		return audioClips [0];
	}

	public AudioClip playerDeath(){
		return audioClips [1];
	}

	public AudioClip startWave(){
		return audioClips [2];
	}

	public AudioClip playerShoot(){
		return audioClips [3];
	}

	public AudioClip enemyShoot(){
		return audioClips[4];
	}

	public AudioClip enemyDeath(){
		return audioClips [5];
	}

	public AudioClip healthToThePlayer(){
		return audioClips [6];
	}
		
}
