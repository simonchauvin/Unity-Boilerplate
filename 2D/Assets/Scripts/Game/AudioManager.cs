using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
	/// <summary>
	/// The only instance of the audio manager.
	/// </summary>
	private static AudioManager _instance;

	/// <summary>
	/// A sound.
	/// </summary>
	public AudioClip aSound;

	/// <summary>
	/// The audio source.
	/// </summary>
	private AudioSource thisAudio;


	/// <summary>
	/// Retrieve the instance of the audio manager.
	/// </summary>
	/// <value>The audio manager.</value>
	public static AudioManager instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = GameObject.Find("AudioManager").GetComponent<AudioManager>();
			}
			return _instance;
		}
	}

	// Use this for initialization
	void Start ()
	{
		// Components
		thisAudio = audio;
	}

	// Update is called once per frame
	void Update ()
	{

	}

	/// <summary>
	/// Plays a sound.
	/// </summary>
	public void playASound ()
	{
		thisAudio.PlayOneShot(aSound, 1.0f);
	}
}