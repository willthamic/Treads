using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SumoMain : MonoBehaviour {
	
	public GameObject Player;
	GameObject PlayerInstantiate;

	public GameObject AI;
	GameObject AIInstantiate;

	public GameObject winScreen;
	public Text winScreenText;
	
	private Vector3[] position;
	private float[] angle;
	private int[] scramble;

	// Use this for initialization
	void Start () {
		int aiPlayers = PlayerPrefs.GetInt ("aiPlayers");
		int humanPlayers = PlayerPrefs.GetInt ("humanPlayers");
		int totalPlayers = aiPlayers + humanPlayers;
		
		position = new Vector3[totalPlayers];
		angle = new float[totalPlayers];
		scramble = new int[totalPlayers];
		for (int i = 0; i < totalPlayers; i++) {
			float j = i;
			angle[i] = (j/totalPlayers)*360;
			position[i] = new Vector3(3*Mathf.Cos(angle[i]*0.0174533f),3*Mathf.Sin(angle[i]*0.0174533f),0);
			scramble[i] = i;
		}
		scramble = reshuffle (scramble);
		for (int i = 0; i < humanPlayers; i++) {
			PlayerInstantiate =(GameObject) Instantiate (Player, position[scramble[i]], Quaternion.Euler(0, 0, angle[scramble[i]]));
			PlayerInstantiate.name = "Player " + (i+1);
			PlayerInstantiate.GetComponentInChildren<Text>().text = (i+1).ToString();
		}
		for (int i = 0; i < aiPlayers; i++) {
			AIInstantiate =(GameObject) Instantiate (AI, position[scramble[i+humanPlayers]], Quaternion.Euler(0, 0, angle[scramble[i+humanPlayers]]));
			AIInstantiate.name = "AI " + (i+1+humanPlayers);
			AIInstantiate.GetComponentInChildren<Text>().text = (i+1+humanPlayers).ToString();
		}
	}

	int[] reshuffle(int[] array) {
		for (int t = 0; t < array.Length; t++){
			int tmp = array[t];
			int r = Random.Range(t, array.Length);
			array[t] = array[r];
			array[r] = tmp;
		}
		return array;
	}

	void FixedUpdate () {
		if(GameObject.FindGameObjectsWithTag("tank").Length == 1) {
			winScreenText.text = "Winner: " + GameObject.FindGameObjectsWithTag("tank")[0].name;
			winScreen.SetActive(true);
		}
	}

}