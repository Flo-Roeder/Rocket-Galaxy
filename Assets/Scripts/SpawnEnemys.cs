using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{

    public GameObject[] enemys;
    public float spawnDelayMin;
    public float spawnDelayMax;
    public static float spawnFactor; // equals level from GameManager
    private float spawnCounter=0;
    [SerializeField]private float minX;
    [SerializeField]private float maxX;
    [SerializeField]private float minY;
    [SerializeField]private float maxY;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameStart)
        {
            if (spawnCounter <= 0)
            {
                Spawn();
                spawnCounter = Random.Range(spawnDelayMin, spawnDelayMax);
            }
            else
            {
                spawnCounter -= Time.deltaTime * spawnFactor;
            }
        }

    }

    private void Spawn()
    {
        int randEnemyInt = Random.Range(0, 11);
        int spawnEnemy;
        switch (randEnemyInt)
        {
            case <= 5:spawnEnemy = 0;
                break;
            case <=7: spawnEnemy = 1;
                break;
            case <=9: spawnEnemy = 2;
                break;
            case 10: spawnEnemy = 3;
                break;
            default: spawnEnemy = 0;
                break;
        }

        float randPosX = Random.Range(minX, maxX);
        float randPosY = Random.Range(minY, maxY);
        Vector3 randSpwanPoint = new(randPosX, randPosY, 0);
        if (spawnEnemy!=3)
        {
            Instantiate(enemys[spawnEnemy], randSpwanPoint, Quaternion.Euler(0, 0, 90));
        }
        else
        {
            Instantiate(enemys[spawnEnemy], randSpwanPoint,Quaternion.identity);
        }
    }

}
