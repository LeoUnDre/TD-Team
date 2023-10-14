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
    [SerializeField] public List<GameObject> TurrelPrefabs;
    private Autoturell tOwner;
    private Autoturell[] existTurrel = new Autoturell[4];
    public Autoturell selectedTurret;

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

    public bool IsFree(List<GameObject> turrelPrefab, int selInd)
    {
        if (selInd <= 0)
        {
            return turrelPrefab[selInd].GetComponent<StandManager>().isFree;
        }
        else
        {
            return false;
        }
    }

    public void SetNemTurrel(int numTurrel, int selectedIndex, List<GameObject> turrelPrefabs)
    {
        if (selectedTurret == null)
        {
            switch (numTurrel)
            {
                case 0:
                    AddNemTurrel(fireTurrel, numTurrel, selectedIndex, turrelPrefabs);
                    break;
                case 1:
                    AddNemTurrel(lazerTurrel, numTurrel, selectedIndex, turrelPrefabs);
                    break;
                case 2:
                    AddNemTurrel(MachineTurrel, numTurrel, selectedIndex, turrelPrefabs);
                    break;
            }

        }
    }

    private void AddNemTurrel(GameObject[] prefab, int IdTurrel, int selectedIndex, List<GameObject> turrelPrefabs)
    {
        if (turrelPrefabs != null)
        {
            if (!IsFree(turrelPrefabs, selectedIndex))
            {
                GameObject turrell = turrelPrefabs[selectedIndex];
                GameObject turrel = Instantiate(prefab[0], turrell.transform.position, Quaternion.identity);
                tOwner = turrel.GetComponent<Autoturell>();
                tOwner.LevelPrefabs = prefab;
                tOwner.owner = this.gameObject;
                tOwner.numTurrel = IdTurrel;
                tOwner.ownerSpawn = turrell.gameObject;
                turrell.GetComponent<StandManager>().isFree = true;
                existTurrel[selectedIndex] = tOwner;
                Time.timeScale = 1f;
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("This Dont Have a place");
            }
        }
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
        SelectedIndex = 3;
        SetNemTurrel(0,3,TurrelPrefabs);
    }

    public void SetLazer()
    {
        SelectedIndex = 2;
        SetNemTurrel(1,2,TurrelPrefabs);
    }

    public void SetMachineGun()
    {
        SelectedIndex = 1;
        SetNemTurrel(2,1,TurrelPrefabs);
    }

    public void SetMachineGun1()
    {
        SelectedIndex = 0;
        SetNemTurrel(2,0,TurrelPrefabs);
    }

    public void UpgradeMain()
    {
        exManager.UpgradeThisExistTurrel();
        upgradeButton.SetActive(false);
    }
}