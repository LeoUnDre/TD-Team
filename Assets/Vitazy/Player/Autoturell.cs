using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoturell : MonoBehaviour
{
    [SerializeField] GameObject gun;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] GameObject owner;
    [SerializeField] GameObject[] ownerSpawn;

    public GameObject target = null;
    public int damage;

    private void Start()
    {
        damage = 25;
        this.transform.position = ownerSpawn[0].transform.position;
        this.transform.rotation = ownerSpawn[0].transform.rotation;
        bulletSpawn.transform.rotation = this.transform.rotation;
    }





    private void Update()
    {
        transform.position = ownerSpawn[0].transform.position; 
        this.transform.rotation = ownerSpawn[0].transform.rotation;
        bulletSpawn.transform.rotation = this.transform.rotation;
        if (target != null) 
        {
            if (target.GetComponent<MeleeEnemy>() != null)
            {
                Vector3 lookDir = target.GetComponent<Transform>().position;

                gun.GetComponent<Gun>().Shoot(this.gameObject, bulletSpawn);

                Debug.Log(lookDir);
            }
            else if(target.GetComponent<RangeEnemy>() != null)
            {

            }
        }
    }
}
