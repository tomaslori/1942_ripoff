using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectManagementPool
{
	
	private List<GameObject> prefabs;
	
	public List<GameObject> pooledObjects;

	public List<GameObject> activeObjects;

	public int bufferSize;

	protected GameObject containerObject;

	public ObjectManagementPool( List<GameObject> prefabs, int bufferSize = 10 )
	{
		this.prefabs = prefabs;

		this.bufferSize = bufferSize;

		containerObject = new GameObject(prefabs[0].name + "Pool");
		containerObject.transform.position = new Vector2 (-1000f, -1000f);

		pooledObjects = new List<GameObject>();

		activeObjects = new List<GameObject>();
		while (pooledObjects.Count < bufferSize) {
			for (int i=0; i < prefabs.Count; i++) {
				GameObject newObj = MonoBehaviour.Instantiate (prefabs [i], new Vector3 (0, -3, 0), Quaternion.identity) as GameObject;
				newObj.name = prefabs[i].name;
				poolObject (newObj);
				if (pooledObjects.Count == bufferSize) {
					break;
				}
			}
		}
	}
	
	public GameObject getObject ( bool onlyPooled, Vector2 position, float rotation = 0f )
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
			return MonoBehaviour.Instantiate(prefabs[0]) as GameObject;
		}
		return null;
	}
	
	public void poolObject ( GameObject obj )
	{
		obj.SetActive(false);
		obj.transform.position = containerObject.transform.position;
		pooledObjects.Add(obj);
		activeObjects.Remove (obj);
		return;
	}

	public List<GameObject> getAllObjects ()
	{
		return activeObjects;
	}
	
}