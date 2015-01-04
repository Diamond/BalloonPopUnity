using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

	public Transform balloonPrefab;

	public Text scoreDisplay;

	private int playerScore = 0;

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

		GameStart();
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

	public void AddPoints(int points=1) {
		playerScore += points;
		scoreDisplay.text = "Score: " + playerScore.ToString();
	}

	public void GameOver() {
		PlayerPrefs.SetInt("Points", playerScore);
		Application.LoadLevel("TitleScreen");
	}

	public void GameStart() {
		if (PlayerPrefs.HasKey("Points")) {
			playerScore = PlayerPrefs.GetInt("Points");
		}
	}
}
