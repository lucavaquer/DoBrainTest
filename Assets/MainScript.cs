using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    float actualX = -920.0f;

    void Start()
    {
        // Create pool
        this.GetComponent<ObjectPooler>().createPool();

        // Set initial screen buttons
        for (int i = 0; i < 4; i++)
        {
            GameObject level = this.GetComponent<ObjectPooler>().GetPooledObject();
            actualX += 75.0f;
            level.transform.localPosition = new Vector3(actualX, Random.Range(-70, 70), 0);
            level.SetActive(true);
        }

    }

}
