using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives=3,score;
    public TMP_Text livesText,scoreText;
    public bool gameOver;
    [SerializeField]
    GameObject gameOverPanel;
    public AudioSource audioSourcePlay,audioSourceBroke,audioSourcePower;
    void Start()
    {
        livesText.text = "LIVE: " + lives.ToString();
        scoreText.text = "SCORE: " + score.ToString();
        gameOverPanel.GetComponent<RectTransform>().localScale=Vector2.zero;
        gameOverPanel.GetComponent<CanvasGroup>().alpha = 0;
    }
   public void UptadeScore(int addScore)
    {
        score+=addScore;
        scoreText.text = "SCORE: " + score.ToString();
    }
    public void UptadeLives(int reduceScore)
    {
        lives+=reduceScore;

        //lives = Mathf.Clamp(lives, 0, 3);

        if (lives==0)
        {
            lives = 0;
            GameOver();
            
        }

        livesText.text = "LIVE: " + lives.ToString();
    }
    public void GameOver()
    {
        gameOver = true;

        gameOverPanel.GetComponent<CanvasGroup>().DOFade(1, 0.5f); // 0.5 saniyede 1 olsun alfasý
        gameOverPanel.GetComponent<RectTransform>().DOScale(1, 0.5f); // 0.5 saniyede 1 olsun scale     

    }
    public void reStart()
    {
        SceneManager.LoadScene("GamePlay");//oyun yeniden baþlamasý için sahneyi yeniden yükler
        audioSourcePlay.Play();
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
    public void Sounds() //Tuðlayý kýrýnca gelen ses
    {
        audioSourceBroke.Play();
    }
    public void PowerSound()
    {
        audioSourcePower.Play();
    }
}
