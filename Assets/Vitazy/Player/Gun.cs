using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField]public Transform bulletSpawner;
    [SerializeField]public GameObject objbullet;

    public GameObject objclone;
    public int power = 500;

    public void Shoot()
    {
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
}
