using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleScreenScript : MonoBehaviour {
	public Text scoreDisplay;

	public void Start() {
		if (PlayerPrefs.HasKey("Points")) {
			scoreDisplay.text = "Score: " + PlayerPrefs.GetInt ("Points").ToString();
		}
	}

	public void LoadGame() {
		Application.LoadLevel ("MainGame");
	}

	public void LoadStore() {
		Application.LoadLevel("Store");
	}
}
