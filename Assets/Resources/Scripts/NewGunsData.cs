using UnityEngine;
using System.Collections;

public class NewGunsData : MonoBehaviour
{
	private ObjectManagementPool projectilePool;

	private int numberOfShots;

	private int cooldown;


	public NewGunsData( GameObject prefab, int numberOfShots, int cooldown)
	{
		this.projectilePool = new ObjectManagementPool (prefab, numberOfShots);
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

