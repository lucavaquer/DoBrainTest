using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    public Stack<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    // Create pool of objects in a stack
   public void createPool()
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

    // Pop and return object from stack
    public GameObject GetPooledObject()
    {
        return pooledObjects.Pop();
    }

    // Push back object into stack
    public void backInPool(GameObject obj)
    {
        pooledObjects.Push(obj);
        obj.SetActive(false);
    }

}
