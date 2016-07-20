using UnityEngine;
using System.Collections;

public class MainScreenAI : MonoBehaviour {

	private Rigidbody2D rb;
	private string name;
	private string name2;
	private Vector2 targetZone;
	private GameObject playerFire;
	private GameObject otherPlayer;

	private float lastTimeA;
	private float lastTimeB;
	private float lastTimeC;
	private int stage;

	public GameObject Bullet;
	GameObject BulletInstantiate;
	public GameObject Missile;
	GameObject MissileInstantiate;

	private string lastmsg;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		name = gameObject.name;
		name = name.Substring(name.Length-1, 1);
		if (name == "1") {
			stage = 0;
			targetZone = new Vector2(-6,1);
			name2 = "2";
			playerFire = GameObject.Find("BulletSpawn 1");
			lastTimeC = Time.time - 2.5f;
		} else {
			stage = 2;
			targetZone = new Vector2(-2,-3);
			name2 = "1";
			playerFire = GameObject.Find("BulletSpawn 2");
			lastTimeC = Time.time;
		}
		otherPlayer = GameObject.Find ("Player " + name2);
		lastTimeA = Time.time;
		lastTimeB = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float angleTank = transform.rotation.eulerAngles.z;
		if (inRange(targetZone, 0.5f)) { // in safe zone
			float angleTarget = vecAngle(to2D(otherPlayer.transform.position) - to2D(transform.position));
			if (Mathf.Abs(Mathf.DeltaAngle(angleTarget,angleTank)) < 15) {
				if (Random.Range(0,100-1) == 0)
					fireMissile();
				else
					fireBullet();
				float torque = (Mathf.DeltaAngle(angleTarget,angleTank) > 0) ? -1 : 1;
				rb.AddTorque(torque);
			} else {
				float torque = (Mathf.DeltaAngle(angleTarget,angleTank) > 0) ? -8 : 8;
				rb.AddTorque(torque);
			}
		} else { // not in safe zone
			float angleZone = vecAngle(targetZone - to2D(transform.position));
			if (Mathf.Abs(Mathf.DeltaAngle(angleZone,angleTank)) < 15) {
				rb.AddRelativeForce(new Vector2(25,0));
			} else {
				float torque = (Mathf.DeltaAngle(angleZone,angleTank) > 0) ? -8 : 8;
				rb.AddTorque(torque);
			}
		}

		if (lastTimeC + 5 < Time.time) {
			if (stage == 0) {
				targetZone = new Vector2(-6,1);
				stage++;
			} else if (stage == 1) {
				targetZone = new Vector2(-2,1);
				stage++;
			} else if (stage == 2) {
				targetZone = new Vector2(-2,-3);
				stage++;
			} else if (stage == 3) {
				targetZone = new Vector2(-5,-3);
				stage = 0;
			}
			lastTimeC = Time.time;
		}
	}

	bool inRange (Vector2 target, float range) {
		Vector2 temp = to2D (transform.position) - target;
		if (Mathf.Abs(temp.magnitude) < range) {
			return true;
		} else {
			return false;
		}
	}

	bool inAngle (float angle1, float angle2, float range) {
		if (Mathf.Abs(Mathf.DeltaAngle(angle1,angle2)) < range/2)
			return true;
		else
			return false;
	}

	Vector2 to2D (Vector3 temp) {
		return new Vector2 (temp.x, temp.y);
	}

	float vecAngle (Vector2 angle1) {
		if (angle1.x == 0) {
			if (angle1.y > 0) 
				return 90;
			else
				return 270;
		}
		float angle = Mathf.Rad2Deg*Mathf.Atan(angle1.y/angle1.x);
		angle = (angle1.x < 0) ? angle + 180 : angle;
		angle = (angle1.x > 0 && angle1.y < 0) ? angle + 360 : angle;
		return angle;
	}
	
	void log (string message) {
		if (message != lastmsg) {
			Debug.Log (message);
		}
		lastmsg = message;
	}

	void fireBullet () {
		if (lastTimeA + 0.3f < Time.time) {
			BulletInstantiate = (GameObject)Instantiate (Bullet, playerFire.transform.position, transform.rotation);
			BulletInstantiate.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (500, 0));
			lastTimeA = Time.time;
		}
	}

	void fireMissile () {
		if (lastTimeB + 0.5f < Time.time) {
			MissileInstantiate = (GameObject)Instantiate (Missile, playerFire.transform.position, transform.rotation);
			MissileInstantiate.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (250, 0));
			lastTimeB = Time.time;
		}
	}

}
