using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject Employees;
    [SerializeField] GameObject Office;
    [SerializeField] GameObject CVMenu;
    [SerializeField] bool isMenuActive;

    public void showMainMenu()
    {
        if (MainMenu != null)
        {
            if (isMenuActive == false)
            {
                isMenuActive = true;
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
            if(isMenuActive ==false)
            {
                isMenuActive = true;
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
            if (isMenuActive == false)
            {
                isMenuActive = true;
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
            if (isMenuActive == false)
            {
                isMenuActive = true;
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
        isMenuActive = false;

        MainMenu.SetActive(false);
        Employees.SetActive(false);
        Office.SetActive(false);
        CVMenu.SetActive(false);

    }
}
