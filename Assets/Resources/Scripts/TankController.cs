using UnityEngine;
using System.Collections;

public class TankController : EnemyController {

	Vector3 patternMove ( Rigidbody2D body ) {
		float x = Mathf.Round (Mathf.Sin (Time.deltaTime));
		float y = -Mathf.Abs (Mathf.Round (Mathf.Sin (Time.deltaTime)));
		return new Vector3( x, y, 0.0f );
	}

}
