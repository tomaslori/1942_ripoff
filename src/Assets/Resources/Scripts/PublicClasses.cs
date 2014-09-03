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
	public float spd, topSpd;
	public GunsData gData;
	
	public AircraftData (float spd, float topSpd, int def, GunsData gData) {
		health = 100;
		this.spd = spd;
		this.topSpd = topSpd;
		this.def = def;
		this.gData = gData;
	}
}

public class PublicClasses : MonoBehaviour {
	// empty container
}
