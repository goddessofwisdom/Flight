using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesView : MonoBehaviour {

	public Text LivesLabel;

	public void UpdateLives (int lives) {
		LivesLabel.text = "Lives: " + lives.ToString ("N0");
	}
}
	