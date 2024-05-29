using UnityEngine;
public class GameManager : MonoBehaviour
{
<<<<<<< HEAD
    public Ghost[] ghosts; //고스트의 움직임

    public Pacman pacman;

    public Transform pallets;
=======
    public Ghost[] ghosts;
    public Pacman pacman;
    public Transform pellets;
>>>>>>> d4586f63434c2f0c5ce66827715b71fac83b5eab

    public int score { get; private set; }
    public int lives { get; private set; }


    private void Start()
    {
        NewGame();
<<<<<<< HEAD
    }
    //아무키나 눌렀을 때 다시시작.
    private void Update()
    {
        if (this.lives <= 0 && Input.anyKeyDown)
        {
            NewGame();

        }
=======
>>>>>>> d4586f63434c2f0c5ce66827715b71fac83b5eab
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound()
    {
<<<<<<< HEAD
        foreach (Transform pellet in this.pallets)
        {
=======
        foreach (Transform pellet in this.pellets){
>>>>>>> d4586f63434c2f0c5ce66827715b71fac83b5eab
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState()
    {
<<<<<<< HEAD
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(true);
        }
        this.pacman,gameObject.SetActive(true);
=======
        for (int i=0; i<this.ghosts.Length; i++){
            this.ghosts[i].gameObject.SetActive(true);
        }

        this.pacman.gameObject.SetActive(true);
    }
>>>>>>> d4586f63434c2f0c5ce66827715b71fac83b5eab

    }
    //팩맨이 잡아먹혔을 때 게임오버.
    private void GameOver()
    {
<<<<<<< HEAD
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(false);
        }
        this.pacman,gameObject.SetActive(false);
=======
        for (int i=0; i<this.ghosts.Length; i++){
            this.ghosts[i].gameObject.SetActive(false);
        }

        this.pacman.gameObject.SetActive(false);
>>>>>>> d4586f63434c2f0c5ce66827715b71fac83b5eab
    }

    private void SetScore(int score)
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

<<<<<<< HEAD
    //고스트를 먹었을때 추가점수.
=======
>>>>>>> d4586f63434c2f0c5ce66827715b71fac83b5eab
    public void GhostEaten(Ghost ghost)
    {
        SetScore(this.score + ghost.points);
    }
    //팩맨이 잡아 먹혔을 때
    //1.목숨이 0개보다 많으면 목숨이 1개씩 줄어들고 다시시작.(3초 뒤에 다시 시작)
    //2.목숨이 0개 이하면 게임오버.
    public void PacmanEaten()
    {
        this.pacman.gmaeObject.SetActive(false);

        SetLives(this.lives - 1);
<<<<<<< HEAD
        if (this lives > 0){
            Invoke(nameof(ResetState), 3.0f);
        }else
        {
=======

        if(this.lives > 0){
            Invoke(nameof(ResetState), 3.0f);
        } else {
>>>>>>> d4586f63434c2f0c5ce66827715b71fac83b5eab
            GameOver();
        }

    }
<<<<<<< HEAD
}
=======
}
>>>>>>> d4586f63434c2f0c5ce66827715b71fac83b5eab
