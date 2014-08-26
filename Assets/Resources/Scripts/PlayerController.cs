using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public AircraftData data;
	//private ProjectileManager projManager;
	private Rigidbody2D body;
	private float delta = 0.0f; // Used for easier debugging

	void Start () {
		body = gameObject.GetComponent<Rigidbody2D> ();
		//projManager = new ProjectileManager ();
	}

	private void moveAircraft (Vector2 dir) {
		body.AddForce (dir * data.spd);

		if (body.velocity.magnitude > data.topSpd)
			body.velocity = body.velocity.normalized * data.topSpd;
	}

	void FixedUpdate () {
		moveAircraft ( new Vector2( Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")) );

		// debugging
		delta += Time.deltaTime;
		if (delta > 1.0f) {
			//Debug.Log ("pos( " + body.position.x + ", " + body.position.y + " );");
			delta = 0.0f;
		}
	}

	private void shoot () {
		data.gData.offset = -data.gData.offset;
		Vector3 pos = new Vector3 (body.position.x + data.gData.offset, body.position.y, 2.0f);
		Quaternion rot = new Quaternion (0.0f, 0.0f, 90.0f, 90.0f);

		GameObject proj = Instantiate(Resources.Load ("Prefabs/Projectile"), pos, rot) as GameObject;
		proj.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0.0f, data.gData.projSpd, 0.0f);
	}

	void Update () {
		if (Input.GetKeyDown ("space"))
			shoot();
	}
	
}