using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMap : MonoBehaviour
{
    public GameObject _city, _cyber;

    public void Start()
    {
        if (PlayerPrefs.GetString("NowMap") == "Cyber")
            _cyber.SetActive(true);
        else
            _city.SetActive(true);
    }
}
