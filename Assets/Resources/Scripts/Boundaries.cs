using UnityEngine;
using System.Collections;

public class Boundaries : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log (other.gameObject.name + " Enter");
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.name == "Square-Building-1") {
			NewLevelManager nlm = FindObjectOfType(typeof(NewLevelManager)) as NewLevelManager;
			nlm.spawnStructure(7);
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		Debug.Log (other.gameObject.name + " Stay");
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
