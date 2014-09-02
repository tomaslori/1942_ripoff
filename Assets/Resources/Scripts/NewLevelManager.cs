using UnityEngine;
using System.Collections;

public class NewLevelManager : MonoBehaviour
{
	private ObjectManagementPool enemyPool;

	private ObjectManagementPool buildingPool;

	private AircraftManager aircraftManager;

	private PlayerController playerController;

	public string aircraftName = "F-22B";
	private float backgroundSpeed = -0.02f, backgroundPosition = 0.0f;

	private float delta = 0.0f; // Used for easier debugging
	
	// Use this for initialization
	void Start ()
	{
		this.enemyPool = new ObjectManagementPool(Resources.Load ("Prefabs/Scouter") as GameObject, 15);
		this.buildingPool = new ObjectManagementPool(Resources.Load ("Prefabs/Square-Building-1") as GameObject, 15);
		this.aircraftManager = new AircraftManager();

		GameObject player = Resources.Load ("Prefabs/" + aircraftName) as GameObject;
		Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
		this.playerController = player.GetComponent<PlayerController> ();
		playerController.data = aircraftManager.getAircraft(aircraftName);

		spawnStructure (7);
		spawnStructure (13);
		spawnStructure (19);
		spawnStructure (25);
		enemyPool.GetObject (true, new Vector2(0, 3));

	}

	private void moveBackground() {
		backgroundPosition += backgroundSpeed/5;
		
		// avoids float growing and becoming inaccurate
		if (backgroundPosition < -1.0f)
			backgroundPosition += 1.0f;
		
		renderer.material.mainTextureOffset = new Vector2 (0.0f, backgroundPosition);

		foreach (GameObject building in buildingPool.getAllObjects()) {
			Rigidbody2D buildingBody = building.GetComponent<Rigidbody2D> ();
			buildingBody.MovePosition(new Vector2(buildingBody.position.x, buildingBody.position.y + backgroundSpeed));
		}
	}
	
	public void spawnStructure (float height){
		float x = Random.Range(-7f, 7f);
		buildingPool.GetObject (true, new Vector2(x, height));
	}
	
	void Update () {
		delta += Time.deltaTime;
		if (delta > 0.4f) {
			//Debug.Log("backpos = ( " + renderer.material.mainTextureOffset.x + ", " + backgroundPosition + " );");
			delta = 0.0f;
		} 
	}
	
	void FixedUpdate () {
		moveBackground ();
	}
}

