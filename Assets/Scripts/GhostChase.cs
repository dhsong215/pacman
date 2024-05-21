using UnityEngine;

public class GhostChase : GhostBehaviour
{
        private void OnDisable()
    {
      this.Ghost.Chase.Enable();
     }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>(); // 노드와 충돌시 노드 컴포넌트 가져옵니다.

        // frightened모드 우선 수행
        if (node != null && this.enabled && !this.Ghost.Frightened.enabled)
        {
            Vector2 direction = Vector2.zero;
            float minDistance = float.MaxValue;

            // 팩맨에게 가장 가까운 방향을 foreach로 탐색
            foreach (Vector2 availableDirection in node.AvailableDirections)
            {
                Vector3 newPosition = this.transform.position + new Vector3(availableDirection.x, availableDirection.y, 0.0f);
                float distance = (this.Ghost.target.position - newPosition).sqrMagnitude;

                if (distance < minDistance)
                {
                    direction = availableDirection;
                    minDistance = distance;
                }
            }

            this.Ghost.Movement.SetDirection(direction);

        }
    }
}
