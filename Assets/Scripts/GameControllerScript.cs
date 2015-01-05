using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

	public Transform balloonPrefab;
	public Text      scoreDisplay;

	private int             _playerScore        = 0;
	private int             _multiplier         = 1;
	private float           _timeSinceLastSpawn = 0.0f;
	private float           _timeToSpawn        = 0.0f;
	private List<Transform> _balloons;

	private const int BALLOON_POOL = 35;

	void Start () {
		_balloons = new List<Transform>();
		for (int i = 0; i < BALLOON_POOL; i++) {
			Transform balloon = Instantiate(balloonPrefab) as Transform;
			balloon.parent = this.transform;
			_balloons.Add(balloon);
		}
		SpawnBalloon();

		GameStart();
	}

	void InitMultiplier() {
		if (PlayerPrefs.HasKey("Multiplier")) {
			_multiplier = Mathf.Max (1, PlayerPrefs.GetInt ("Multiplier"));
		}
	}

	void InitPoints() {
		if (PlayerPrefs.HasKey("Points")) {
			_playerScore = PlayerPrefs.GetInt("Points");
		}
	}
	
	// Update is called once per frame
	void Update () {
		_timeSinceLastSpawn += Time.deltaTime;
		if (_timeSinceLastSpawn >= _timeToSpawn) {
			SpawnBalloon();
		}
	}

	void SpawnBalloon() {
		_timeSinceLastSpawn = 0.0f;
		_timeToSpawn = Random.Range (0.0f, 2.0f);
		foreach (Transform b in _balloons) {
			BalloonScript bs = b.GetComponent<BalloonScript>();
			if (bs && !bs.isActive) {
				bs.Activate();
				break;
			}
		}
	}

	public void AddPoints(int points=1) {
		_playerScore += points * _multiplier;
		UpdateScoreDisplay();
	}

	public void GameOver() {
		SavePoints();
		Application.LoadLevel("TitleScreen");
	}

	void UpdateScoreDisplay() {
		scoreDisplay.text = "Score: " + _playerScore.ToString() + "(x" + _multiplier.ToString() + ")";
	}

	public void GameStart() {
		InitPoints();
		InitMultiplier();
		UpdateScoreDisplay();
	}

	void OnApplicationPause() {
		SavePoints();
	}

	void OnApplicationQuit() {
		SavePoints();
	}

	void SavePoints() {
		PlayerPrefs.SetInt("Points", _playerScore);
	}
}
