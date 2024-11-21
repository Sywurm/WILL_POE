using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] float spawnDelayMin = 15;
    [SerializeField] float spawnDelayMax = 30;
    [SerializeField] int spawnAmount;
    public List<GameObject> employeeObjects = new List<GameObject>();
    public static EmployeeSpawner instance;

    [SerializeField] Transform spawnLocation; // Empty object to determine where employees spawn
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

        if (spawnAmount != 0 && canSpawn == true && GameManager.instance.timeIsPaused == false)
        {
            spawnAmount--;

            if (employeeObjects.Count > 0)
            {
                // Select a random employee from the list
                int randomIndex = Random.Range(0, employeeObjects.Count);
                GameObject selectedEmployee = employeeObjects[randomIndex];

                // Use the spawnLocation if assigned, otherwise use this.transform.position
                Vector3 spawnPosition = spawnLocation != null ? spawnLocation.position : this.transform.position;
                Quaternion spawnRotation = spawnLocation != null ? spawnLocation.rotation : Quaternion.identity;

                // Instantiate the selected employee
                GameObject temp = Instantiate(selectedEmployee, spawnPosition, spawnRotation);

                // Register the employee in the Employee_Manager
                Employee_Manager.instance.SetEmployees(temp);
                Debug.Log($"Employee Spawned: {selectedEmployee.name}");
            }
            else
            {
                Debug.LogWarning("No employee objects available to spawn.");
            }

            canSpawn = false;
        }

        // Wait for the next spawn
        yield return new WaitForSeconds(spawnDelay);

        // Randomize the next spawn delay
        spawnDelay = Random.Range(spawnDelayMin, spawnDelayMax);
        canSpawn = true;
        StartCoroutine(spawnEmployee());
    }

    public void SetSpawnAmount()
    {
        // Determine the number of employees to spawn based on the day
        switch (GameManager.instance.dayPublic)
        {
            case 0:
                spawnAmount = 2; // Shouldn't reach this day; default to Monday
                break;
            case 1: // Monday
                spawnAmount = 2;
                break;
            case 2: // Tuesday
                spawnAmount = 4;
                break;
            case 3: // Wednesday
                spawnAmount = 6;
                break;
            case 4: // Thursday
                spawnAmount = 8;
                break;
            case 5: // Friday
                spawnAmount = 10;
                break;
            case 6: // Saturday
                spawnAmount = 12; // Extra spawns for Saturday
                break;
            default:
                spawnAmount = 6;
                break;
        }
    }
}

