using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControllerScript : MonoBehaviour {

	public Transform balloonPrefab;

	private float timeSinceLastSpawn = 0.0f;
	private float timeToSpawn = 0.0f;

	private List<Transform> balloons;

	private const int BALLOON_POOL = 35;

	void Start () {
		balloons = new List<Transform>();
		for (int i = 0; i < BALLOON_POOL; i++) {
			Transform balloon = Instantiate(balloonPrefab) as Transform;
			balloon.parent = this.transform;
			balloons.Add(balloon);
		}
		SpawnBalloon();
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastSpawn += Time.deltaTime;
		if (timeSinceLastSpawn >= timeToSpawn) {
			SpawnBalloon();
		}
	}

	void SpawnBalloon() {
		timeSinceLastSpawn = 0.0f;
		timeToSpawn = Random.Range (0.0f, 2.0f);
		foreach (Transform b in balloons) {
			BalloonScript bs = b.GetComponent<BalloonScript>();
			if (bs && !bs.isActive) {
				bs.Activate();
				break;
			}
		}
	}
}
