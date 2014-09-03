using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class EnemyController : MonoBehaviour {
	
	protected Rigidbody2D body;
	protected float topSpd = 3.0f;
	protected float detectionRange = 5.0f;
	public static ObjectManagementPool buildings;

	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		Vector3 baseDir = patternMove ();
		List<GameObject> buildingList = buildings.getAllObjects ();
		Vector3 avoidance = avoidCollisions (new Vector2(body.position.x, body.position.y), buildingList);
		moveSelf (baseDir + avoidance);
	}

	void OnCollisionEnter2D(Collision2D other) {
		NewLevelManager nlm = FindObjectOfType(typeof(NewLevelManager)) as NewLevelManager;
		nlm.destroyEnemy(this.gameObject);
		nlm.spawnEnemy (15f);
	}
	
	void OnCollisionExit2D(Collision2D other) {
	}
	
	void OnCollisionrStay2D(Collision2D other) {
	}


	protected abstract Vector3 patternMove ();

	protected Vector3 avoidCollisions( Vector2 pos, List<GameObject> hazardousObjects ) {
		Vector2 avoidance = new Vector3 (0, 0, 0);

		if (hazardousObjects.Count == 0)
			return avoidance;

		List<Vector2> relevant = new List<Vector2> ();

		foreach( GameObject obj in hazardousObjects ) {
			Vector2 vec = pos - (Vector2)obj.GetComponent<Rigidbody2D>().position;
			if (vec.magnitude < detectionRange) 
				relevant.Add(vec);
		}


		foreach( Vector2 vec in relevant ) {
			avoidance = avoidance + vec.normalized * (1 -(vec.magnitude/detectionRange)) * topSpd;
		}

		return avoidance;
	}

	protected void moveSelf ( Vector3 dir ) {
		body.velocity = dir;
		body.rotation = 0.0f;
	}
}
