using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {


	public bool pause = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Pause()
	{
		
	    pause = !pause;
		if (pause) 
		{
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
		}
			
	}


}
