using UnityEngine;

// Rigidbody2D 컴포넌트를 필요로 하는 Movement 클래스를 정의합니다.
// 여러 캐릭터의 움직임을 설정합니다.
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public float speed = 8f; // 기본 이동 속도
    public float speedMultiplier = 1f; // 속도 배수
    public Vector2 initialDirection; // 초기 이동 방향
    public LayerMask obstacleLayer; // 장애물 감지용 레이어 마스크

    public Rigidbody2D Rigidbody { get; private set; }
    public Vector2 Direction { get; private set; } // 현재 이동 방향
    public Vector2 NextDirection { get; private set; } // 다음 이동 방향
    public Vector3 StartingPosition { get; private set; } // 시작 위치
    
    // 캐릭터 상태를 초기 상태로 리셋합니다.
    public void ResetState()
    {
        speedMultiplier = 1f;
        Direction = initialDirection;
        NextDirection = Vector2.zero;
        transform.position = StartingPosition;
        Rigidbody.isKinematic = false; // Rigidbody를 비키네틱 상태로 설정하여 물리 연산에 반응하게 합니다.
        enabled = true;
    }
}