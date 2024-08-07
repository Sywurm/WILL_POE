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

    private void Update()
    {
        //Chooses a random cv in the list of cv Scriptable object
        // add new cv in the in the inspecter.
        int rng = Random.Range(0,myCVList.Count);
        if (generate)
        {
            theCV = myCVList[rng];
        }
        generate = false;
    }
}