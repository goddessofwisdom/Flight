using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public Text ContentLabel;
	public Button ConfirmButton;


	public void OnConfirmButtonPressed() {
		HideButton ();
		Close ();
	}

	protected void HideButton() {
		ConfirmButton.gameObject.SetActive (false);
	}

	protected void Close() {
		gameObject.SetActive(false);
	}
}
	
