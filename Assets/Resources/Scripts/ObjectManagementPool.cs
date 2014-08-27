using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectManagementPool
{
	
	private GameObject prefab;
	
	public List<GameObject> pooledObjects;

	public List<GameObject> activeObjects;

	public int bufferSize;

	protected GameObject containerObject;

	public ObjectManagementPool( GameObject prefab, int bufferSize = 10 )
	{
		this.prefab = prefab;

		this.bufferSize = bufferSize;

		containerObject = new GameObject(prefab.name + "Pool");
		
		pooledObjects = new List<GameObject>();

		activeObjects = new List<GameObject>();

		for ( int n=0; n < bufferSize; n++)
		{
			GameObject newObj = MonoBehaviour.Instantiate(prefab, new Vector3(0, -3, 0), Quaternion.identity) as GameObject;
			Debug.Log("SuperDuper");
			newObj.name = prefab.name;
			PoolObject(newObj);
		}
	}
	
	public GameObject GetObject ( bool onlyPooled, Vector2 position, float rotation = 0f )
	{
		if(pooledObjects.Count > 0)
		{
			GameObject pooledObject = pooledObjects[0];
			pooledObjects.RemoveAt(0);
			activeObjects.Add(pooledObject);
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
		activeObjects.Remove (obj);
		return;
	}

	public List<GameObject> getAllObjects ()
	{
		return activeObjects;
	}
	
}