using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public Boundary bounds;
	public AircraftData data;
	//private ProjectileManager projManager;
	private Rigidbody2D body;
	private float delta = 0.0f; // Used for easier debugging

	void Start () {
		body = gameObject.GetComponent<Rigidbody2D> ();
		//projManager = new ProjectileManager ();
	}

	private void moveAircraft (float xMov, float yMov) {
		Vector3 mov = new Vector3 (xMov, yMov, 0.0f);
		body.velocity = mov * data.spd;
		
		body.position = new Vector3 (
			Mathf.Clamp (body.position.x, bounds.xMin, bounds.xMax), 
			Mathf.Clamp (body.position.y, bounds.yMin, bounds.yMax),
			0.0f
			);
	}

	void FixedUpdate () {
		moveAircraft (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));

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