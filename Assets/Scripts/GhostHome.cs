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
        StartCoroutine(ExitTransition());
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
            Vector3 newPosition = Vector3.Lerp(position, this.inside.position, elapsed / duration);
            newPosition.z = position.z;
            this.Ghost.transform.position = newPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0.0f;

        while ( elapsed < duration) {
            Vector3 newPosition = Vector3.Lerp(this.inside.position, this.outside.position, elapsed / duration);
            newPosition.z = position.z;
            this.Ghost.transform.position = newPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }

        // 고스트가 집을 나오고 좌우 방향중 랜덤하게 움직임
        this.Ghost.Movement.SetDirection(new Vector2(Random.value < 0.5f ? -1.0f : 1.0f, 0.0f), true);
        this.Ghost.Movement.Rigidbody.isKinematic = true;
        this.Ghost.Movement.enabled = false;
    }
}
