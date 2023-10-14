using System.Collections.Generic;
using UnityEngine;

public class TowerControl : MonoBehaviour
{
    [SerializeField] Transform baseTurrel;
    [SerializeField] GameObject gun;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] GameObject gameSpawn;
    [SerializeField] GameObject platform;
    [SerializeField] public GameObject[] turrelSpawn;
    private Camera _cam;
    private float rotationSpeed = 10.0f;

    public int HP;

    public int MaxHP = 100;
    public int damage = 30;

    private float rotationAmount;
    Vector3 lookPos;
    private bool isPlatformRotate;

    private void Awake()
    {
        _cam = Camera.main;
    }
    private void Start()
    {
        HP = MaxHP;
        gun.transform.rotation = Quaternion.Euler(-90, 0f, 0f);
        platform.transform.rotation = Quaternion.Euler(-90, 0f, 0f);
    }



    private void Update()
    {
        Mover();

        if (Input.GetKey(KeyCode.Q))
        {
            rotationAmount = rotationSpeed;
            isPlatformRotate = true;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotationAmount = -rotationSpeed;
            isPlatformRotate = true;
        }

        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.E)) 
        {
            isPlatformRotate = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gun.GetComponent<Gun>().Shoot(this.gameObject, bulletSpawn);
        }


        if (HP <= 0)
        {
            GameOver();
        }

        if (isPlatformRotate)
        {
            PlatformMover();
        }
    }

    private void PlatformMover()
    {
        Vector3 currentPosition = platform.transform.position;
        Vector3 currentRotation = platform.transform.rotation.eulerAngles;
        currentRotation.y += rotationAmount * Time.deltaTime;

        platform.transform.rotation = Quaternion.Euler(currentRotation);
        platform.transform.position = currentPosition;
    }




    private void Mover()
    {
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            lookPos = hit.point;
        }
        Vector3 lookDir = lookPos - baseTurrel.transform.position;
        lookDir.y = 0;


        Quaternion targetRotation = Quaternion.LookRotation(lookDir);
        targetRotation *= Quaternion.Euler(-90f, -90f, 0f);
        baseTurrel.transform.rotation = Quaternion.Lerp(baseTurrel.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        gun.transform.rotation = baseTurrel.transform.rotation;
    }

    private void GameOver()
    {
        Application.Quit();
    }

    private void OnDestroy()
    {
        Time.timeScale = 0;
    }

    public void Takedamage(int damage)
    {
        HP -= damage;
        if (HP == 0)
        {
            Destroy(this.gameObject);
        }
    }
}