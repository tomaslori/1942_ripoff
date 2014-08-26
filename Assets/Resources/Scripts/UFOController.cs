using UnityEngine;
using System.Collections;

public class UFOController : EnemyController {
	public float rad = 3.0f;

	protected override Vector3 patternMove () {
		float x = Mathf.Sin(Time.deltaTime)*rad;
		float y = topSpd / 2.0f + Mathf.Cos(Time.deltaTime)*rad;
		return new Vector3( x, y, 0.0f );
	}

}
