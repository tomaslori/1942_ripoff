using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewGunsData
{
	private ObjectManagementPool projectilePool;

	private int numberOfShots;

	private int cooldown;


	public NewGunsData( GameObject prefab, int numberOfShots, int cooldown)
	{
		List<GameObject> prefabs = new List<GameObject> ();
		prefabs.Add (prefab);
		this.projectilePool = new ObjectManagementPool (prefabs, numberOfShots);
		this.cooldown = cooldown;
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

