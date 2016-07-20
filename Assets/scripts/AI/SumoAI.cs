using UnityEngine;
using System.Collections;

public class SumoAI : MonoBehaviour {
	
	private Rigidbody2D rb;
	private Vector2 origin;
	public PlayerFire playerFire;
	
	private float lastTimeA;
	private float lastTimeB;
	private float lastTimeC;

	public GameObject Bullet;
	GameObject BulletInstantiate;
	public GameObject Missile;
	GameObject MissileInstantiate;

	public GameObject[] players;
	private GameObject player;

	private bool Active = true;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		origin = new Vector2 (0, 0);
		lastTimeA = Time.time;
		lastTimeB = Time.time;
		players = GameObject.FindGameObjectsWithTag("tank");
		player = players[Random.Range (0, players.Length)];

	}
	
	void FixedUpdate () {
		if (players.Length > 1) {

			// Creates an array of all tanks currently in the game and then picks a random one other than itself
			// Runs every five seconds of when current target is eliminated
			if (lastTimeC + 5 < Time.time || player == null) {
				players = GameObject.FindGameObjectsWithTag("tank");
				do {
					player = players[Random.Range (0, players.Length)];
				} while(gameObject == player && players.Length > 1);
				lastTimeC = Time.time;
			}

			// angleC - Current rotation angle on z axis
			// angleCfO - Angle to current position from origin
			// angleOfC - Angle to origin from current position
			// angleTfO = Angle to target from origin
			// angleTfC - Angle to target from current position
			float angleC = transform.rotation.eulerAngles.z;
			float angleCfO = vecAngle(to2D(transform.position));
			float angleOfC = vecAngle(-to2D(transform.position));
			float angleTfO = vecAngle(to2D(player.transform.position));
			float angleTfC = vecAngle(to2D(player.transform.position) - to2D(transform.position));

			// Checks ot see if within 1.5 units of origin
			if (inRange(origin, 1.5f) && player != null) {
				if (Mathf.Abs(Mathf.DeltaAngle(angleTfC,angleC)) < 15) {
					if (Random.Range(0,100-1) == 0)
						fireMissile();
					else
						fireBullet();
					float torque = (Mathf.DeltaAngle(angleTfC,angleC) > 0) ? -1 : 1;
					rb.AddTorque(torque);
				} else {
					float torque = (Mathf.DeltaAngle(angleTfC,angleC) > 0) ? -8 : 8;
					rb.AddTorque(torque);
				}
			} else if (!inRange(origin, 3f) && player != null && Time.timeSinceLevelLoad > 3) {
				float dodgeAngle = (Mathf.DeltaAngle(angleTfO,angleCfO) > 0) ? -60 : 60;
				if (Mathf.Abs(Mathf.DeltaAngle(angleOfC + 45,angleC)) < 15) {
					rb.AddRelativeForce(new Vector2(15,0));
				} else {
					float torque = (Mathf.DeltaAngle(angleOfC + 45,angleC) > 0) ? -4 : 4;
					rb.AddTorque(torque);
				}
			} else {
				if (Mathf.Abs(Mathf.DeltaAngle(angleOfC,angleC)) < 15) {
					rb.AddRelativeForce(new Vector2(15,0));
				} else {
					float torque = (Mathf.DeltaAngle(angleOfC,angleC) > 0) ? -4 : 4;
					rb.AddTorque(torque);
				}
			}
			if (Random.Range (0, 40 - 1) == 0) {
				rb.AddTorque(5);
			}
			if (Random.Range (0, 40 - 1) == 0) {
				rb.AddTorque(-5);
			}
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
