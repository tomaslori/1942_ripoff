using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectManagementPool
{
	
	private GameObject prefab;
	
	public List<GameObject> pooledObjects;

	public int bufferSize;

	protected GameObject containerObject;

	public ObjectManagementPool( GameObject prefab, int bufferSize = 10 )
	{
		this.prefab = prefab;

		this.bufferSize = bufferSize;

		containerObject = new GameObject(prefab.name + "Pool");
		
		pooledObjects = new List<GameObject>();
		
		for ( int n=0; n < bufferSize; n++)
		{
			GameObject newObj = MonoBehaviour.Instantiate(prefab, new Vector3(0, -3, 0), Quaternion.identity) as GameObject;
			Debug.Log("SuperDuper");
			newObj.name = prefab.name;
			PoolObject(newObj);
		}
	}
	
	public GameObject GetObject ( bool onlyPooled, Vector3 position = new Vector3(0f,-3f,0f), Quaternion rotation = Quaternion.identity )
	{
		if(pooledObjects.Count > 0)
		{
			GameObject pooledObject = pooledObjects[0];
			pooledObjects.RemoveAt(0);
			pooledObject.transform.parent = null;
			pooledObject.SetActive(true);
			Rigidbody2D objectBody = pooledObject.GetComponent<Rigidbody2D> ();
			objectBody.position = position;
			objectBody.rotation = rotation;

			return pooledObject;
		} else if(!onlyPooled) {
			return MonoBehaviour.Instantiate(prefab) as GameObject;
		}
		return null;
	}
	
	public void PoolObject ( GameObject obj )
	{
		obj.SetActive(false);
		obj.transform.parent = containerObject.transform;
		pooledObjects.Add(obj);
		return;
	}

	public List<GameObject> getAllObjects ()
	{
		return this.pooledObjects;
	}
	
}