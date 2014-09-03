using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public string aircraftName = "F-22B";
	public Dictionary <string, AircraftData> aircrafts;
	private Boundary bounds;
	private float backgroundSpeed = -0.02f, backgroundPosition = 0.0f;
	private float delta = 0.0f; // Used for easier debugging

	private void initAircrafts () {
		aircrafts = new Dictionary<string, AircraftData> ();
		aircrafts.Add("F-22B",   new AircraftData (7.0f, 11.0f,  1, new GunsData (1.75f, 8.0f, 0.25f)));
		aircrafts.Add("F-35D",   new AircraftData (4.0f, 7.0f,  1, new GunsData (1.5f, 6.0f, 0.1f)));
		aircrafts.Add("FA-28A",  new AircraftData (5.5f, 9.0f,  2, new GunsData (2.5f, 6.5f, 0.2f)));
		aircrafts.Add("MiG-51",  new AircraftData (4.0f, 6.5f,  3, new GunsData (2.0f, 5.25f, 0.25f)));
		aircrafts.Add("MiG-51S", new AircraftData (4.0f, 6.5f,  1, new GunsData (5.0f, 5.25f, 0.25f)));
		aircrafts.Add("SR-91A",  new AircraftData (2.75f, 4.5f, 5, new GunsData (1.0f, 4.0f, 0.4f)));
	}
	
	private void initBoundaries () {
		bounds = new Boundary ();
		bounds.xMax = 7.7f;
		bounds.xMin = -7.7f;
		bounds.yMax = 4.1f;
		bounds.yMin = -4.1f;
	}

	void Start () {
		initAircrafts ();
		initBoundaries ();
		GameObject player = Resources.Load ("Prefabs/" + aircraftName) as GameObject;
		Instantiate(player, new Vector3(0, -3, 0), Quaternion.identity);
		PlayerController script = player.GetComponent<PlayerController> ();
		script.data = aircrafts[aircraftName];
	}

	private void moveBackground() {
		backgroundPosition += backgroundSpeed;

		// avoids float growing and becoming inaccurate
		if (backgroundPosition < -1.0f)
			backgroundPosition += 1.0f;
		
		renderer.material.mainTextureOffset = new Vector2 (0.0f, backgroundPosition);
	}

	private void spawnStructure (float spawnTime){
		return ;
	}

	void Update () {
		delta += Time.deltaTime;
		if (delta > 0.4f) {
			spawnStructure(Random.Range (0.5f, 2.0f));
			Debug.Log("backpos = ( " + renderer.material.mainTextureOffset.x + ", " + backgroundPosition + " );");
			delta = 0.0f;
		} 
	}

	void FixedUpdate () {
		moveBackground ();
	}
}
