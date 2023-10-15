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
    [SerializeField] GameObject prefabBoss;
    [SerializeField] GameObject playerTargetBoss;
    [SerializeField] GameObject objectWin;

    private float timeSpawn = 1f; //время спавна мобов

    private float timer;

    private void Start()
    {
        timer = timeSpawn;
        prefabBoss.GetComponent<RangeEnemy>().objectWin = objectWin;
        prefabBoss.GetComponent<RangeEnemy>().target = playerTargetBoss;
        prefabBoss.GetComponent<RangeEnemy>().player = playerTarget;
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

            Instantiate(prefabEnemy[UnityEngine.Random.Range(0, prefabEnemy.Length)], pos, Quaternion.identity);
            count--;
            }

            else if(count == 0)
            {
                Vector3 pos = prefabSpawn[2].GetComponent<Transform>().position;
                Instantiate(prefabBoss, pos, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
}

