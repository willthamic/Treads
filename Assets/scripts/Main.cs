using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	public GameObject Player;
	GameObject PlayerInstantiate;

	// Use this for initialization
	void Start () {
		for (int i = 1; i <= 2; i++) {
			PlayerInstantiate =(GameObject) Instantiate (Player, new Vector3(i*2-5,0,0), transform.rotation);
			PlayerInstantiate.name = "Player " + i;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}
}
