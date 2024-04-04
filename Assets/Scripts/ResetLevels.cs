using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevels : MonoBehaviour
{
    public void ResLevels()
    {
        PlayerPrefs.SetInt("Game Level", 0);
    }

}
