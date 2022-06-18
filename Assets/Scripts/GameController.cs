using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("GameStart")]
    [SerializeField]
    private float fadeTime = 0.5f;
    private AnimationCurve fadeCurve;
    private TextMeshProUGUI fadeText;
    private float endAlpa;

    [Header("GameOverUI")]
    [SerializeField]
    private GameObject PanelGameOver;
    public float timeStopTime;

    public bool IsGameOver { private set; get; } = false;

    private void Awake()
    {
        fadeText = GetComponent<TextMeshProUGUI>();
        endAlpa = fadeText.color.a;
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    //public void fadeIn()
    //{
    //    StartCoroutine(Fade(0, endAlpa))
    //}

    //private IEnumerator Fade()
    //{

    //}

    public void GameOver()
    {
        IsGameOver = true;

        //게임 오버시 판낼 활성화 
        PanelGameOver.SetActive(true);

        StartCoroutine("SlowAndStopTime");
    }

    private IEnumerator SlowAndStopTime()
    {
        float current = 0;
        float percent = 0;

        Time.timeScale = 0.5f;

        while(percent < 1)
        {
            current += Time.deltaTime;
            percent = current / timeStopTime;

            yield return null;
        }

        Time.timeScale = 0;
    }
}
