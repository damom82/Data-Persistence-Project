using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public string playerName;
    public int highScore;
    public string highScoreName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }

    [System.Serializable]
    private class SaveDataFile
    {
        public int highScore;
        public string highScoreName;
    }

    public void SaveData()
    {
        SaveDataFile data = new SaveDataFile();
        data.highScore = highScore;
        data.highScoreName = highScoreName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveDataFile data = JsonUtility.FromJson<SaveDataFile>(json);

            highScore = data.highScore;
            highScoreName = data.highScoreName;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("StartMenu");
    }
}