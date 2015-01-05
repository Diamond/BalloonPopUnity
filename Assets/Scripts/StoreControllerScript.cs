using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class StoreControllerScript : MonoBehaviour {
	private int _points             = 0;
	private int _multiplierCost     = 100;
	private int _batteryCost        = 250;
	private int _peaShooterCost     = 500;
	private int _colorSmartBombCost = 500;
	private int _flamethrowerCost   = 750;
	private int _chainReactionCost  = 750;
	private int _machineGunCost     = 1000;

	public Text multiplierCostText;
	public Text batteryCostText;
	public Text peaShooterCostText;
	public Text colorSmartBombCostText;
	public Text flamethrowerText;
	public Text chainReactionText;
	public Text machinegunText;

	void Start() {
		InitStore ();
	}

	void InitPoints() {
		if (PlayerPrefs.HasKey("Points")) {
			_points = PlayerPrefs.GetInt("Points");
		}
	}

	void InitStore() {
		InitPoints();
		InitMultiplier();
		InitBattery();
		InitChainReaction();
		InitFlamethrower();
		InitMachinegun();
		InitPeaShooter();
		InitSmartBomb();
	}

	void InitMultiplier() {
		int cost = 100;
		int multiplier = 2;
		if (PlayerPrefs.HasKey("Multiplier")) {
			multiplier = Mathf.Min(multiplier, PlayerPrefs.GetInt ("Multiplier"));
		}
		if (multiplier > 2) {
			cost = 1000 * (multiplier - 2);
		}
		// DEBUG REMOVE ME:
		cost = 1;
		_multiplierCost = cost;
		multiplierCostText.text = _multiplierCost.ToString();
	}

	public void BuyMultiplier() {
		if (_points < _multiplierCost) return;
		int multiplier = 2;
		if (PlayerPrefs.HasKey("Multiplier")) {
			multiplier = Mathf.Min (multiplier, PlayerPrefs.GetInt ("Multiplier")) + 1;
		}
		PlayerPrefs.SetInt ("Multiplier", multiplier);
		Buy (_multiplierCost);
	}

	void InitBattery() {
		Debug.Log ("Not Implemented Yet");
	}

	public void BuyBattery() {
		Debug.Log ("Not Implemented Yet");
	}

	void InitPeaShooter() {
		Debug.Log ("Not Implemented Yet");
	}

	public void BuyPeaShooter() {
		Debug.Log ("Not Implemented Yet");
	}

	void InitSmartBomb() {
		Debug.Log ("Not Implemented Yet");
	}

	public void BuySmartBomb() {
		Debug.Log ("Not Implemented Yet");
	}

	void InitFlamethrower() {
		Debug.Log ("Not Implemented Yet");
	}

	public void BuyFlamethrower() {
		Debug.Log ("Not Implemented Yet");
	}

	void InitChainReaction() {
		Debug.Log ("Not Implemented Yet");
	}

	public void BuyChainReaction() {
		Debug.Log ("Not Implemented Yet");
	}

	void InitMachinegun() {
		Debug.Log ("Not Implemented Yet");
	}

	public void BuyMachinegun() {
		Debug.Log ("Not Implemented Yet");
	}

	void Buy(int cost) {
		_points -= cost;
		_points = Mathf.Max(0, _points);
		PlayerPrefs.SetInt ("Points", _points);
		InitStore();
	}

	public void ExitStore() {
		Application.LoadLevel ("TitleScreen");
	}
}
