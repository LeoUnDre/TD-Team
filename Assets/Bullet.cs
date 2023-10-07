using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log("XIZ");
            Destroy(other.gameObject);
        }
    }
}
