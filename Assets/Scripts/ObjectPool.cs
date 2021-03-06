using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	#region PRIVATE VARIABLES
	private Queue<GameObject> pool;
	private GameObject prefab;

	private Transform parent;
	#endregion

	#region CONSTRUCTOR
	// Create a new object pool.
	public ObjectPool(GameObject _prefab, int initialCapacity)
	{
		pool = new Queue<GameObject>();
		prefab = _prefab;
		parent = new GameObject(prefab.name + " Pool").transform;

		for (int i = 0; i < initialCapacity; i++)
		{
			GameObject obj = GameObject.Instantiate(prefab) as GameObject;
			obj.transform.parent = parent;

			pool.Enqueue(obj);
			obj.SetActive(false);
		}
	}
	#endregion

	// Spawn an object from the pool.
	public GameObject Spawn()
	{
		GameObject obj;

		if (pool.Count > 0)
			obj = pool.Dequeue();
		else
		{
			obj = GameObject.Instantiate(prefab) as GameObject;
			obj.transform.parent = parent;

		}

		obj.SetActive(true);
		float x = Random.Range(-8.4f,8.4f);
		float z = Random.Range(-9f,0f);
		obj.transform.position=obj.transform.position + new Vector3(x,0.0f,z);

		return obj;
	}

	public void Recycle(GameObject obj)
	{
		obj.SetActive(false);
		pool.Enqueue(obj);
	}
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
