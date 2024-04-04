using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCity : MonoBehaviour
{
    public void ResCity()
    {
        PlayerPrefs.SetString("NowMap", "City");
    }
}
