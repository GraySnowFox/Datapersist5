using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public int highPoints;
    public string kingName;

    private void Awake()
    {
        highPoints = 0;
        kingName = "None";
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public void PointCompare(int points)
    {
        if(points > highPoints)
        {
            highPoints = points;
            Debug.Log("New High");
            SaveScore();
        }
    }
    
     [System.Serializable]
    class HighScore
    {
        public string name;
        public int score;
    }

    public void SaveScore()
    {
       HighScore topScore = new HighScore();
        topScore.name = "John Doe";
        topScore.score = highPoints;

        string json = JsonUtility.ToJson(topScore);

        File.WriteAllText(Application.persistentDataPath + "/savefile", json);

    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            
            HighScore topScore = JsonUtility.FromJson<HighScore>(json);
            highPoints = topScore.score;
            kingName = topScore.name;
            

        }

    }

    
}
