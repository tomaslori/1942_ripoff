using UnityEngine;
using System.Collections;

public class ProjectileManager : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other) {
		PlayerController playerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;
		playerController.poolBullet(this.gameObject);
		if (other.gameObject.name == "Scouter") {
			NewLevelManager nlm = FindObjectOfType(typeof(NewLevelManager)) as NewLevelManager;
			nlm.destroyEnemy(other.gameObject);
			nlm.spawnEnemy(15f);
		}
	}
	
	void OnCollisionExit2D(Collision2D other) {
	}
	
	void OnCollisionrStay2D(Collision2D other) {
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
