using UnityEngine;

public class LoadIngame : MonoBehaviour
{
    public void Load()
    {
        SceneLoader.Instance.LoadAsync("InGame");
    }
}
