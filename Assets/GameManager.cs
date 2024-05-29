using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts; //고스트의 움직임

    public Pacman pacman;

    public Transform pallets;

    public int score { get; private set; }

    public int lives { get; private set; }


    private void Start()
    {
        NewGame();
    }
    //아무키나 눌렀을 때 다시시작.
    private void Update()
    {
        if (this.lives <= 0 && Input.anyKeyDown) {
            NewGame();
            
        }
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound()
    {
        foreach(Transform pellet in this.pallets){
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState()
    {
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(true);
        }
        this.pacman,gameObject.SetActive(true);

    }
    //팩맨이 잡아먹혔을 때 게임오버.
    private void GameOver()
    {
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(false);
        }
        this.pacman,gameObject.SetActive(false);
    }

    private void SetScore(int score)
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

    //고스트를 먹었을때 추가점수.
    public void GhostEaten(Ghost ghost)
    {
        SetScore(this.score + ghost.points);
    }
    //팩맨이 잡아 먹혔을 때
    //1.목숨이 0개보다 많으면 목숨이 1개씩 줄어들고 다시시작.(3초 뒤에 다시 시작)
    //2.목숨이 0개 이하면 게임오버.
    public void PacmanEaten()
    {
        this.pacman.gameObject.SetActive(false);

        SetLives(this.lives - 1);
        if(this lives > 0){
            Invoke(nameof(ResetState), 3.0f);
        }else
        {
            GameOver();
        }
    }
}

