using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Collider2D Collider2D;

	public void OnMove () {
		transform.Translate (Input.acceleration.x, Input.acceleration.y, 0);
	}
		
}
