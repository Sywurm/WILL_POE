using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Random_CV_Generator : MonoBehaviour
{
    //usses a list of cv from the cv added in the inspector
    public List<CV_SO> myCVList;
    public bool generate = true;
    public CV_SO theCV;
    public string cE_name;
    //public float cE_Happiness;
    public int cE_Efficientcy;
    public int cE_Productivity;

    private void Update()
    {
        //Chooses a random cv in the list of cv Scriptable object
        // add new cv in the in the inspecter.
        if (generate)
        {
            int rng = Random.Range(0,myCVList.Count);
            theCV = myCVList[rng];
            cE_name = theCV.e_Name;
            //cE_Happiness = theCV.e_Happiness;
            cE_Efficientcy = theCV.e_Efficientcy;
            cE_Productivity = theCV.e_Productivity;
        }
        generate = false;
    }
}