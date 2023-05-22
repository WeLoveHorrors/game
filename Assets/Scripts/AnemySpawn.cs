using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnemySpawn : MonoBehaviour
{
    public GameObject[] anemyes;
    private GameObject obj;
    public bool gg = true;
    public void SpawnEnemy(string name)
    {
        foreach (var item in anemyes)
        {
            if (item.name == name)
            {
                obj = item;
            }
        }
        if (gg == true)
        {
            GameObject impact = Instantiate(obj, new Vector3(500f, 0f, 200f), Quaternion.LookRotation(new Vector3(0f, 0f, 0f)));
            gg = false;
        }
        gg=true;


    }
    public void IsAnemyDead(bool IsAlive, string name)
    {
        if (IsAlive == false)
        {
            SpawnEnemy(name);
            gg = false;
        }
        else
        {
            Debug.Log("Anamy is Alive");
        }
    }
}
