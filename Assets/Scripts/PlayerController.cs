using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2     moveDirection = Vector2.right; // 이동방향을 나타내는 변수 moveDirection, 최초방향 right로 설정
    private Movement2D  movement2D;

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
    }

    private void Update()
    {
        // 1. 방향키 입력으로 이동방향을 설정
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveDirection = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveDirection = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDirection = Vector2.down;
        }

        if (Input.anyKeyDown)
        {
            // MoveTo()함수에 이동방향을 매개변수로 전달하여 이동
            movement2D.MoveTo(moveDirection);
        }
    }
}
