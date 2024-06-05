using UnityEngine;

public class GhostFrightened : GhostBehavior
{
    // 유령의prefab을 제어하는 스프라이트들
    public SpriteRenderer body;
    public SpriteRenderer eyes;
    public SpriteRenderer blue;
    public SpriteRenderer white;

    private bool eaten;

    // 지정된 지속 시간 동안 frightened 모드를 활성화
    public override void Enable(float duration)
    {
        base.Enable(duration);

        // 유령의 모습을 frightened 모드로 변경
        body.enabled = false;
        eyes.enabled = false;
        blue.enabled = true;
        white.enabled = false;

        // frightened 모드 지속 시간의 절반 후에 깜박이기 시작
        Invoke(nameof(Flash), duration / 2f);
    }

    // frightened 모드를 비활성화하고 모습을 되돌림
    public override void Disable()
    {
        base.Disable();

        // 유령의 모습을 정상으로 되돌림
        body.enabled = true;
        eyes.enabled = true;
        blue.enabled = false;
        white.enabled = false;
    }

    // 유령이 팩맨에게 먹혔을 때 처리
    private void Eaten()
    {
        eaten = true;
        // 유령을 유령 집으로 되돌림
        ghost.SetPosition(ghost.home.inside.position);
        ghost.home.Enable(duration);

        // 유령의 모습을 눈만 보이도록 변경 (팩맨에 먹혔으ㄹ때ㅔ)
        body.enabled = false;
        eyes.enabled = true;
        blue.enabled = false;
        white.enabled = false;
    }

    // frightened 모드의 끝부분에서 유령의 모습을 깜박이게 함
    private void Flash()
    {
        if (!eaten)
        {
            blue.enabled = false;
            white.enabled = true;
            white.GetComponent<AnimatedSprite>().Restart();
        }
    }

    // frightened 모드가 활성화될 때 설정
    private void OnEnable()
    {
        // frightened 스프라이트의 애니메이션을 재시작
        blue.GetComponent<AnimatedSprite>().Restart();
        // 유령의 이동 속도를 늦춤
        ghost.movement.speedMultiplier = 0.8f;
        eaten = false;
    }

    // frightened 모드가 비활성화될 때 정리
    private void OnDisable()
    {
        // 유령의 이동 속도를 되돌림
        ghost.movement.speedMultiplier = 1f;
        eaten = false;
    }

    // frightened 모드에서 이동할 방향을 결정
    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null && enabled)
        {
            Vector2 direction = Vector2.zero;
            float maxDistance = float.MinValue;

            // 팩맨으로부터 가장 멀리 이동하는 방향을 찾음
            foreach (Vector2 availableDirection in node.availableDirections)
            {
                Vector3 newPosition = transform.position + new Vector3(availableDirection.x, availableDirection.y);
                float distance = (ghost.target.position - newPosition).sqrMagnitude;

                if (distance > maxDistance)
                {
                    direction = availableDirection;
                    maxDistance = distance;
                }
            }

            // 유령의 이동 방향을 설정
            ghost.movement.SetDirection(direction);
        }
    }

    // 팩맨과의 충돌을 처리
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if (enabled) {
                Eaten();
            }
        }
    }

}
