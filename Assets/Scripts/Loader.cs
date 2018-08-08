﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Loader : MonoBehaviour {

	public GameObject gameManager;


	// Use this for initialization
	void Awake () 
	{
        Debug.Log("Loader");
		if (GameManager.instance == null)
			Instantiate (gameManager);

		//GameManager.GetInstance().InitGame();
		//Debug.Log ("InitGame");
	}

}
