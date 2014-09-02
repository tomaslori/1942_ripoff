using UnityEngine;
using System.Collections;

public class ScouterController : EnemyController {

	protected override Vector3 patternMove () {
		float x = 0.0f;
		float y = -topSpd / 2.0f;
		return new Vector3( x, y, 0.0f );
	}

}
