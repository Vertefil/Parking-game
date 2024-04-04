using System.Collections;
using UnityEngine;

public class AmbientSound : MonoBehaviour
{
    private AudioSource _audio;

    public void Start()
    {
        _audio = GetComponent<AudioSource>();
        StartCoroutine(SoundBackground());
    }

    //Бесконечно зацикливаем звук
    IEnumerator SoundBackground()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 6f));
            _audio.Play();
        }
    }

}
