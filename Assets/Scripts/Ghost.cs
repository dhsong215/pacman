using UnityEngine;

/// <summary>
/// 일반적인(home, scatter, chase, frightened) 고스트의 행동제어
/// </summary>
public class Ghost : MonoBehaviour
{
    // home, scatter, chase, frightened간 서로 참조하며 전환 위해 프로퍼티 추가
    public Rigidbody2D Rigidbody {get; private set;}
    public Movement Movement {get; private set;}
    public GhostHome Home {get; private set;}
    public GhostScatter Scatter {get; private set;}
    public GhostChase Chase {get; private set;}
    public GhostFrightened Frightened {get; private set;}
    public GhostBehaviour initialBehaviour;
    public Transform target;

    // 고스트의 점수
    public int points = 200;

    private void Awake()
    {
        this.Movement = GetComponent<Movement>();
        this.Home = GetComponent<GhostHome>();
        this.Scatter = GetComponent<GhostScatter>();
        this.Chase = GetComponent<GhostChase>();
        this.Frightened = GetComponent<GhostFrightened>();
    }

    public void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.Movement.ResetState();
        this.Scatter.Enable();
        this.Frightened.Disable();
        this.Chase.Disable();

        if (this.Home != this.initialBehaviour) {
            this.Home.Disable();
        }

        if (this.initialBehaviour != null) {
            this.initialBehaviour.Enable();
        }
    }

    // Pacman과 충돌시에 발생하는 이벤트입니다.
    // Frightened일 때와 아닐때 두가지로 나뉩니다.
    // GameManager 개발이 계속 미뤄져서 임시적으로 만들어 놨습니다.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.layer == LayerMask.NameToLayer('Pacman')) {
        //     if (this.Frightened.enabled) {
        //         FindObjectOfType<GameManager>().GhostEaten(this);
        //     } else {
        //         FindObjectOfType<GameManager>().PacmanEaten();
        //     }
        // }
    }

}
