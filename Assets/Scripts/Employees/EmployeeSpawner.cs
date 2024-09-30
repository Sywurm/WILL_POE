using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EmployeeSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> employeePrefabs = new List<GameObject>();
    [Header("Spawn Settings")]
    [SerializeField] float spawnDelayMin;
    [SerializeField] float spawnDelayMax;
    [SerializeField] int spawnAmount;

    float spawnDelay;
    private void Start()
    {
        StartCoroutine(spawnEmployee());
    }

    IEnumerator spawnEmployee()
    {
        GameObject employee = employeePrefabs[Random.Range(0, employeePrefabs.Count)];

        if (spawnAmount != 0)
        {
            spawnAmount--;
            Instantiate(employee, this.transform.position, Quaternion.identity);
        }

        yield return new WaitForSeconds(spawnDelay);

        spawnDelay = Random.Range(spawnDelayMin, spawnDelayMax);
        StartCoroutine(spawnEmployee());
    }

    public void SetSpawnAmount(int amount)
    {
        spawnAmount = amount;
    }

    public void SetSpawnDelayRange(float minDelay,  float maxDelay) 
    {
        spawnDelayMin = minDelay;
        spawnDelayMax = maxDelay;
    }

}
