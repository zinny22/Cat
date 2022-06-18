using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private Vector3 moveDirection;

    public Vector3 MoveDirection => moveDirection;

    void Update()
    {
        transform.position += moveSpeed * moveDirection * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
