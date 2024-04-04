using UnityEngine;

public class CreateAmbient : MonoBehaviour
{
    public GameObject AmbientHorns;
    private static bool IsCreated = false;

    public void Start()
    {
        if (IsCreated) return;

        IsCreated = true;
        DontDestroyOnLoad(Instantiate(AmbientHorns));
            
    }

}
