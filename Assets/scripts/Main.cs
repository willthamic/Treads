using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	public GameObject Player;
	public GameObject menu;
	GameObject PlayerInstantiate;
	private bool isShowing;



	// Use this for initialization
	void Start () {
		PlayerInstantiate =(GameObject) Instantiate (Player, new Vector3(-3,0,0), Quaternion.Euler(0, 0, 180));
		PlayerInstantiate.name = "Player " + 1;
		PlayerInstantiate =(GameObject) Instantiate (Player, new Vector3(3,0,0), transform.rotation);
		PlayerInstantiate.name = "Player " + 2;
	}

}