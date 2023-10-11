using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class SpawnMobs : MonoBehaviour
{
    [SerializeField] int count;
    [SerializeField] GameObject[] prefabEnemy;
    [SerializeField] GameObject[] prefabSpawn;
    [SerializeField] GameObject playerTarget;

    private float timeSpawn = 1f;

    private float timer;

    private void Start()
    {
        timer = timeSpawn;
        for (int i = 0; i < prefabEnemy.Length; i++)
        {
            prefabEnemy[i].GetComponent<Enemy>().player = playerTarget;
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && count != 0)
            {
                timer = timeSpawn;
                Vector3 pos = prefabSpawn[UnityEngine.Random.Range(0, prefabSpawn.Length)].GetComponent<Transform>().position;
                pos.x += Random.Range(3, 7);
                pos.z += Random.Range(3, 7);
                Instantiate(prefabEnemy[UnityEngine.Random.Range(0, prefabEnemy.Length - 1)], pos, Quaternion.identity);
                count--;
        }
    }
}

