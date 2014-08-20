using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

[System.Serializable]
public class GunsData {
	public float dmg, projSpd, offset;
	
	public GunsData (float dmg, float projSpd, float offset) {
		this.dmg = dmg;
		this.projSpd = projSpd;
		this.offset = offset;
	}
}


[System.Serializable]
public class AircraftData {
	public int health, def;
	public float spd;
	public GunsData gData;
	
	public AircraftData (float spd, int def, GunsData gData) {
		health = 100;
		this.spd = spd;
		this.def = def;
		this.gData = gData;
	}
}


[System.Serializable]
public class ProjectileManager {
	public Queue<GameObject> projectiles;
	public Vector3 posOutOfBounds = new Vector3(30.0f, 30.0f, 30.0f);
	
	public ProjectileManager (int startingQty) {
		projectiles = new Queue<GameObject> ();
		for ( int i=0; i<25 ; i++)
			projectiles.Enqueue (instantiateProj (posOutOfBounds, Quaternion.identity));
	}

	public void spawnProjectile (Vector3 pos, Quaternion rot, float projSpd) {
		GameObject proj;
		Rigidbody2D body;

		if (projectiles.Count == 0)
			projectiles.Enqueue (instantiateProj (pos, rot));

		proj = projectiles.Dequeue ();
		body = proj.GetComponent<Rigidbody2D> ();
		body.position = pos;
		//body.rotation = rot.toAngleAxis(rot);
		body.velocity = new Vector3 (0.0f, projSpd, 0.0f);

		return ;

	}

	public GameObject instantiateProj (Vector3 pos, Quaternion rot) {
		return GameObject.Instantiate(Resources.Load ("Prefabs/Projectile"), pos, rot) as GameObject;
	}
}


public class PublicClasses : MonoBehaviour {
	// empty container
}
