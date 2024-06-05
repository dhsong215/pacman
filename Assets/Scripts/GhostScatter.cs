using UnityEngine;

public class GhostScatter : GhostBehavior
{
    private void OnDisable()
    {
        ghost.chase.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        // 유령이 frightened일 동안에는 아무것도 하지 않음
        if (node != null && enabled && !ghost.frightened.enabled)
        {
            // 가능한 방향 중에서 무작위로 하나 선택
            int index = Random.Range(0, node.availableDirections.Count);

            // 왔던 방향으로 돌아가지 않도록
            // 가능한 다음 방향으로 인덱스를 증가시킴
            if (node.availableDirections.Count > 1 && node.availableDirections[index] == -ghost.movement.direction)
            {
                index++;

                // 인덱스가 넘쳤을 경우 처음으로 돌아감
                if (index >= node.availableDirections.Count) {
                    index = 0;
                }
            }

            ghost.movement.SetDirection(node.availableDirections[index]);
        }
    }

}
