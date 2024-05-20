using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundWrap : MonoBehaviour // 객체가 특정 좌표계를 벗어날 때 해당 객체를 반대편으로 이동시키는 기능을 제공함.
{
    [SerializeField]
    private StageData stageData; // StageData는 스테이지의 한계를 정의하는 클래스임. 이를 직렬화하여 UnityEditor에서 설정할 수 있게 함. [SerializeField]

    public void UpdateAroundWrap() // 객체의 위치를 확인함. 필요하다면 좌표계를 반전시켜 Wrap-around 효과를 적용함.
    {
        Vector3 position = transform.position; // 현재 객체의 위치를 가져옴.

        if(position.x < stageData.LimitMin.x || position.x > stageData.LimitMax.x) // 객체의 x좌표가 스테이지의 최소 또는 최대 x좌표를 벗어나는지 확인함.
        {
            position.x *= -1; // 객체의 x좌표가 한계에 벗어나면, 반대편으로 이동시킴.
        }

        if(position.y < stageData.LimitMin.y || position.y > stageData.LimitMax.y) // 객체의 y좌표가 스테이지의 최소 또는 최대 y좌표를 벗어나는지 확인함.
        {
            position.y *= -1; // 객체의 y좌표가 한계에 벗어나면, 반대편으로 이동시킴.
        }

        transform.position = position; // 객체의 위치를 새롭게 계산된 위치로 업데이트.
    }
}
