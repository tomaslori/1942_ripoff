using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public AircraftData data;
	//private ProjectileManager projManager;
	private Rigidbody2D body;
	public Boundary bounds;

	public ObjectManagementPool bulletPool;

	void OnCollisionEnter2D(Collision2D other) {
		NewLevelManager nlm = FindObjectOfType(typeof(NewLevelManager)) as NewLevelManager;
		nlm.restartGame ();
	}

	void Start () {
		bulletPool = new ObjectManagementPool(Resources.Load ("Prefabs/Projectile") as GameObject, 50);
		body = gameObject.GetComponent<Rigidbody2D> ();
		bounds.xMax = 10.5f;
		bounds.xMin = -10.5f;
		bounds.yMax = 4.1f;
		bounds.yMin = -4.1f;
		//projManager = new ProjectileManager ();
	}

	private void moveAircraft (Vector2 dir) {
		body.AddForce (dir * data.spd);

		if (body.velocity.magnitude > data.topSpd)
			body.velocity = body.velocity.normalized * data.topSpd;
	}

	void FixedUpdate () {
		moveAircraft ( new Vector2( Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")) );
	}

	private void shoot () {
		data.gData.offset = -data.gData.offset;
		Vector3 pos = new Vector3 (body.position.x + data.gData.offset, body.position.y, 2.0f);
		Quaternion rot = new Quaternion (0.0f, 0.0f, 90.0f, 90.0f);

		GameObject proj = bulletPool.getObject (true, new Vector2(body.position.x, body.position.y), 90f);
		proj.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0.0f, data.gData.projSpd, 0.0f);
	}

	void Update () {
		if (Input.GetKeyDown ("space"))
			shoot();

		body.position = new Vector3 (Mathf.Clamp (body.position.x, bounds.xMin, bounds.xMax), Mathf.Clamp (body.position.y, bounds.yMin, bounds.yMax), 0.0f);
	}

	public void poolBullet (GameObject bullet) {
		this.bulletPool.poolObject (bullet);
	}
	
}