using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    [SerializeField]
    private movement Movement;
    public GameController gameController;      //게임시작 종료 여부 판단을 위함 
    private float limitDeathY;

    private Vector3 touchBeganPos;              //터치 시작 위치 
    private Vector3 touchEndedPos;              //터치 종료 위치 
    private Vector3 touchDif;                   //둘의 차이를 나타내줄 변수 값 
    private float swipeSensitivity;             //스와이프 민감도 

    private void Awake()
    {
        Movement = GetComponent<movement>();
        //최초 이동방향 설정
        //Movement.MoveTo(Vector3.right);

        limitDeathY = transform.position.y - transform.localScale.y * 0.5f;

    }

    private IEnumerator Start()
    {
        while (true)
        {
            if(gameController.IsGameStart == true)
            {
                Movement.MoveTo(Vector3.right);         //오른쪽으로 이동하게 하기 
                yield break;
            }
            yield return null;
        }
    }

    void Update()
    {
        if (gameController.IsGameOver == true) return;      //게임 종료 되면 다 멈추게 하기 
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)   
            {
                touchBeganPos = touch.position; 
            }
            if (touch.phase == TouchPhase.Ended)
            {
                touchEndedPos = touch.position;
                touchDif = (touchEndedPos - touchBeganPos);

                //스와이프. 터치의 x이동거리나 y이동거리가 민감도보다 크면
                if (Mathf.Abs(touchDif.y) > swipeSensitivity || Mathf.Abs(touchDif.x) > swipeSensitivity)
                {
                    if (touchDif.y < 0 && Mathf.Abs(touchDif.y) > Mathf.Abs(touchDif.x))
                    {
                        Debug.Log("down");
                    }
                    else if (touchDif.x > 0 && Mathf.Abs(touchDif.y) < Mathf.Abs(touchDif.x))
                    {
                        Debug.Log("right");
                        Vector3 direction = Vector3.right;
                        Movement.MoveTo(direction);
                    }
                    else if (touchDif.x < 0 && Mathf.Abs(touchDif.y) < Mathf.Abs(touchDif.x))
                    {
                        Debug.Log("Left");
                        Vector3 direction = Vector3.forward;
                        Movement.MoveTo(direction);
                    }
                }
                //터치.
                else
                {
                    Debug.Log("touch");
                }
            }
        }
        if (transform.position.y < limitDeathY)
        {
            gameController.GameOver();
        }
    }
}