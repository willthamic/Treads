using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonOnClick : MonoBehaviour {

	public GameObject loadingImage;
	public Text human;
	public Text AI;

	public GameObject MainMenu;
	public GameObject SumoMenu;

	void Start () {
		human = human.GetComponent<Text> ();
		AI = AI.GetComponent<Text> ();
		PlayerPrefs.SetInt ("humanPlayers", 2);
		PlayerPrefs.SetInt ("aiPlayers", 0);
		human.text = "Human Players: 2";
		AI.text = "AI Players: 0";
	}
	
	public void buttonClick (int scene) {
		loadingImage.SetActive(true);
		Application.LoadLevel(scene);
	}

	public void setHuman (int count) {
		human.text = "Human Players: " + count;
		PlayerPrefs.SetInt("humanPlayers", count);
	}

	public void setAI (int count) {
		AI.text = "AI Players: " + count;
		PlayerPrefs.SetInt("aiPlayers", count);
	}

	public void setMenu (GameObject menu) {
		MainMenu.SetActive (false);
		SumoMenu.SetActive (false);
		menu.SetActive (true);
	}
}
