using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    [SerializeField]
    private GameObject[] enemyReference;

    private GameObject spawnedEnemy;

    [SerializeField]
    private Transform leftSide, rightSide;

    private int randomIndex;
    private int randomSide;
    IEnumerator SpawnMonsters()
    {

        while (true)
        {

            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, enemyReference.Length);
            randomSide = Random.Range(0, 3);

            spawnedEnemy = Instantiate(enemyReference[randomIndex]);

            // left side
            if (randomSide == 0)
            {

                spawnedEnemy.transform.position = leftSide.position;
                spawnedEnemy.GetComponent<WalkingEnemyController>().speed = Random.Range(1, 8);

            }
           

        } // while loop

    }
}

