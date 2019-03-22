using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    float actualX = -920.0f;

    GameObject[] levels = new GameObject[90];
    int loadedLevels = 0;

    void Start()
    {
        // Create pool
        this.GetComponent<ObjectPooler>().createPool();

        // Set initial screen buttons
        do
        {
            levels[loadedLevels] = this.GetComponent<ObjectPooler>().GetPooledObject();
            actualX += 60.0f;
            levels[loadedLevels].transform.localPosition = new Vector3(actualX, Random.Range(-70, 70), 0);
            // Set levelIndex variable
            levels[loadedLevels].GetComponent<Button>().levelIndex = loadedLevels + 1;
            levels[loadedLevels].GetComponentInChildren<Text>().text = levels[loadedLevels].GetComponent<Button>().levelIndex.ToString();
            // Set buttonColor variable
            levels[loadedLevels].GetComponent<Button>().buttonColor = new Color(Random.Range(0F, 1F), Random.Range(0, 1F), Random.Range(0, 1F));
            levels[loadedLevels].GetComponent<Image>().color = levels[loadedLevels].GetComponent<Button>().buttonColor;
            levels[loadedLevels].SetActive(true);
            loadedLevels += 1;
        } while (levels[loadedLevels - 1].GetComponentInParent<Canvas>().pixelRect.Contains(levels[loadedLevels - 1].transform.position));

    }

    public void whenScrollActive()
    {
        // Create new level button only when next level is in view
        if (levels[loadedLevels-1].GetComponentInParent<Canvas>().pixelRect.Contains(levels[loadedLevels-1].transform.position))
        {
            levels[loadedLevels] = this.GetComponent<ObjectPooler>().GetPooledObject();
            actualX += 60.0f;
            levels[loadedLevels].transform.localPosition = new Vector3(actualX, Random.Range(-70, 70), 0);
            levels[loadedLevels].GetComponent<Button>().levelIndex = loadedLevels + 1;
            levels[loadedLevels].GetComponentInChildren<Text>().text = levels[loadedLevels].GetComponent<Button>().levelIndex.ToString();
            levels[loadedLevels].GetComponent<Button>().buttonColor = new Color(Random.Range(0F, 1F), Random.Range(0, 1F), Random.Range(0, 1F));
            levels[loadedLevels].GetComponent<Image>().color = levels[loadedLevels].GetComponent<Button>().buttonColor;
            levels[loadedLevels].SetActive(true);
            loadedLevels += 1;
        }

        // Delete latest level button when previous level button disappear from view
        if (!levels[loadedLevels - 2].GetComponentInParent<Canvas>().pixelRect.Contains(levels[loadedLevels - 2].transform.position))
        {
            this.GetComponent<ObjectPooler>().backInPool(levels[loadedLevels-1]);
            actualX -= 60.0f;
            loadedLevels -= 1;
        }
    }
}
