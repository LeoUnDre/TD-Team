using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ExManager : MonoBehaviour
{
    [SerializeField] GameObject levelMenu;
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] GameObject[] fireTurrel;
    [SerializeField] GameObject[] laserTurrel;
    [SerializeField] GameObject[] machineTurrel;
    [SerializeField] GameObject platform;
    [SerializeField] public int SelectedIndex;
    private Autoturell [] existTurrel = {null, null, null, null};
    private Autoturell tOwner;
    private int Xp;
    private int NextLevelXp;
    public int level;
    public bool isNewLevel = false;



    private void Start()
    {
        Xp = 0;
        NextLevelXp = 10;
        level = 1;
    }

    private void Update()
    {

        if (Xp == NextLevelXp)
        {
            SetNewLevel();
            Debug.Log("New Level" + level);
            Debug.Log(this.GetComponent<TowerControl>().damage);
        }
    }


    private void SetNewLevel()
    {
        level += 1;
        NextLevelXp += 100;
        Xp = 0;
        if (level <= 12)
        {
            isNewLevel = true;
            this.GetComponent<TowerControl>().damage += 10;
            OpenMenuLevel();
        }
    }

    private void OpenMenuLevel()
    {
        if (isNewLevel) 
        {
            Time.timeScale = 0;
            levelMenu.SetActive(true);
            isNewLevel = false;
        }
    }

    private void CloseMenuLevel()
    {
        Time.timeScale = 1.0f;
        levelMenu.SetActive(false);
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

    public void SetNewTurrel(GameObject[] prefabTurrel, int numTurrel, int selectedIndex, List<GameObject> turrelPrefabs)
    {
            switch (numTurrel)
            {
                case 0:
                    AddNemTurrel(prefabTurrel, numTurrel, selectedIndex, turrelPrefabs);
                    CloseMenuLevel();
                    break;
                case 1:
                    AddNemTurrel(prefabTurrel, numTurrel, selectedIndex, turrelPrefabs);
                    CloseMenuLevel();
                    break;
                case 2:
                    AddNemTurrel(prefabTurrel, numTurrel, selectedIndex, turrelPrefabs);
                    CloseMenuLevel();
                    break;
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
                tOwner.level = 1;
                tOwner.ownerSpawn = turrell.gameObject;
                existTurrel[selectedIndex] = tOwner;

            }
            else
            {
            }
        }
    }


    public void UpgradeThisExistTurrel(int selIndex)
    {
        if (existTurrel[selIndex] != null)
        {
            if (existTurrel[selIndex].level < existTurrel[selIndex].LevelPrefabs.Length)
            {
                existTurrel[selIndex] = existTurrel[selIndex].LevelUp();
                CloseMenuLevel();
            }
            else
            {
                Debug.Log("TurrelHaveMaxLevel");
            }
        }
    }



    public void SetXp(int xp)
    {
        Xp += xp;
    }
}