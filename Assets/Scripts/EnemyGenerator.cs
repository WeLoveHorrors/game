using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public List<GameObject> enemyToSpawn;
    static int generated = 0;
    public int enemiesToSpawn = 10;
    public int perGeneratorAddEnemy = 2;
    float xPos;
    float zPos;
    int enemyCount;
    public float StartPosX = 8;
    public float StartPosZ = 8;
    bool isSpawned = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !isSpawned)
        {
            isSpawned = true;
            StartCoroutine(EnemyDrop());
        }
    }
    IEnumerator EnemyDrop()
    {
        generated++;
        while (enemyCount < enemiesToSpawn + (generated-1) * perGeneratorAddEnemy)
        {
            xPos = Random.Range(StartPosX*-1f, StartPosX);
            zPos = Random.Range(StartPosZ*-1f, StartPosZ);
            Instantiate(enemyToSpawn[Random.Range(0, enemyToSpawn.Count)], transform.position + new Vector3(xPos, 0f, zPos), transform.rotation);
            yield return new WaitForSeconds(0.1f);
            enemyCount++;
        }
    }
}
