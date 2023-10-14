using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] GameObject levelMenu;
    [SerializeField] GameObject[] fireTurrel;
    [SerializeField] GameObject[] lazerTurrel;
    [SerializeField] GameObject[] MachineTurrel;
    [SerializeField] GameObject[] button;
    [SerializeField] GameObject upgradeButton;
    [SerializeField] ExManager exManager;

    private int SelectedIndex;


    public void SetFirsIndexGun()
    {
        SelectedIndex = 0;
        UpgradeOrNew();
        Debug.Log(SelectedIndex);
    }

    public void SetTwoIndexGun()
    {
        UpgradeOrNew();
        SelectedIndex = 1;
        Debug.Log(SelectedIndex);
    }

    public void SetThirdIndexGun()
    {
        UpgradeOrNew();
        SelectedIndex = 2;
        Debug.Log(SelectedIndex);
    }

    public void SetFourIndexGun()
    {
        UpgradeOrNew();
        SelectedIndex = 3;
        Debug.Log(SelectedIndex);
    }

   

    private void UpgradeOrNew()
    {
            OnAllButton(button, true);
    }

    private void OnAllButton(GameObject[] button, bool On)
    {
        foreach (GameObject but in button)
        {
            if (On)
                but.SetActive(true);
            else
                but.SetActive(false);
        }
    }

    public void SetFire()
    {
        exManager.SelectedIndex = SelectedIndex;
        exManager.SetNemTurrel(0);
        Time.timeScale = 1f;
        OnAllButton(button, false);
        gameObject.SetActive(false);
    }

    public void SetLazer()
    {
        exManager.SelectedIndex = SelectedIndex;
        exManager.SetNemTurrel(1);
        Time.timeScale = 1f;
        OnAllButton(button, false);
        levelMenu.SetActive(false);
    }

    public void SetMachineGun()
    {
        exManager.SelectedIndex = SelectedIndex;
        exManager.SetNemTurrel(2);
        Time.timeScale = 1f;
        OnAllButton(button, false);
        levelMenu.SetActive(false);
    }

    public void UpgradeMain()
    {
        Time.timeScale = 1f;
        exManager.UpgradeThisExistTurrel();
        upgradeButton.SetActive(false);
        levelMenu.SetActive(false);
    }

}
