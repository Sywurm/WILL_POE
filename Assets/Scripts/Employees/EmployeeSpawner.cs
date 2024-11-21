using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EmployeeSpawner : MonoBehaviour
{
    [SerializeField] GameObject employeePrefab;
    [Header("Spawn Settings")]
    [SerializeField] float spawnDelayMin = 15;
    [SerializeField] float spawnDelayMax = 30;
    [SerializeField] int spawnAmount;
    public List<GameObject> employeeObjects = new List<GameObject>();
    public static EmployeeSpawner instance;

    [SerializeField] bool canSpawn = false;

    float spawnDelay = 1;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(spawnEmployee());
    }

    private void Update()
    {
        if (GameManager.instance.dayJustStarted == true)
        {
            SetSpawnAmount();
        }

    }

    IEnumerator spawnEmployee()
    {
        yield return new WaitForSeconds(spawnDelay);
        Debug.Log(spawnDelay.ToString());
        if (spawnAmount != 0 && canSpawn == true && GameManager.instance.timeIsPaused == false)
        {
            spawnAmount--;
            GameObject temp = Instantiate(employeePrefab, this.transform.position, Quaternion.identity);
            Employee_Manager.instance.SetEmployees(temp);
            Debug.Log("Employee Spawned");
            canSpawn = false;
        }

        yield return new WaitForSeconds(spawnDelay);

        //I like the idea of the spawning happening between a somewhat random time.
        //Taking into consideration each hour is 30 seconds, I have set the min to 15 / max to 45 so that there is a possibly large delay
        spawnDelay = Random.Range(spawnDelayMin, spawnDelayMax);
        canSpawn = true;
        StartCoroutine(spawnEmployee());
    }

    public void SetSpawnAmount() //(int amount)
    {
        //Grabs the public day int variable from the static instance of the game manager
        switch(GameManager.instance.dayPublic)
        {
            case 0:
                //Shouldnt reach this day but this will be replicate monday incase it does
                spawnAmount = 2;
                break;
            case 1:
                //Monday
                spawnAmount = 2;
                break;
            case 2:
                //Tueday
                spawnAmount = 4;
                break;
            case 3:
                //Wednesday
                spawnAmount = 6;
                break;
            case 4:
                //Thursday
                spawnAmount = 8;
                break;
            case 5:
                //Friday
                spawnAmount = 10;
                break;
            case 6:
                //Shouldnt reach this day but this will be replicate saturday incase it does. It's just friday plus two
                spawnAmount = 12;
                break;
            default:
                spawnAmount = 6;
                break;
        }
    }

}
