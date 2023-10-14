using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] GameObject levelMenu;


    private void SetFire()
    {
        Time.timeScale = 1f;
        levelMenu.SetActive(false);
    }

    private void SetLazer()
    {
        Time.timeScale = 1f;
        levelMenu.SetActive(false);
    }

    private void MachineGun()
    {
        Time.timeScale = 1f;
        levelMenu.SetActive(false);
    }

    private void UpgradeMain()
    {
        Time.timeScale = 1f;
        levelMenu.SetActive(false);
    }

}
