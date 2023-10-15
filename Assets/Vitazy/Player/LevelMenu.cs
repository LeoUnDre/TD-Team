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
    [SerializeField] GameObject[] menuButton;
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
        UpgradeOrNew(isTurrelSet[SelectedIndex], SelectedIndex);
        Debug.Log(SelectedIndex);
    }

    public void SetTwoIndexGun()
    {

        SelectedIndex = 1;
        UpgradeOrNew(isTurrelSet[SelectedIndex], SelectedIndex);
        Debug.Log(SelectedIndex);
    }

    public void SetThirdIndexGun()
    {
        SelectedIndex = 2;
        UpgradeOrNew(isTurrelSet[SelectedIndex], SelectedIndex);
        Debug.Log(SelectedIndex);
    }

    public void SetFourIndexGun()
    {
        SelectedIndex = 3;
        UpgradeOrNew(isTurrelSet[SelectedIndex], SelectedIndex);
        Debug.Log(SelectedIndex);
    }

    private void UpgradeOrNew(bool isTurrelExist, int selectedId)
    {
        OnAllButton(isTurrelExist, selectedId);
    }

    private void OnArrayButton(int idButton)
    {
        for (int i = 0; i < menuButton.Length; i++)
        {
            if (i == idButton)
            {
                menuButton[i].SetActive(true);
            }
            else
                menuButton[i].SetActive(false);
        }
    }

    private void OnAllButton(bool On, int idTurrel)
    {
        if (!On)
        {
            switch (idTurrel)
            {
                case 0:
                case 1:
                    OnArrayButton(0);
                    break;
                case 2:
                    OnArrayButton(1);
                    break;
                case 3:
                    OnArrayButton(2);
                    break;
            }
        }
        else
        {
            foreach (var but in menuButton)
            {
                but.SetActive(false);
            }
            upgradeButton.SetActive(true);
        }
    }

    public void createNewTurrel(int selTurrel)
    {
        switch (selTurrel)
        {
            case 0:
                exManager.SetNewTurrel(fireTurrel, 0, SelectedIndex, TurrelPrefabs);
                isTurrelSet[SelectedIndex] = true;
                break;
            case 1:
                exManager.SetNewTurrel(lazerTurrel, 1, SelectedIndex, TurrelPrefabs);
                isTurrelSet[SelectedIndex] = true;
                break;
            case 2:
                exManager.SetNewTurrel(machineTurrel, 2, SelectedIndex, TurrelPrefabs);
                isTurrelSet[SelectedIndex] = true;
                break;
            case 3:
                exManager.UpgradeThisExistTurrel(SelectedIndex);
                isTurrelSet[SelectedIndex] = true;
                break;
        }
    }
}