using UnityEngine;
using System.Collections.Generic;

public class SpawnEnemies : MonoBehaviour
{

    // Use this for initialization
    public int wave=1;
    public int spawnedThisWave = 0;
    public int spawnAtSameTime = 4;
    public int maxAlive = 100;
    public int tick = 25;
    public int totalThisWave = 2;
    public Transform[] spawnlocations;
    public GameObject spawnedEnemy;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if(tick>0)
        {
            tick--;
        }
        else
        {
            spawnWave();
            tick = 25;
        }

    }

    void spawnWave()
    {
        float w = (float)wave;
        float wsqd = Mathf.Pow(w,2f);
        totalThisWave = (int)Mathf.Ceil(0.5f * wsqd);
        if (GameObject.FindObjectsOfType(typeof(Enemy)).Length < maxAlive)
        {
            if (spawnedThisWave < totalThisWave)
            {
                int i = 0;
                List<Transform> spawnLocationsList = new List<Transform>(spawnlocations);
                while (spawnedThisWave < totalThisWave && i < spawnAtSameTime)
                {
                    int index = Random.Range(0, spawnLocationsList.Count);
                    Transform spawnlocation = spawnLocationsList[index];
                    spawnedEnemy = (GameObject)Instantiate(Resources.Load("Placeholder_enemy"));
                    spawnedEnemy.transform.position = spawnlocation.position;
                    spawnedEnemy.transform.rotation = spawnlocation.rotation;
                    spawnLocationsList.Remove(spawnlocation);
                    spawnedThisWave++;
                    i++;
                }
            }
        }
    }

    public void advanceWave()
    {
        wave++;
        spawnedThisWave = 0;
        tick = 70;
    }
}
