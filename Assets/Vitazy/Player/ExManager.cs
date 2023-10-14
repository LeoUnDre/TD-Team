using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ExManager : MonoBehaviour
{
    [SerializeField] GameObject levelMenu;
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] GameObject[] FirePrefabs;
    [SerializeField] GameObject[] LaserPrefabs;
    [SerializeField] GameObject[] MachinePrefabs;
    [SerializeField] GameObject platform;
    [SerializeField] List<GameObject> TurrelPrefabs;
    private Autoturell tOwner;
    private int Xp;
    private int NextLevelXp;
    public int Level;
    public bool isNewLevel = false;
    private bool isFull;
    private List<GameObject> existTurrel = new List<GameObject>();
    public Autoturell selectedTurret;



    private void Start()
    {
        Xp = 0;
        NextLevelXp = 10;
        Level = 1;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.W))
        {

            SetNemTurrel(UnityEngine.Random.Range(0, 2));
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            if (existTurrel != null)
            {
                if (selectedTurret != null)
                {
                    UpgradeThisExistTurrel();
                }
            }
            else
            {
                Debug.Log("Лох");
            }
        }

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
        levelMenu.SetActive(true);
        levelMenu.GetComponent<LevelMenu>();
        Time.timeScale = 0;
    }

    public void SetNemTurrel(int numTurrel)
    {
        if (selectedTurret == null)
        {
            switch (numTurrel)
            {
                case 0:
                    AddNemTurrel(FirePrefabs, numTurrel);
                    break;
                case 1:
                    AddNemTurrel(LaserPrefabs, numTurrel);
                    break;
                case 2:
                    AddNemTurrel(MachinePrefabs, numTurrel);
                    break;
            }

        }
    }

private void AddNemTurrel(GameObject[] prefab, int IdTurrel)
    {
        if(TurrelPrefabs != null)
        {
            foreach(var t in TurrelPrefabs)
            {
                if (!t.GetComponent<StandManager>().isFree)
                {
                    GameObject turrel = Instantiate(prefab[0], t.transform.position, Quaternion.identity);
                    tOwner = turrel.GetComponent<Autoturell>();
                    tOwner.LevelPrefabs = prefab;
                    tOwner.owner = this.gameObject;
                    tOwner.numTurrel = IdTurrel;
                    tOwner.ownerSpawn = t.gameObject;
                    tOwner.SetSelectedTurret(tOwner);
                    t.GetComponent<StandManager>().isFree = true;
                    existTurrel.Add(turrel);
                    break;
                }
            }
        }
        else
        {
            Debug.Log("This dosnt exist");
        }
    }

    public void UpgradeThisExistTurrel()
    {
        if (selectedTurret != null)
        {
            // Проверяем, что у турели есть доступные уровни для апгрейда
            if (selectedTurret.Level < selectedTurret.LevelPrefabs.Length - 1)
            {
                // Улучшаем турель на один уровень
                selectedTurret.LevelUp();
            }
            else
            {
                // Если у турели больше нет уровней, выведите сообщение или выполните другие действия
                Debug.Log("Турель достигла максимального уровня.");
            }
        }
    }



    public void SetXp(int xp)
    {
        Xp += xp;
    }
}