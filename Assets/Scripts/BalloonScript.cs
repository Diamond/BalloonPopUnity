using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BalloonScript : MonoBehaviour {

	public List<Sprite> balloonImages;

	public bool isActive = false;

	// Use this for initialization
	void Start () {
		int balloonChoice = Random.Range (0, balloonImages.Count);
		this.GetComponent<SpriteRenderer>().sprite = balloonImages[balloonChoice];
		this.transform.position = new Vector3(0.0f, -10.0f, 0.0f);
	}

	void Update() {
		if (this.transform.position.y > 6.0f && isActive) {
			Deactivate();
		}
	}

	public void Activate() {
		isActive = true;
		float upSpeed = Random.Range (1.5f, 4.0f);
		this.rigidbody2D.velocity = new Vector3(0.0f, upSpeed, 0.0f);
		this.transform.position = new Vector3(Random.Range (-2.4f, 2.45f), -6.0f, 0.0f);
	}

	public void Deactivate() {
		isActive = false;
		this.rigidbody2D.velocity = Vector3.zero;
	}
}
