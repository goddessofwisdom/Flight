using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour {

	public Text ScoreLabel;

	public void Start() {
		double newWidth = (Screen.width/4);
		double newHeight = (Screen.height/6);
		RectTransform rt = (RectTransform)this.transform;
		rt.sizeDelta = new Vector2 ((float)newWidth, (float)newHeight);
		float newX = Screen.width;
		float newY = Screen.height;
		transform.position = new Vector3 (newX, newY, 1);
	}

	public void UpdateScore (int score) {
		ScoreLabel.text = "Score: " + score.ToString ("N0");
	}
}
