using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField]public GameObject objbullet;

    public GameObject objclone;
    public int power = 1000;

    private float shootCooldow;
    private float startShootCooldown = 2f;

    public void Shoot(GameObject types, Transform bulletSpawner)
    {
        if (types.GetComponent<TowerControl>() != null)
        {
            objbullet.GetComponent<Bullet>().isEnemy = false;
            Ray ray = new Ray(bulletSpawner.position, bulletSpawner.forward);
            RaycastHit hit;
            float shootdistance = 20f;
            if (Physics.Raycast(ray, out hit, shootdistance))
                shootdistance = hit.distance;

            objclone = Instantiate(objbullet, bulletSpawner.position, Quaternion.identity);
            objclone.GetComponent<Rigidbody>().AddForce(bulletSpawner.transform.forward * power);
            Destroy(objclone, 10);

            Debug.DrawRay(ray.origin, ray.direction * shootdistance, Color.blue, 1);
        }
        else if (types.GetComponent<RangeEnemy>() != null)
        {
            if (shootCooldow <= 0)
            {
                objbullet.GetComponent<Bullet>().isEnemy = true;
                objclone = Instantiate(objbullet, bulletSpawner.position, Quaternion.identity);
                objclone.GetComponent<Rigidbody>().AddForce(bulletSpawner.transform.forward * power);
                Destroy(objclone, 10);
                shootCooldow = startShootCooldown;
            }

            shootCooldow -= Time.deltaTime;
        }


    }
}
