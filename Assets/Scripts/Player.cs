using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Collider2D Collider2D;

	public void OnMove () {
		Vector3 position = Camera.main.WorldToViewportPoint (transform.position);
		if (!(position.x + Input.acceleration.x < 0.0) && !(position.x + Input.acceleration.x > Screen.width)) {
			if (!(position.y + Input.acceleration.y < 0.0) && !(position.y + Input.acceleration.y > Screen.height)) {
				transform.Translate (Input.acceleration.x, Input.acceleration.y, 0);
			} else {
				Debug.Log ("Reached a vertical edge!");
			}
		} else {
			Debug.Log ("Reached a horizontal edge!");
		}

		Vector3 newWorldPos = transform.position;
		newWorldPos.x += Input.acceleration.x;
		newWorldPos.y += Input.acceleration.y;

		Vector3 leftBoundPos = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0f, 0f));
		Vector3 rightBoundPos = Camera.main.ViewportToWorldPoint(new Vector3(0.9f, 0f, 0f));
		Vector3 upperBoundPos = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.9f, 0f));
		Vector3 lowerBoundPos = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.1f, 0f));

		if (newWorldPos.x < leftBoundPos.x || newWorldPos.x > rightBoundPos.x) {
			return; //do nothing
		}
		if (newWorldPos.y < lowerBoundPos.y || newWorldPos.y > upperBoundPos.y) {
			return; //do nothing
		}

		transform.position = newWorldPos;
	}
		
}
