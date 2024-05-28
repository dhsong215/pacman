using UnityEngine;

public class GhostChase : GhostBehavior
{
    private void OnDisable()
    {
        // chase 모드가 비활성화되면 산개 모드를 활성화
        ghost.scatter.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        // 유령이 frightened일 때는 아무것도 하지 않음
        if (node != null && enabled && !ghost.frightened.enabled)
        {
            Vector2 direction = Vector2.zero;
            float minDistance = float.MaxValue;

            // 팩맨에게 가장 가까운 방향을 찾음
            foreach (Vector2 availableDirection in node.availableDirections)
            {
                // 현재 방향의 거리가 현재 최소 거리보다 작으면
                // 다음 방향이 새로운 가장 가까운 방향이 됨
                Vector3 newPosition = transform.position + new Vector3(availableDirection.x, availableDirection.y);
                float distance = (ghost.target.position - newPosition).sqrMagnitude;

                if (distance < minDistance)
                {
                    direction = availableDirection;
                    minDistance = distance;
                }
            }

            // 고스트 이동 방향 설정
            ghost.movement.SetDirection(direction);
        }
    }

}