using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Panel.gameObject.active)
            {
                Time.timeScale = 1f;
                Panel.gameObject.SetActive(false);
            }
            else
            {
                Panel.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
