using UnityEngine;
using System.Collections;

public class onClick : MonoBehaviour {

	public GameObject levelController;

	void OnMouseDown() {
		Debug.Log ("clicked " + gameObject.name);
		levelController.GetComponent<LevelStart>().startGameWith (gameObject.name);
	}
}
