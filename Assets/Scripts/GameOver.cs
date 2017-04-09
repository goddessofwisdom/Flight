using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public Text TitleLabel;
	public Text ContentLabel;
	public Button ConfirmButton;

	public void OnConfirmButtonPressed() {
		Close ();
	}


	public void OnUnderlayButtonPressed() {
		Close();
	}


	protected void Close() {
		gameObject.SetActive(false);
	}
}
	
