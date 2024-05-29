using UnityEngine;

// 실행 순서를 -10으로 설정하여 Movement 스크립트보다 먼저 실행되게 함
[DefaultExecutionOrder(-10)]
// Movement 컴포넌트가 반드시 필요함을 명시
[RequireComponent(typeof(Movement))]
public class Ghost : MonoBehaviour
{
    // 고스트의 다양한 상태 및 행동 컴포넌트
    public Movement movement { get; private set; }
    public GhostHome home { get; private set; }
    public GhostScatter scatter { get; private set; }
    public GhostChase chase { get; private set; }
    public GhostFrightened frightened { get; private set; }
    // 초기 상태를 설정할 고스트 행동
    public GhostBehavior initialBehavior;
    // 고스트의 타겟
    public Transform target;
    // 고스트를 잡았을 때 얻는 점수
    public int points = 200;

    private void Awake()
    {
        // 필요한 컴포넌트를 가져옴
        movement = GetComponent<Movement>();
        home = GetComponent<GhostHome>();
        scatter = GetComponent<GhostScatter>();
        chase = GetComponent<GhostChase>();
        frightened = GetComponent<GhostFrightened>();
    }

    private void Start()
    {
        // 초기 상태로 리셋
        ResetState();
    }

    public void ResetState()
    {
        // 고스트를 활성화하고 모든 상태 초기화
        gameObject.SetActive(true);
        movement.ResetState();

        // 초기 상태 설정
        frightened.Disable();
        chase.Disable();
        scatter.Enable();

        if (home != initialBehavior) {
            home.Disable();
        }

        if (initialBehavior != null) {
            initialBehavior.Enable();
        }
    }

    public void SetPosition(Vector3 position)
    {
        // z-위치를 유지하며 위치 설정 (z-위치는 그리기 순서를 결정)
        position.z = transform.position.z;
        transform.position = position;
    }

    // 충돌 감지와 관련된 처리는 GameManager 스크립트에서 관리하도록 함
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     // Pacman과의 충돌 시 처리 로직
    //     // if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
    //     // {
    //     //     if (frightened.enabled) {
    //     //         GameManager.Instance.GhostEaten(this);
    //     //     } else {
    //     //         GameManager.Instance.PacmanEaten();
    //     //     }
    //     // }
    // }
}