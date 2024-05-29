using System.Collections;
using UnityEngine;

public class GhostHome : GhostBehavior
{
    public Transform inside;
    public Transform outside;

    private void OnEnable()
    {
        StopAllCoroutines();
    }

    private void OnDisable()
    {
        // 객체가 파괴될 때 오류를 방지하기 위해 활성 상태를 확인
        if (gameObject.activeInHierarchy) {
            StartCoroutine(ExitTransition());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 유령이 벽에 부딪힐 때마다 방향을 반대로 하여 유령이 집 안에서 튕기는 효과를 만듭니다
        if (enabled && collision.gameObject.layer == LayerMask.NameToLayer("Obstacle")) {
            ghost.movement.SetDirection(-ghost.movement.direction);
        }
    }

    private IEnumerator ExitTransition()
    {
        // 위치를 수동으로 애니메이션화하는 동안 움직임을 끕니다
        ghost.movement.SetDirection(Vector2.up, true);
        ghost.movement.rigidbody.isKinematic = true;
        ghost.movement.enabled = false;

        Vector3 position = transform.position;

        float duration = 0.5f;
        float elapsed = 0f;

        // 시작 지점으로 애니메이션화합니다
        while (elapsed < duration)
        {
            ghost.SetPosition(Vector3.Lerp(position, inside.position, elapsed / duration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0f;

        // 유령 집을 나가는 애니메이션을 만듭니다
        while (elapsed < duration)
        {
            ghost.SetPosition(Vector3.Lerp(inside.position, outside.position, elapsed / duration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        // 왼쪽 또는 오른쪽의 임의 방향을 선택하고 움직임을 다시 활성화합니다
        ghost.movement.SetDirection(new Vector2(Random.value < 0.5f ? -1f : 1f, 0f), true);
        ghost.movement.rigidbody.isKinematic = false;
        ghost.movement.enabled = true;
    }
}