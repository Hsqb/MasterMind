using UnityEngine;
using System.Collections;

public class ClickButton : MonoBehaviour {

	public DataController dataController;
//	public UIController uiController;

	public void OnClickResource1(){

		int resource1PerClick = dataController.GetResource1PerClick ();
		dataController.AddResource1 (resource1PerClick);
	}


}
