using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] GameObject levelMenu;
    [SerializeField] GameObject[] fireTurrel;
    [SerializeField] GameObject[] lazerTurrel;
    [SerializeField] GameObject[] machineTurrel;
    [SerializeField] GameObject newMenuButton;
    [SerializeField] GameObject upgradeButton;
    [SerializeField] ExManager exManager;
    [SerializeField] public List<GameObject> TurrelPrefabs;
    private Autoturell tOwner;
    private Autoturell[] existTurrel = new Autoturell[4];
    private bool[] isTurrelSet = { false, false, false, false };
    public Autoturell selectedTurret;

    private int SelectedIndex;


    public void SetFirsIndexGun()
    {
        SelectedIndex = 0;
        UpgradeOrNew(isTurrelSet[SelectedIndex]);
        Debug.Log(SelectedIndex);
    }

    public void SetTwoIndexGun()
    {

        SelectedIndex = 1;
        UpgradeOrNew(isTurrelSet[SelectedIndex]);
        Debug.Log(SelectedIndex);
    }

    public void SetThirdIndexGun()
    {
        SelectedIndex = 2;
        UpgradeOrNew(isTurrelSet[SelectedIndex]);
        Debug.Log(SelectedIndex);
    }

    public void SetFourIndexGun()
    {
        SelectedIndex = 3;
        UpgradeOrNew(isTurrelSet[SelectedIndex]);
        Debug.Log(SelectedIndex);
    }

    private void UpgradeOrNew(bool isTurrelExist)
    {
        OnAllButton(isTurrelExist);
    }

    private void OnAllButton(bool On)
    {
        if (On)
        {
            newMenuButton.SetActive(false);
            upgradeButton.SetActive(true);
        }
        else
        {
            upgradeButton.SetActive(false);
            newMenuButton.SetActive(true);
        }
    }

    public void createNewTurrel(int selTurrel)
    {
        switch (selTurrel)
        {
            case 0:
                exManager.SetNewTurrel(fireTurrel, 0, SelectedIndex, TurrelPrefabs);
                isTurrelSet[SelectedIndex] = true;
                newMenuButton.SetActive(false);
                break;
            case 1:
                exManager.SetNewTurrel(lazerTurrel, 1, SelectedIndex, TurrelPrefabs);
                isTurrelSet[SelectedIndex] = true;
                newMenuButton.SetActive(false);
                break;
            case 2:
                exManager.SetNewTurrel(machineTurrel, 2, SelectedIndex, TurrelPrefabs);
                isTurrelSet[SelectedIndex] = true;
                newMenuButton.SetActive(false);
                break;
            case 3:
                exManager.UpgradeThisExistTurrel(SelectedIndex);
                isTurrelSet[SelectedIndex] = true;
                newMenuButton.SetActive(false);
                break;
        }
    }
}