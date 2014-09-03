using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewLevelManager : MonoBehaviour
{
	private ObjectManagementPool enemyPool;
	private ObjectManagementPool buildingPool;

	private AircraftManager aircraftManager;
	private PlayerController playerController;

	public GameObject cloudPrefab;
	private GameObject cloud;

	private Boundary bounds;

	public string aircraftName = "F-22B";
	private float backgroundSpeed = -0.02f, backgroundPosition = 0.0f;
	public GameObject startScreen;

	public GameObject lostGameLabel;
	
	private void initBoundaries () {
		bounds = new Boundary ();
		bounds.xMax = 10.5f;
		bounds.xMin = -10.5f;
		bounds.yMax = 4.1f;
		bounds.yMin = -4.1f;
	}

	private List<GameObject> loadBuildings () {
		List<GameObject> buildings = new List<GameObject> ();
		buildings.Add (Resources.Load ("Prefabs/Square-Building-1") as GameObject);
		buildings.Add (Resources.Load ("Prefabs/Square-Building-2") as GameObject);
		buildings.Add (Resources.Load ("Prefabs/Square-Building-3") as GameObject);
		buildings.Add (Resources.Load ("Prefabs/Square-Building-4") as GameObject);
		return buildings;
	}

	private void init()
	{
		initBoundaries ();

		this.buildingPool = new ObjectManagementPool(loadBuildings(), 10);
		EnemyController.buildings = this.buildingPool;

		List<GameObject> enemies = new List<GameObject> ();
		enemies.Add (Resources.Load ("Prefabs/Scouter") as GameObject);
		this.enemyPool = new ObjectManagementPool(enemies, 5);
		this.aircraftManager = new AircraftManager();

		GameObject player = MonoBehaviour.Instantiate (Resources.Load ("Prefabs/" + aircraftName) as GameObject) as GameObject;
		this.playerController = player.GetComponent<PlayerController> ();
		playerController.data = aircraftManager.getAircraft(aircraftName);
		playerController.bounds = this.bounds;

		cloud = Instantiate(cloudPrefab, new Vector3(-3.0f, -10.0f, -8.0f), Quaternion.identity) as GameObject;

		spawnStructure (7);
		spawnStructure (13);
		spawnStructure (19);
		spawnStructure (25);
		spawnEnemy (15);
		spawnEnemy (21);
		spawnEnemy (27);
		//enemyPool.getObject (true, new Vector2(0, 3));

	}

	public void startGameWith (string aircraftName) {
		this.aircraftName = aircraftName;
		init ();
	}

	void Update () {
	}
	
	void FixedUpdate () {
		moveBackground ();
	}

		private void moveBackground() {
		backgroundPosition += backgroundSpeed/5;
		cloud.transform.position = new Vector2 (cloud.transform.position.x, cloud.transform.position.y - backgroundSpeed/3);

		if (cloud.transform.position.y > 20.0f)
			cloud.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-20f, -12f), -8.0f);

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
		float x = Random.Range(-12f, 12f);
		buildingPool.getObject (true, new Vector2(x, height));
	}

	public void spawnEnemy (float height){
		float x = Random.Range(-12f, 12f);
		enemyPool.getObject (true, new Vector2(x, height));
	}

	public void poolStructure (GameObject structure) {
		buildingPool.poolObject (structure);
	}

	public void destroyEnemy (GameObject enemy) {
		enemyPool.poolObject (enemy);
	}

	public void restartGame() {
		StartCoroutine(LostGameGui());
	}

	private IEnumerator LostGameGui () {
		GameObject label = Instantiate (lostGameLabel) as GameObject;
		yield return new WaitForSeconds(2.0f);
		Destroy(label);

		Destroy(this.gameObject);
		this.buildingPool.recallObjects();
		Destroy (this.buildingPool.containerObject);
		this.enemyPool.recallObjects();
		Destroy (this.enemyPool.containerObject);
		this.playerController.bulletPool.recallObjects ();
		Destroy (this.playerController.bulletPool.containerObject);
		Destroy (this.playerController.gameObject);
		Destroy (this.cloud);
		this.startScreen.SetActive (true);
	}
}

