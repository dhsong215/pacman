using System.Collections;
using UnityEngine;

public class GhostHome : GhostBehaviour
{
    public Transform inside;
    public Transform outside;

    private void OnEnable()
    {
        StopAllCoroutines();
    }

    private void OnDisable()
    {
        if (gameObject.activeInHierarchy) {
            StartCoroutine(ExitTransition());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 집 안에서 벽에 부딛히면 반대방향으로 이동
        if (enabled && collision.gameObject.layer == LayerMask.NameToLayer("Obstacle")) {
            Ghost.Movement.SetDirection(-Ghost.Movement.Direction);
        }
    }

    private IEnumerator ExitTransition()
    {
        // 고스트가 집의 중앙에 있을때 위로 빠져나가게 함
        this.Ghost.Movement.SetDirection(Vector2.up, true);
        this.Ghost.Movement.Rigidbody.isKinematic = true;
        this.Ghost.Movement.enabled = false;

        Vector3 position = this.transform.position;

        float duration = 0.5f;
        float elapsed = 0.0f;

        // 문으로 탈출까지의 시간을 측정해서 집 안에서 맴돌게 함
        while ( elapsed < duration) {
            Ghost.SetPosition(Vector3.Lerp(position, inside.position, elapsed / duration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0.0f;

        while ( elapsed < duration) {
            Ghost.SetPosition(Vector3.Lerp(inside.position, outside.position, elapsed / duration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        // 고스트가 집을 나오고 좌우 방향중 랜덤하게 움직임
        this.Ghost.Movement.SetDirection(new Vector2(Random.value < 0.5f ? -1.0f : 1.0f, 0.0f), true);
        this.Ghost.Movement.Rigidbody.isKinematic = true;
        this.Ghost.Movement.enabled = false;
    }
}
