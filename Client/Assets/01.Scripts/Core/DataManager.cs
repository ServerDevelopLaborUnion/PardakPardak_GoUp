using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance = null;
    public static DataManager Instance {
        get {
            if(instance == null)
                instance = FindObjectOfType<DataManager>();

            return instance;
        }
    }

    private string saveFolderPath = "/Save";

    public UserSetting userSetting = null;

    private void Awake()
    {
        saveFolderPath = Path.Combine(Application.persistentDataPath, saveFolderPath);

        if(instance != null)
            return;

        instance = this;

        if (!Directory.Exists(saveFolderPath)) Directory.CreateDirectory(saveFolderPath);

        userSetting = InitialData<UserSetting>();
    }

    #region 에디터용
    private void OnDestroy()
    {
        if(instance != this)
            return;

        SaveData<UserSetting>(userSetting);
    }
    #endregion

    #region 빌드용
    // private void OnApplicationQuit()
    // {
    //     if(instance != this)
    //         return;

    //     SaveData<UserSetting>(userSetting);
    // }
    #endregion

    private T InitialData<T>() where T : Data, new()
    {
        if(!TryReadJson<T>(out T data))
        {
            data = new T();
            data.Generate();
        }

        return data;
    }

    private bool TryReadJson<T>(out T data) where T : Data
    {
        string json = File.ReadAllText(GetPath<T>());

        if (json.Length > 0)
        {
            data = JsonConvert.DeserializeObject<T>(json);

            if(data.IsNull())
            {
                data = default(T);
                return false;
            }

            return true;
        }
        else
        {
            data = default(T);
            return false;
        }
    }

    private void SaveData<T>(T data) where T : Data
    {
        data.Save();

        string json = JsonConvert.SerializeObject(data);

        File.WriteAllText(GetPath<T>(), json);
    }

    private string GetPath<T>()
    {
        string path = $"{saveFolderPath}/{typeof(T)}.json";

        if(!File.Exists(path)) File.Create(path).Close();

        return path;
    }
}