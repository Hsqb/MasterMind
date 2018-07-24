using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	//public static GameManager instance = null;

	public static GameManager instance;

	public static GameManager GetInstance() {

		if (instance == null) {
			instance = FindObjectOfType<GameManager> ();

			if (instance == null) {
				GameObject container = new GameObject ("GameManager");

				instance = container.AddComponent<GameManager> ();

			}

		}
		return instance;
	}



	public Text resource1Text;
	public Text resource2Text;
	public Text resource3Text;
	public Text resource4Text;
	public Text resource5Text;
	public Text facility1Text;
	public Text facility2Text;
	public Text facility3Text;
	public Text facility4Text;
	public Text facility5Text;

	public Text advancedfacility1Text;
	public Text advancedfacility2Text;
	public Text advancedfacility3Text;
	public Text advancedfacility4Text;

	public Text playerApText;

	public int resource1 = 0;
	public int resource2 = 0;
	public int resource3 = 0;
	public int resource4 = 0;
	public int resource5 = 0;

	public int requireResource1ActivateFacility1 = 1;
	public int requireResource2ActivateFacility1 = 1;
	public int requireResource3ActivateFacility1 = 0;
	public int requireResource4ActivateFacility1 = 0;
	public int requireResource5ActivateFacility1 = 0;

	public int requireResource1ActivateFacility2 = 2;
	public int requireResource2ActivateFacility2 = 2;
	public int requireResource3ActivateFacility2 = 0;
	public int requireResource4ActivateFacility2 = 0;
	public int requireResource5ActivateFacility2 = 0;

	public int requireResource1ActivateFacility3 = 3;
	public int requireResource2ActivateFacility3 = 3;
	public int requireResource3ActivateFacility3 = 0;
	public int requireResource4ActivateFacility3 = 0;
	public int requireResource5ActivateFacility3 = 0;

	public int requireResource1ActivateFacility4 = 4;
	public int requireResource2ActivateFacility4 = 4;
	public int requireResource3ActivateFacility4 = 0;
	public int requireResource4ActivateFacility4 = 0;
	public int requireResource5ActivateFacility4 = 0;

	public int requireResource1ActivateFacility5 = 5;
	public int requireResource2ActivateFacility5 = 5;
	public int requireResource3ActivateFacility5 = 0;
	public int requireResource4ActivateFacility5 = 0;
	public int requireResource5ActivateFacility5 = 0;

	public int requireResource1ActivateAdvancedFacility1 = 1;
	public int requireResource2ActivateAdvancedFacility1 = 1;
	public int requireResource3ActivateAdvancedFacility1 = 0;
	public int requireResource4ActivateAdvancedFacility1 = 0;
	public int requireResource5ActivateAdvancedFacility1 = 0;

	public int requireResource1ActivateAdvancedFacility2 = 2;
	public int requireResource2ActivateAdvancedFacility2 = 2;
	public int requireResource3ActivateAdvancedFacility2 = 0;
	public int requireResource4ActivateAdvancedFacility2 = 0;
	public int requireResource5ActivateAdvancedFacility2 = 0;

	public int requireResource1ActivateAdvancedFacility3 = 3;
	public int requireResource2ActivateAdvancedFacility3 = 3;
	public int requireResource3ActivateAdvancedFacility3 = 0;
	public int requireResource4ActivateAdvancedFacility3 = 0;
	public int requireResource5ActivateAdvancedFacility3 = 0;

	public int requireResource1ActivateAdvancedFacility4 = 4;
	public int requireResource2ActivateAdvancedFacility4 = 4;
	public int requireResource3ActivateAdvancedFacility4 = 0;
	public int requireResource4ActivateAdvancedFacility4 = 0;
	public int requireResource5ActivateAdvancedFacility4 = 0;

	public int requireResource1UsingFacility3 = 0;
	public int requireResource2UsingFacility3 = 1;
	public int requireResource3UsingFacility3 = 0;
	public int requireResource4UsingFacility3 = 0;
	public int requireResource5UsingFacility3 = 0;

	public int requireResource1UsingFacility4 = 0;
	public int requireResource2UsingFacility4 = 1;
	public int requireResource3UsingFacility4 = 0;
	public int requireResource4UsingFacility4 = 0;
	public int requireResource5UsingFacility4 = 0;

	public int requireResource1UsingFacility5 = 3;
	public int requireResource2UsingFacility5 = 0;
	public int requireResource3UsingFacility5 = 0;
	public int requireResource4UsingFacility5 = 2;
	public int requireResource5UsingFacility5 = 0;

	[HideInInspector]public int playerAP = 3;
	[HideInInspector]public int playerMaxAP = 3;

	[HideInInspector]public int turn = 1;

