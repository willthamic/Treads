using UnityEngine;
using System.Collections;

public class PlayerFire : MonoBehaviour {

	private string name;
	private float lastTimeA;
	private float lastTimeB;
	private bool ai;

	public GameObject Bullet;
	GameObject BulletInstantiate;

	public GameObject Missile;
	GameObject MissileInstantiate;

	void Start () {
		name = transform.parent.name;
		ai = (name.Substring (0, 1) == "A") ? true : false;
		name = name.Substring(name.Length-1, 1);
		lastTimeA = Time.time;
		lastTimeB = Time.time;
	}
	
	void FixedUpdate () {
		if (!ai) {
			float fire = Input.GetAxis ("Fire" + name);
			if (fire == 1) {
				fireBullet ();
			}
			if (fire == -1) {
				fireMissile ();
			}
		}
	}

	public void fireBullet () {
		if (lastTimeA + 0.2f < Time.time) {
			BulletInstantiate = (GameObject)Instantiate (Bullet, transform.position, transform.rotation);
			BulletInstantiate.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (750, 0));
			lastTimeA = Time.time;
		}
	}

	public void fireMissile () {
		if (lastTimeB + 1f < Time.time) {
			MissileInstantiate = (GameObject)Instantiate (Missile, transform.position, transform.rotation);
			MissileInstantiate.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (250, 0));
			lastTimeB = Time.time;
		}
	}
}
