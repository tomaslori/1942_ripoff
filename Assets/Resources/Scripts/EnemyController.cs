using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class EnemyController : MonoBehaviour {
	
	protected Rigidbody2D body;
	//protected ObjectManagmentPool<Buildings> buildings;

	void Start () {

	}

	void Update () {
		Vector3 baseDir = patternMove (body);
		Vector3 avoidance; // = avoidCollisions (body.position, buildings.getList ());
		moveSelf (baseDir + avoidance);
	}

	protected abstract Vector3 patternMove ( Rigidbody2D body );

	protected Vector3 avoidCollisions( Vector3 pos, List<Vector3> hazardousObjects ) {
		Vector3 avoidance = new Vector3 (0, 0, 0);

		foreach( Vector3 vec in hazardousObjects )
			avoidance = avoidance + (pos-vec);

		return avoidance;
	}

	protected void moveSelf ( Vector3 dir ) {
		body.velocity = dir;
		body.rotation = dir;
	}
}
