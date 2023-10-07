using UnityEngine;

public class TowerControl : MonoBehaviour
{
    [SerializeField] Gun gun;
    private Camera _cam;

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
            gun.Shoot();
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

}
