using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //for text stuff ui stuff
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text textForScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gs();
    }

    private void gs()
    {
        textForScore.text = score.ToString();
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //aktif sahneyi tekrar yüklüyoruz
    }
}
