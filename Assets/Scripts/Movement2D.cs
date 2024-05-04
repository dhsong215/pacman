using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float  moveTime = 0.2f; // 한칸 이동에 소요되는 시간
    private bool   isMove = false; // 오브젝트의 이동/대기 제어 변수

    public bool MoveTo(Vector3 moveDirection)
    {
        // 이동중이면 이동함수가 실행되지 않도록 함
        if(isMove)
        {
            return false;
        }

        // 현재위치로부터 이동방향으로 1 단위 이동한 위치를 매개변수로 코루틴 함수 실행
        StartCoroutine(SmoothGridMovement(transform.position + moveDirection));

        return true;
    }

    private IEnumerator SmoothGridMovement(Vector2 endPosition)
    {
        Vector2 startPosition = transform.position;
        float  percent = 0;

        // moveTime시간동안 while() 반복문 호출
        // while() 반복문을 호출하는 동안 isMove = true, 반복문 종료 시 isMove = false
        isMove = true;
        while ( percent < moveTime )
        {
            percent += Time.deltaTime;
            // startPosition에서 endPosition까지 moveTime시간동안만 이동
            transform.position = Vector2.Lerp(startPosition, endPosition, percent/moveTime);

            yield return null;
        }
        isMove = false;
    }
}

/* 
 * File : Movement2D.cs
 * Desc
 *  : 2D Grid 환경에서 한칸 단위로 이동 제어
 */