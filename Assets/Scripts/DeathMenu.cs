using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

	public Image BackgroundImage;
	public Text scoreText;

	private float transition = 0.0f;

	bool isShown = false;
	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isShown)
			return;
		transition += Time.deltaTime;
		BackgroundImage.color = Color.Lerp (new Color (0, 0, 0, 0), Color.black, transition);
	}

	public void ToggleEndMenu(float score)
	{
		
		gameObject.SetActive (true);
		scoreText.text = ((int)score).ToString ();
		isShown = true;
	}

	public void Restart()
	{
		//loading a scene, asking the scene manager on what scene we are, on restart click, boot the scene
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void ToMenu()
	{
		SceneManager.LoadScene ("Menu");
	}
}
