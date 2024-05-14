using UnityEngine;

public class GhostScatter : GhostBehaviour
{
  private void OnDisable()
  {
    this.Ghost.Chase.Enable();
  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    Node node = other.GetComponent<Node>(); // 노드와 충돌시 노드 컴포넌트 가져옵니다.

    if (node != null && this.enabled && !this.Ghost.Frightened.enabled) // frightened모드가 우선 이여서 조건에 추가
    {
      // 방향을 랜덤하게 선택
      int index = Random.Range(0, node.AvailableDirections.Count);

      // 선택된 방향이 현재 고스트의 이동 방향의 반대(뒤)이고, 사용 가능한 방향이 1개 이상일 경우
      if (node.AvailableDirections[index] == -this.Ghost.Movement.Direction && node.AvailableDirections.Count > 1)
      {
        index++;
        
        // 직진
        if (index >= node.AvailableDirections.Count) {
          index = 0;
        }
      }

      this.Ghost.Movement.SetDirection(node.AvailableDirections[index]);
    }
  }
}
