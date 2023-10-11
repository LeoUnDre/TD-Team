using System.Collections.Generic;
using UnityEngine;

public class TowerControl : MonoBehaviour
{
    [SerializeField] Gun gun;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] GameObject gameSpawn;
    private Camera _cam;

    public int HP = 3;

    Vector3 lookPos;

    private void Awake()
    {
        _cam = Camera.main;
    }
    private void Start()
    {
       
    }

    

    private void Update()
    {
        Mover();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gun.Shoot(this.gameObject, bulletSpawn);
        }
        if(HP == 0)
        {
            GameOver();
        }
    }

    private void Mover()
    {
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            lookPos = hit.point;
        }


        Vector3 lookDir = lookPos - transform.position;
        lookDir.y = 0;
        transform.LookAt(transform.position + lookDir, Vector3.up);
    }

    private void GameOver()
    {
        List<Enemy> enemiesList = new List<Enemy>(FindObjectsOfType<Enemy>());
        Enemy[] enemiesArray = enemiesList.ToArray();

        for (int i = 0; i < enemiesArray.Length; i++)
        {
            Destroy(enemiesArray[i]);
        }

        Destroy(gameSpawn);
        Destroy(gameObject);
    }

    public void Takedamage()
    {
        HP -= 1;
        if(HP == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
