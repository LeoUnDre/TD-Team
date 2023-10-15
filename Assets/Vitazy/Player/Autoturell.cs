using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoturell : MonoBehaviour
{
    [SerializeField] Gun gun;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] public GameObject owner;
    [SerializeField] public GameObject ownerSpawn;
    [SerializeField] public GameObject[] LevelPrefab;
    [SerializeField] public int numTurrel;
    public int damage;
    public int level;

    [SerializeField] public GameObject[] LevelPrefabs;


    private void Start()
    {
        level = 1;
        damage = 25;
        bulletSpawn.transform.rotation = this.transform.rotation;
        transform.position = ownerSpawn.transform.position;
        transform.rotation = ownerSpawn.transform.rotation;
        gun = gameObject.GetComponent<Gun>();
    }





    private void Update()
    {
        transform.position = ownerSpawn.transform.position;
        transform.rotation = ownerSpawn.transform.rotation;
        gun.Shoot(this.gameObject, bulletSpawn);
        Debug.Log(level);
    }

    public Autoturell LevelUp()
    {
        GameObject newTurret = Instantiate(LevelPrefabs[level + 1], transform.position, transform.rotation);
        Autoturell newTurretComponent = newTurret.GetComponent<Autoturell>();
        newTurretComponent.owner = owner;
        newTurretComponent.ownerSpawn = ownerSpawn;
        newTurretComponent.level = level + 1;
        newTurretComponent.LevelPrefabs = LevelPrefabs;
        Destroy(gameObject);
        return newTurretComponent;
    }
}