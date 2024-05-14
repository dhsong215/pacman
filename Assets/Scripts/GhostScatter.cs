using UnityEngine;

public class GhostScatter : GhostBehaviour
{
  private void OnDisable()
  {
    this.Ghost.Chase.Enable();
  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    Node node = other.GetComponent<Node>();

    if (node != null && this.enabled && !this.Ghost.Frightened.enabled) // frightened모드가 우선 이여서 조건에 추가
    {
      int index = Random.Range(0, node.AvailableDirections.Count);

      if (node.AvailableDirections[index] == -this.Ghost.Movement.Direction && node.AvailableDirections.Count > 1)
      {
        index++;

        if (index >= node.AvailableDirections.Count) {
          index = 0;
        }
      }

      this.Ghost.Movement.SetDirection(node.AvailableDirections[index]);
    }
  }
}
