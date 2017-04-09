using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesView : MonoBehaviour {

	public Text LivesLabel;

	public void Start() {
		double newWidth = (Screen.width/4);
		double newHeight = (Screen.height/6);
		RectTransform rt = (RectTransform)this.transform;
		rt.sizeDelta = new Vector2 ((float)newWidth, (float)newHeight);
		float newX = Screen.width;
		float newY = (float)(Screen.height - (Screen.height/6));
		transform.position = new Vector3 (newX, newY, 1);
	}

	public void UpdateLives (int lives) {
		LivesLabel.text = "Lives: " + lives.ToString ("N0");
	}
}
	