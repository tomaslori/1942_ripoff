using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectManagementPool : MonoBehaviour
{
	
	private GameObject prefab;
	
	public List<GameObject> pooledObjects;

	public int bufferSize;

	protected GameObject containerObject;

	public ObjectManagementPool( GameObject prefab, int bufferSize = 10 )
	{
		this.prefab = prefab;

		this.bufferSize = bufferSize;
	}

	void Start ()
	{
		containerObject = new GameObject(prefab.name + "Pool");

		pooledObjects = new List<T>();
		
		for ( int n=0; n < bufferSize; n++)
		{
			GameObject newObj = Instantiate(prefab);
			newObj.name = prefab.name;
			PoolObject(newObj);
		}
	}
	
	public GameObject GetObject ( bool onlyPooled )
	{
		if(pooledObjects.Count > 0)
		{
			GameObject pooledObject = pooledObjects[0];
			pooledObjects.RemoveAt(0);
			pooledObject.transform.parent = null;
			pooledObject.SetActiveRecursively(true);
			
			return pooledObject;
		} else if(!onlyPooled) {
			return Instantiate(prefab) as GameObject;
		}
		return null;
	}
	
	public void PoolObject ( GameObject obj )
	{
		obj.SetActiveRecursively(false);
		obj.transform.parent = containerObject.transform;
		pooledObjects.Add(obj);
		return;
	}

	public List<GameObject> getAllObjects ()
	{
		return this.pooledObjects;
	}
	
}