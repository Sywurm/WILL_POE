using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    //This is a list of employees, this list will be updated by the emplyoeeManager as a new emploee is hired or fired
    private List<GameObject> listOfActiveEmployees;

    //These Variables are the current office stats that will be seen on the UI.
    [Tooltip("This Value Represents the Office happiness. It can only be reAssigned from within this script ")]
    [SerializeField] private float OfficeHappitness;

    [Tooltip("This Value Represents the Office Efficiency. It can only be reAssigned from within this script ")]
    [SerializeField] private float OfficeEfficiency;

    [Tooltip("This Value Represents the Office State. It can only be reAssigned from within this script ")]
    [SerializeField] private float OfficeState;

    [Tooltip("This Value is public so other elements such as UI can access it ")]
    public float _OfficeHappitness;

    [Tooltip("This Value is public so other elements such as UI can access it ")]
    public float _OfficeEfficiency;

    [Tooltip("This Value is public so other elements such as UI can access it ")]
    public float _OfficeState;

    #endregion

    #region Unity Functions
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region Functions

    private void OfficeStats()
    {
        //Setting these States so that they can be used by the UI elements.
        _OfficeHappitness = OfficeHappitness;
        _OfficeEfficiency = OfficeEfficiency;
        _OfficeState = OfficeState;
    }


    #endregion



}
