using UnityEngine;
using System.Collections;

public class NewLevelManager : MonoBehaviour
{
	private ObjectManagementPool enemyPool;

	private ObjectManagementPool buildingPool;

	// Use this for initialization
	void Start ()
	{
		this.enemyPool = new ObjectManagementPool(/* Enemy Prefab */, 15);
		this.buildingPool = new ObjectManagementPool(/* Building Prefab */, 15);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

