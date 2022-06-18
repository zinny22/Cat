using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    private movement Movement;
    private GameController gameController;
    private float limitDeathY;
    private Vector3 touchBeganPos;
    private Vector3 touchEndedPos;
    private Vector3 touchDif;
    private float swipeSensitivity;

    private void Awake()
    {
        Movement = GetComponent<movement>();
        Movement.MoveTo(Vector3.right);

        limitDeathY = transform.position.y - transform.localScale.y * 0.5f;

    }

    void Update()
    {
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

        if (gameController.IsGameOver == true) return;
    }
}