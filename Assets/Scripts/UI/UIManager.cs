using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject Employees;
    [SerializeField] GameObject Office;
    [SerializeField] GameObject CVMenu;
    [SerializeField] GameObject activeMenu = null;

    private void Update()
    {
        PauseTime();
    }

    public void showMainMenu()
    {
        if (MainMenu != null)
        {
            
            if (activeMenu != MainMenu)
            {
                activeMenu = MainMenu;
                MainMenu.SetActive(true);
                Employees.SetActive(false);
                Office.SetActive(false);
                CVMenu.SetActive(false);
            }
            else
            {
                HideSelectedMenu();
            }
        }
        
    }

    public void showEmployeesMenu()
    {
        if (Employees != null)
        {

            if (activeMenu != Employees)
            {
                activeMenu = Employees;
                MainMenu.SetActive(false);
                Employees.SetActive(true);
                Office.SetActive(false);
                CVMenu.SetActive(false);
            }
            else
            {
                HideSelectedMenu();
            }
        }


        
    }

    public void showOfficeMenu()
    {
        if(Office != null)
        {
            if (activeMenu != Office)
            {
                activeMenu = Office;
                MainMenu.SetActive(false);
                Employees.SetActive(false);
                Office.SetActive(true);
                CVMenu.SetActive(false);
            }
            else
            {
                HideSelectedMenu();
            }
        }
        
    }

    public void showCVMenu()
    {
        if (CVMenu != null)
        {
            if (activeMenu != CVMenu)
            {
                activeMenu = CVMenu;
                MainMenu.SetActive(false);
                Employees.SetActive(false);
                Office.SetActive(false);
                CVMenu.SetActive(true);
            }
            else
            {
                HideSelectedMenu();
            }
        }
        
    }

    public void HideSelectedMenu()
    {
        activeMenu = null;

        MainMenu.SetActive(false);
        Employees.SetActive(false);
        Office.SetActive(true);
        CVMenu.SetActive(false);

    }

    private void PauseTime()
    {
        if(CVMenu.gameObject.activeSelf || MainMenu.gameObject.activeSelf)
        {
            GameManager.instance.timeIsPaused = true;
        }
        else
        {
            GameManager.instance.timeIsPaused = false;
        }
    }
}
