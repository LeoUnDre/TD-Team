using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExManager : MonoBehaviour
{
    [SerializeField] GameObject levelMenu;
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] GameObject[] FirePrefabs;
    [SerializeField] GameObject[] LaserPrefabs;
    [SerializeField] GameObject[] MachinePrefabs;
    [SerializeField] GameObject[] TurrelPrefabs;
    private int Xp;
    private int NextLevelXp;
    public int Level;
    public bool isNewLevel = false;

    private void Start()
    {
        Xp = 0;
        NextLevelXp = 10;
        Level = 1;
    }

    private void Update()
    {
        if (Xp == NextLevelXp)
        {
            SetNewLevel();
            Debug.Log("New Level" + Level);
            Debug.Log(this.GetComponent<TowerControl>().damage);
        }
    }


    private void SetNewLevel()
    {
        Level += 1;
        NextLevelXp += 100;
        Xp = 0;
        isNewLevel = true;
        this.GetComponent<TowerControl>().damage += 10;
        OpenLevelMenu();
    }


    private void OpenLevelMenu()
    {
        Time.timeScale = 0;
        levelMenu.SetActive(true);
    }
    public void SetXp(int xp)
    {
        Xp += xp;
    }
}