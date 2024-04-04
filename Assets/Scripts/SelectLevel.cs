using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{

    public Text CountMoves;

    //Обозначение полей для юнити
    [Serializable]
    //Структура для уровней и кол-во шагов
    public struct Levels
    {
        public GameObject level;
        public int moves;
    }

    public Levels[] levels;

    public void Start()
    {
        //Обработка на выдуманный уровень
        if (!PlayerPrefs.HasKey("Game Level"))
            PlayerPrefs.SetInt("Game Level", 1);



        if (PlayerPrefs.GetInt("Game Level") >= levels.Length)
            PlayerPrefs.SetInt("Game Level", levels.Length);

        //Подстановка уровней
        if (PlayerPrefs.GetInt("Game Level") <= 0)
        {
            PlayerPrefs.SetInt("Game Level", 0);
            Levels now = levels[PlayerPrefs.GetInt("Game Level")];
            now.level.SetActive(true);
            //Подстановка шагов
            CountMoves.text = now.moves.ToString();
        }
        else 
        {
            Levels now = levels[PlayerPrefs.GetInt("Game Level") - 1];
            now.level.SetActive(true);
            //Подстановка шагов
            CountMoves.text = now.moves.ToString();
        }


    }
}
