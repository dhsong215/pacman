// 일반적인 고스트의 행동제어 클래스
using UnityEngine;

public class Ghost : MonoBehaviour
{
    // home, scatter, chase, frightened간 서로 참조하며 전환 위해 프로퍼티 추가
    // public Movement movement {get; private set;}
    public GhostHome home {get; private set;}
    public GhostScatter scatter {get; private set;}
    public GhostChase chase {get; private set;}
    public GhostFrightened frightened {get; private set;}
    public GhostBehaviour initialBehaviour;
    public Transform target;

    // 고스트의 점수
    public int points = 200;

    private void Awake()
    {
        // this.movement = GetComponent<Movement>();
        this.home = GetComponent<GhostHome>();
        this.scatter = GetComponent<GhostScatter>();
        this.chase = GetComponent<GhostChase>();
        this.frightened = GetComponent<GhostFrightened>();
    }

}
