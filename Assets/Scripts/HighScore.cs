using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour
{

    public Text newKingName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void giveKingName()
    {
        SaveManager.Instance.kingName = newKingName.text;
        SaveManager.Instance.SaveScore();
        SceneManager.LoadScene(0);

    }
}
