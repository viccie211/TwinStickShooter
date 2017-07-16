using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour
{

    // Use this for initialization
    public int tick = 0;
    public float chance = 0.0f;

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
        if (GameObject.FindObjectsOfType(typeof(Enemy)).Length < 60)
        {
            chance = 1 - (2 / (Mathf.Exp(0.00005f * tick) + 1));
            float usedChance;
            if (chance > 0.1f)
            {
                usedChance = chance;
            }
            else
            {
                usedChance = 0.01f;
            }
            float act = Random.Range(0f, 1f);
            if (act <= usedChance)
            {
                Transform spawnlocation = spawnlocations[Random.Range(0, spawnlocations.Length)];
                spawnedEnemy = (GameObject)Instantiate(Resources.Load("Placeholder_enemy"));
                spawnedEnemy.transform.position = spawnlocation.position;
                spawnedEnemy.transform.rotation = spawnlocation.rotation;
            }
        }
        tick++;
    }
}
