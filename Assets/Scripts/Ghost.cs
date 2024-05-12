using UnityEngine;

/// <summary>
/// 일반적인(home, scatter, chase, frightened) 고스트의 행동제어
/// </summary>
public class Ghost : MonoBehaviour
{
    // home, scatter, chase, frightened간 서로 참조하며 전환 위해 프로퍼티 추가
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

}
