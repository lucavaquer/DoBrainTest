using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    public static ObjectPooler SharedInstance;

    void Awake()
    {
        SharedInstance = this;
    }

    public Stack<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new Stack<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.transform.parent = GameObject.Find("Panel2").transform;
            obj.SetActive(false);
            pooledObjects.Push(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        return pooledObjects.Pop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
