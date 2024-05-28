using UnityEngine;

public class GhostFrightened : GhostBehaviour
{
    public SpriteRenderer frightenedBody;
    public SpriteRenderer normalBody;

    public bool IsEaten { get; private set; }

    public override void Enable(float duration)
    {
        base.Enable(duration);

        // ...frightened 스프라이트 활성화...

        Invoke(nameof(Flash), duration / 2.0f);
    }
    
    public override void Disable()
    {
        base.Disable();

        // ...frightened 스프라이트 비활성화...(animation)
    }

    private void Flash()
    {
        if (!this.IsEaten)
        {
            // ...frightened 스프라이트 비활성화...
        }
    }

    private void Eaten() 
    {
        this.IsEaten = true;
        
        Vector3 position = this.Ghost.Home.inside.position;
        position.z = this.Ghost.transform.position.z;
        this.Ghost.transform.position = position;

        this.Ghost.Home.Enable(this.duration);

        // ...frightened 스프라이트 비활성화...
    }

    private void OnEnable()
    {
        this.Ghost.Movement.speedMultiplier = 0.5f; // frightened 모드일때 이동속도 줄어듬.
        this.IsEaten = false;
    }

    private void OnDisable()
    {
        this.Ghost.Movement.speedMultiplier = 1.0f;
        this.IsEaten = false;
    }

    // 팩맨에게 잡혔을 때 실행 됩니다.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman")) {
            if (this.enabled) {
                Eaten();
            }
        }
    }

    // frightened 해제 되면 실행됩니다.
    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>(); // 노드와 충돌시 노드 컴포넌트 가져옵니다.

        // frightened모드 우선 수행
        if (node != null && this.enabled)
        {
            Vector2 direction = Vector2.zero;
            float maxDistance = float.MinValue;

            // 팩맨에게 가장 가까운 방향을 foreach로 탐색
            foreach (Vector2 availableDirection in node.AvailableDirections)
            {
                Vector3 newPosition = this.transform.position + new Vector3(availableDirection.x, availableDirection.y, 0.0f);
                float distance = (this.Ghost.target.position - newPosition).sqrMagnitude;

                if (distance > maxDistance)
                {
                    direction = availableDirection;
                    maxDistance = distance;
                }
            }

            this.Ghost.Movement.SetDirection(direction);

        }
    }
}
