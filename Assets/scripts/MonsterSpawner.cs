using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] monster;
    int randomSpawnPoint, randomMonster;
    public static bool spawnAllowed;
    public float monsterSpawnSpeed;


    // Start is called before the first frame update
    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnMonster", 0f, monsterSpawnSpeed);
    }

    void SpawnMonster()
    {
        if(spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomMonster = Random.Range(0, monster.Length);
            Instantiate(monster[randomMonster], spawnPoints[randomSpawnPoint].position,
                Quaternion.identity);
        }
    }    

    // Update is called once per frame
    void Update()
    {
        
    }
}
