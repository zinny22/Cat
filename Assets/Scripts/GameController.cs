using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("GameStart UI")]
    [SerializeField]
    private FadeEffect[] fadeGameStart;
    [SerializeField]
    private GameObject PanelGameStart;

    [Header ("InGame")]
    [SerializeField]
    private TextMeshProUGUI TextGameScore;
    private TextMeshProUGUI TextGameCoin;


    [Header("GameOver UI")]
    [SerializeField]
    private GameObject PanelGameOver;
    [SerializeField]
    public float timeStopTime;
    private GameObject PanelScore;

    public bool IsGameStart { private set; get; } = false;  //게임 시작 여부 
    public bool IsGameOver { private set; get; } = false;   //게임 종료 여부


    private IEnumerator Start()
    {
        Time.timeScale = 1;
        for (int i =0; i< fadeGameStart.Length; i++)
        {
            fadeGameStart[i].FadeIn();
        }

        while (true)
        {
            if (Input.GetMouseButtonDown(0)) {
                GameStart();
                IsGameStart = true;
                yield break;
            }
            yield return null;          //실행이 일시 정지되고 다음 프레임에서 다시 시작되는 지점
        }
    }

    public void GameStart()
    {
        PanelGameStart.SetActive(false);
        TextGameScore.gameObject.SetActive(true);
        TextGameCoin.gameObject.SetActive(true);
    }


    public void GameOver()
    {
        IsGameOver = true;

        //게임 오버시 판낼 활성화 
        PanelGameOver.SetActive(true);
        PanelScore.SetActive(true);

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
