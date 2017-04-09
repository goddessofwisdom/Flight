using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Collider2D Collider2D;

	public void OnMove () {
		//Vector3 position = Camera.main.WorldToViewportPoint (transform.position);
		if (!(Input.acceleration.x < 0.0 || Input.acceleration.x > 1.0)) {
			if (!(Input.acceleration.y < 0.0 || Input.acceleration.y > 1.0)) {
				transform.Translate (Input.acceleration.x, Input.acceleration.y, 0);
			} else {
				Debug.Log ("Reached a vertical edge!");
			}
		} else {
			Debug.Log ("Reached a horizontal edge!");
		}
	}
		
}
