using UnityEngine;
using System.Collections;

public class Boundaries : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log (other.gameObject.name + " Enter");
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.name.StartsWith ("Square-Building")) {
			NewLevelManager nlm = FindObjectOfType (typeof(NewLevelManager)) as NewLevelManager;
			nlm.spawnStructure (13);
			nlm.poolStructure (other.gameObject);
		} else if (other.gameObject.name.StartsWith ("Projectile")) {
			PlayerController playerController = FindObjectOfType (typeof(PlayerController)) as PlayerController;
			playerController.poolBullet(other.gameObject);
		} else if (other.gameObject.name.StartsWith("Scouter")) {
			NewLevelManager nlm = FindObjectOfType (typeof(NewLevelManager)) as NewLevelManager;
			nlm.spawnEnemy (15);
			nlm.destroyEnemy (other.gameObject);
		}
	}

	void OnTriggerStay2D(Collider2D other) {
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