//	public int resource1PerClick = 3;

	void Start (){


		resource1Text = GameObject.Find ("Resource1Text").GetComponent<Text> ();
		resource2Text = GameObject.Find ("Resource2Text").GetComponent<Text> ();
		resource3Text = GameObject.Find ("Resource3Text").GetComponent<Text> ();
		resource4Text = GameObject.Find ("Resource4Text").GetComponent<Text> ();
		resource5Text = GameObject.Find ("Resource5Text").GetComponent<Text> ();

		facility1Text = GameObject.Find ("Facility1Text").GetComponent<Text> ();
		facility2Text = GameObject.Find ("Facility2Text").GetComponent<Text> ();
		facility3Text = GameObject.Find ("Facility3Text").GetComponent<Text> ();
		facility4Text = GameObject.Find ("Facility4Text").GetComponent<Text> ();
		facility5Text = GameObject.Find ("Facility5Text").GetComponent<Text> ();

		advancedfacility1Text = GameObject.Find ("AdvancedFacility1Text").GetComponent<Text> ();
		advancedfacility2Text = GameObject.Find ("AdvancedFacility2Text").GetComponent<Text> ();
		advancedfacility3Text = GameObject.Find ("AdvancedFacility3Text").GetComponent<Text> ();
		advancedfacility4Text = GameObject.Find ("AdvancedFacility4Text").GetComponent<Text> ();


		playerApText = GameObject.Find ("PlayerApText").GetComponent<Text> ();

		resource1 = DataController.GetInstance().GetResource1 ();
		resource2 = DataController.GetInstance().GetResource2 ();
		resource3 = DataController.GetInstance().GetResource3 ();
		resource4 = DataController.GetInstance().GetResource4 ();
		resource5 = DataController.GetInstance().GetResource5 ();

		resource1Text.text = "Electric  " + resource1;
		resource2Text.text = "Ore       " + resource2;
		resource3Text.text = "MicroChips" + resource3;
		resource4Text.text = "Ingot     " + resource4;
		resource5Text.text = "Newclear  " + resource5;

		playerApText.text = "AP " + playerAP;

		ActiveFacilities ();
	
	}

	public void ActiveFacilities(){

		if (DataController.GetInstance ().GetFacility1 () == 1) {
			GameObject.Find ("Facility1Button").GetComponent<Button> ().interactable = true;
			Debug.Log (DataController.GetInstance ().GetFacility1 ());
			facility1Text.text = "Power Plant\n(Electricity +3)";
		}
		else if (DataController.GetInstance ().GetResource1 () >= requireResource1ActivateFacility1 && DataController.GetInstance ().GetResource2 () >= requireResource2ActivateFacility1 && DataController.GetInstance ().GetResource3 () >= requireResource3ActivateFacility1 && DataController.GetInstance ().GetResource4 () >= requireResource4ActivateFacility1 && DataController.GetInstance ().GetResource5 () >= requireResource5ActivateFacility1) {
			GameObject.Find ("Facility1Button").GetComponent<Button> ().interactable = true;
			facility1Text.text = "Active Power Plant\n(Electricity -3)";
		}
		else {
			GameObject.Find ("Facility1Button").GetComponent<Button> ().interactable = false;
			facility1Text.text = "Active Power Plant\n(Electricity -3)";
		}


		if (DataController.GetInstance ().GetFacility2 () == 1) {
			GameObject.Find ("Facility2Button").GetComponent<Button> ().interactable = true;
			facility2Text.text = "Ore Mine\n(Ore +1)";
		}
		else if (DataController.GetInstance ().GetResource1 () >= requireResource1ActivateFacility2 && DataController.GetInstance ().GetResource2 () >= requireResource2ActivateFacility2 && DataController.GetInstance ().GetResource3 () >= requireResource3ActivateFacility2 && DataController.GetInstance ().GetResource4 () >= requireResource4ActivateFacility2 && DataController.GetInstance ().GetResource5 () >= requireResource5ActivateFacility2) {
			GameObject.Find ("Facility2Button").GetComponent<Button> ().interactable = true;
			facility2Text.text = "Active Ore Mind\n(Electricity -3)";
		}
		else {
			GameObject.Find ("Facility2Button").GetComponent<Button> ().interactable = false;
			facility2Text.text = "Active Ore Mind\n(Electricity -3)";
		}

		if (DataController.GetInstance ().GetFacility3 () == 1) {
			GameObject.Find ("Facility3Button").GetComponent<Button> ().interactable = true;
			facility3Text.text = "Micro Chips Plant\n(Ore -1 Micro Chips +2)";
		}
		else if (DataController.GetInstance ().GetResource1 () >= requireResource1ActivateFacility3 && DataController.GetInstance ().GetResource2 () >= requireResource2ActivateFacility3 && DataController.GetInstance ().GetResource3 () >= requireResource3ActivateFacility3 && DataController.GetInstance ().GetResource4 () >= requireResource4ActivateFacility3 && DataController.GetInstance ().GetResource5 () >= requireResource5ActivateFacility3) {
			GameObject.Find ("Facility3Button").GetComponent<Button> ().interactable = true;
			facility3Text.text = "Active Micro Chips Plant\n(Electricity -3)";
		}
		else {
			GameObject.Find ("Facility3Button").GetComponent<Button> ().interactable = false;
			facility3Text.text = "Active Micro Chips Plant\n(Electricity -3)";
		}


		if (DataController.GetInstance ().GetFacility4 () == 1) {
			GameObject.Find ("Facility4Button").GetComponent<Button> ().interactable = true;
			facility4Text.text = "Ingot Plant\n(Ore -1 Ingot +1)";
		}
		else if (DataController.GetInstance ().GetResource1 () >= requireResource1ActivateFacility4 && DataController.GetInstance ().GetResource2 () >= requireResource2ActivateFacility4 && DataController.GetInstance ().GetResource3 () >= requireResource3ActivateFacility4 && DataController.GetInstance ().GetResource4 () >= requireResource4ActivateFacility4 && DataController.GetInstance ().GetResource5 () >= requireResource5ActivateFacility4) {
			GameObject.Find ("Facility4Button").GetComponent<Button> ().interactable = true;
			facility4Text.text = "Active Ingot Plant\n(Electricity -3)";
		}
		else {
			GameObject.Find ("Facility4Button").GetComponent<Button> ().interactable = false;
			facility4Text.text = "Active Ingot Plant\n(Electricity -3)";
		}


		if (DataController.GetInstance ().GetFacility5 () == 1) {
			GameObject.Find ("Facility5Button").GetComponent<Button> ().interactable = true;
			facility5Text.text = "Newclear Silo\n(Ingot -2 Energy -3 Newclear +1)";
		}
		else if (DataController.GetInstance ().GetResource1 () >= requireResource1ActivateFacility5 && DataController.GetInstance ().GetResource2 () >= requireResource2ActivateFacility5 && DataController.GetInstance ().GetResource3 () >= requireResource3ActivateFacility5 && DataController.GetInstance ().GetResource4 () >= requireResource4ActivateFacility5 && DataController.GetInstance ().GetResource5 () >= requireResource5ActivateFacility5) {
			GameObject.Find ("Facility5Button").GetComponent<Button> ().interactable = true;
			facility5Text.text = "Active Newclear Silo\n(Electricity -3)";
		}
		else {
			GameObject.Find ("Facility5Button").GetComponent<Button> ().interactable = false;
			facility5Text.text = "Active Newclear Silo\n(Electricity -3)";
		}



		if (DataController.GetInstance ().GetAdvancedFacility1 () == 1) {
			GameObject.Find ("AdvancedFacility1Button").GetComponent<Button> ().interactable = true;
			advancedfacility1Text.text = "Power Plant\n(Electricity +3)";
		}
		else if (DataController.GetInstance ().GetResource1 () >= requireResource1ActivateAdvancedFacility1 && DataController.GetInstance ().GetResource2 () >= requireResource2ActivateAdvancedFacility1 && DataController.GetInstance ().GetResource3 () >= requireResource3ActivateAdvancedFacility1 && DataController.GetInstance ().GetResource4 () >= requireResource4ActivateAdvancedFacility1 && DataController.GetInstance ().GetResource5 () >= requireResource5ActivateAdvancedFacility1) {
			GameObject.Find ("AdvancedFacility1Button").GetComponent<Button> ().interactable = true;
			advancedfacility1Text.text = "Active Power Plant\n(Electricity -1)";
		}
		else {
			GameObject.Find ("AdvancedFacility1Button").GetComponent<Button> ().interactable = false;
		}


		if (DataController.GetInstance ().GetAdvancedFacility2 () == 1) {
			GameObject.Find ("AdvancedFacility2Button").GetComponent<Button> ().interactable = true;
			advancedfacility2Text.text = "Power Plant\n(Electricity +3)";
		}
		else if (DataController.GetInstance ().GetResource1 () >= requireResource1ActivateAdvancedFacility2 && DataController.GetInstance ().GetResource2 () >= requireResource2ActivateAdvancedFacility2 && DataController.GetInstance ().GetResource3 () >= requireResource3ActivateAdvancedFacility2 && DataController.GetInstance ().GetResource4 () >= requireResource4ActivateAdvancedFacility2 && DataController.GetInstance ().GetResource5 () >= requireResource5ActivateAdvancedFacility2) {
			GameObject.Find ("AdvancedFacility2Button").GetComponent<Button> ().interactable = true;
			advancedfacility2Text.text = "Active Power Plant\n(Electricity -1)";
		}
		else {
			GameObject.Find ("AdvancedFacility2Button").GetComponent<Button> ().interactable = false;
		}

		if (DataController.GetInstance ().GetAdvancedFacility3 () == 1) {
			GameObject.Find ("AdvancedFacility3Button").GetComponent<Button> ().interactable = true;
			advancedfacility3Text.text = "Power Plant\n(Electricity +3)";
		}
		else if (DataController.GetInstance ().GetResource1 () >= requireResource1ActivateAdvancedFacility3 && DataController.GetInstance ().GetResource2 () >= requireResource2ActivateAdvancedFacility3 && DataController.GetInstance ().GetResource3 () >= requireResource3ActivateAdvancedFacility3 && DataController.GetInstance ().GetResource4 () >= requireResource4ActivateAdvancedFacility3 && DataController.GetInstance ().GetResource5 () >= requireResource5ActivateAdvancedFacility3) {
			GameObject.Find ("AdvancedFacility3Button").GetComponent<Button> ().interactable = true;
			advancedfacility3Text.text = "Active Power Plant\n(Electricity -1)";
		}
		else {
			GameObject.Find ("AdvancedFacility3Button").GetComponent<Button> ().interactable = false;
		}


		if (DataController.GetInstance ().GetAdvancedFacility4 () == 1) {
			GameObject.Find ("AdvancedFacility4Button").GetComponent<Button> ().interactable = true;
			advancedfacility4Text.text = "Power Plant\n(Electricity +3)";
		}
		else if (DataController.GetInstance ().GetResource1 () >= requireResource1ActivateAdvancedFacility4 && DataController.GetInstance ().GetResource2 () >= requireResource2ActivateAdvancedFacility4 && DataController.GetInstance ().GetResource3 () >= requireResource3ActivateAdvancedFacility4 && DataController.GetInstance ().GetResource4 () >= requireResource4ActivateAdvancedFacility4 && DataController.GetInstance ().GetResource5 () >= requireResource5ActivateAdvancedFacility4) {
			GameObject.Find ("AdvancedFacility4Button").GetComponent<Button> ().interactable = true;
			advancedfacility4Text.text = "Active Power Plant\n(Electricity -1)";
		}
		else {
			GameObject.Find ("AdvancedFacility4Button").GetComponent<Button> ().interactable = false;
		}

					
	}

	public void Initialize(){

		DataController.GetInstance ().Initialize ();
		Start ();
	}

	public void UsingAP(){
	
		int currentPlayerAP = DataController.GetInstance().GetPlayerAP ();
		DataController.GetInstance ().SubPlayerAP ();

		if (DataController.GetInstance ().GetPlayerAP () <= 0) {
			DataController.GetInstance ().InitializePlayerAP ();
			turn = PlayerPrefs.GetInt ("Turn",1);
			turn++;
			Debug.Log ("turn is " + turn);
			PlayerPrefs.SetInt ("Turn",turn);
		}

		playerApText = GameObject.Find ("PlayerApText").GetComponent<Text> ();
		playerAP = DataController.GetInstance().GetPlayerAP ();
		playerApText.text = "AP " + playerAP;
	}

	public void OnClickFacility1(){

		//dataController = GameObject.Find ("DataController").GetComponent<DataController> ();

		if (DataController.GetInstance ().GetFacility1 () == 0) { 
			
			DataController.GetInstance ().SubResource1 (requireResource1ActivateFacility1);
			DataController.GetInstance ().SubResource2 (requireResource2ActivateFacility1);
			DataController.GetInstance ().SubResource3 (requireResource3ActivateFacility1);
			DataController.GetInstance ().SubResource4 (requireResource4ActivateFacility1);
			DataController.GetInstance ().SubResource5 (requireResource5ActivateFacility1);
			UsingAP ();
			DataController.GetInstance ().ActivateFacility1 ();
			Start ();
			ActiveFacilities ();
				
		} else {
			int resource1PerClick = DataController.GetInstance ().GetResource1PerClick ();
			DataController.GetInstance ().AddResource1 (resource1PerClick);
			UsingAP ();
			Start ();
			ActiveFacilities ();
		}
		/* replaced by using Start Function
		resource1Text = GameObject.Find ("Resource1Text").GetComponent<Text> ();
		resource1 = DataController.GetInstance().GetResource1 ();
		resource1Text.text = "Electric  " + resource1;
		*/
	}

	public void OnClickFacility2(){

		if (DataController.GetInstance ().GetFacility2 () == 0) { 
			DataController.GetInstance ().SubResource1 (requireResource1ActivateFacility2);
			DataController.GetInstance ().SubResource2 (requireResource2ActivateFacility2);
			DataController.GetInstance ().SubResource3 (requireResource3ActivateFacility2);
			DataController.GetInstance ().SubResource4 (requireResource4ActivateFacility2);
			DataController.GetInstance ().SubResource5 (requireResource5ActivateFacility2);
			UsingAP ();
			DataController.GetInstance ().ActivateFacility2 ();
			Start ();
			ActiveFacilities ();
	

		} else {
			int resource2PerClick = DataController.GetInstance ().GetResource2PerClick ();
			DataController.GetInstance ().AddResource2 (resource2PerClick);
			UsingAP ();
			Start ();
			ActiveFacilities ();
		}
	}

	public void OnClickFacility3(){
		
		if (DataController.GetInstance ().GetFacility3 () == 0) { 
			DataController.GetInstance ().SubResource1 (requireResource1ActivateFacility3);
			DataController.GetInstance ().SubResource2 (requireResource2ActivateFacility3);
			DataController.GetInstance ().SubResource3 (requireResource3ActivateFacility3);
			DataController.GetInstance ().SubResource4 (requireResource4ActivateFacility3);
			DataController.GetInstance ().SubResource5 (requireResource5ActivateFacility3);
			DataController.GetInstance ().ActivateFacility3 ();
			UsingAP ();
			Start ();
			ActiveFacilities ();

		} else if (DataController.GetInstance ().GetResource2 () >= requireResource2UsingFacility3) {
			int resource3PerClick = DataController.GetInstance ().GetResource3PerClick ();
			DataController.GetInstance ().AddResource3 (resource3PerClick);
			DataController.GetInstance ().SubResource2 (requireResource2UsingFacility3);

			UsingAP ();
			Start ();
		} else {
			Debug.Log ("Not Enough Ore! Rad!");
		}
	}

	public void OnClickFacility4(){

		if (DataController.GetInstance ().GetFacility4 () == 0) { 
			DataController.GetInstance ().SubResource1 (requireResource1ActivateFacility4);
			DataController.GetInstance ().SubResource2 (requireResource2ActivateFacility4);
			DataController.GetInstance ().SubResource3 (requireResource3ActivateFacility4);
			DataController.GetInstance ().SubResource4 (requireResource4ActivateFacility4);
			DataController.GetInstance ().SubResource5 (requireResource5ActivateFacility4);
			DataController.GetInstance ().ActivateFacility4 ();
			UsingAP ();
			Start ();
			ActiveFacilities ();

		} else if (DataController.GetInstance ().GetResource2 () >= requireResource2UsingFacility4) {
			int resource4PerClick = DataController.GetInstance ().GetResource4PerClick ();
			DataController.GetInstance ().AddResource4 (resource4PerClick);
			DataController.GetInstance ().SubResource2 (requireResource2UsingFacility4);

			UsingAP ();
			Start ();

		} else {
			Debug.Log ("Not Enough Ore! Rad!");
		}
	}

	public void OnClickFacility5(){

		if (DataController.GetInstance ().GetFacility5 () == 0) { 
			DataController.GetInstance ().SubResource1 (requireResource1ActivateFacility5);
			DataController.GetInstance ().SubResource2 (requireResource2ActivateFacility5);
			DataController.GetInstance ().SubResource3 (requireResource3ActivateFacility5);
			DataController.GetInstance ().SubResource4 (requireResource4ActivateFacility5);
			DataController.GetInstance ().SubResource5 (requireResource5ActivateFacility5);
			DataController.GetInstance ().ActivateFacility5 ();
			UsingAP ();
			Start ();
			ActiveFacilities ();

		} else if (DataController.GetInstance ().GetResource1 () >= requireResource1UsingFacility4 && DataController.GetInstance ().GetResource4 () >= requireResource4UsingFacility4) { // not yet
			int resource5PerClick = DataController.GetInstance ().GetResource5PerClick ();
			DataController.GetInstance ().AddResource5 (resource5PerClick);
			DataController.GetInstance ().SubResource1 (requireResource1UsingFacility5);
			DataController.GetInstance ().SubResource4 (requireResource4UsingFacility5);

			UsingAP ();
			Start ();

		} else {
			Debug.Log ("Not Enough Ore! Rad!");
		}
	}
}
