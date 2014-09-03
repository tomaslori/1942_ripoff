using UnityEngine;
using System.Collections;

public class LevelStart : MonoBehaviour {

	public GameObject levelPrefab;
	private GameObject level;

	public void startGameWith( string aircraftName ) {
		level = Instantiate( levelPrefab, new Vector3(0, 0, 0), Quaternion.Euler(new Vector3(270.0f, 0, 0)) ) as GameObject;
		level.transform.parent = transform.parent;
		gameObject.SetActive (false);
		level.GetComponent<NewLevelManager> ().startScreen = this.gameObject;
		level.GetComponent<NewLevelManager> ().startGameWith (aircraftName);
	}

}
