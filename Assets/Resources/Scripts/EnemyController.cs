using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class EnemyController : MonoBehaviour {
	
	protected Rigidbody2D body;
	protected float topSpd = 3.0f;
	public ObjectManagementPool buildings;

	void Start () {

	}

	void Update () {
		Vector3 baseDir = patternMove ();
		Vector3 avoidance = avoidCollisions (body.position, buildings.getAllObjects());
		moveSelf (baseDir /*+ avoidance*/);
	}

	protected abstract Vector3 patternMove ();

	protected Vector3 avoidCollisions( Vector3 pos, List<GameObject> hazardousObjects ) {
		Vector3 avoidance = new Vector3 (0, 0, 0);

		foreach( GameObject obj in hazardousObjects )
			avoidance = avoidance + ( pos - obj.GetComponent<Rigidbody2D>().position );

		return avoidance;
	}

	protected void moveSelf ( Vector3 dir ) {
		body.velocity = dir;
		body.rotation = 0.0f;
	}
}
