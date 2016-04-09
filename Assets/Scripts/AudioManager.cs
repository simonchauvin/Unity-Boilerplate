using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
	private static AudioManager _instance;


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

	void Start ()
	{
		
	}

	void Update ()
	{

	}
}