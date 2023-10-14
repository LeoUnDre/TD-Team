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
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] GameObject[] FirePrefabs;
    [SerializeField] GameObject[] LaserPrefabs;
    [SerializeField] GameObject[] MachinePrefabs;
    [SerializeField] GameObject platform;
    [SerializeField]public List<GameObject> TurrelPrefabs;
    [SerializeField] public int SelectedIndex;
    private Autoturell tOwner;
    private int Xp;
    private int NextLevelXp;
    public int Level;
    public bool isNewLevel = false;
    private bool isFull;
    private Autoturell[] existTurrel = new Autoturell[4];
    public Autoturell selectedTurret;



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

    public void UpgradeThisExistTurrel()
    {
        if (selectedTurret != null)
        {
            if (selectedTurret.Level < selectedTurret.LevelPrefabs.Length)
            {
                selectedTurret.LevelUp();
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