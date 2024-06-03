using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerUI : MonoBehaviour
{
    public int totalPoint;
    public int stagePoint;
    public int stageIndex;
    public int health;
    public int PlayerMove player;
    public int GameObject[] Stages;

    public Image[] UIhealth;
    public Text UIPoint;
    public Text UIStage;
    public GameObject RestartBtn;

    void update()
    {
        UIPoint.text = (totalPoint + stagePoint).ToString();
    }

    public void NextStage()
    {
        //Change Stage
        if(stageIndex < stages.Length-1){
            Stages[stageIndex].SetActive(false);
            stageIndex++;
            Stages[stageIndex].SetActive(true);
            PlayerReposition();

            UIStage.text = "STAGE " + (stageIndex + 1);
        }
        else{ //Game Clear
        //Player Contol Lock
        Time.timeScale = 0;
        //Result UI
        Debug.Log("게임 클리어!");
        //Restart Button UI
         UIRestartBtn.SetActive(true);
         Text btnText = UIRestartBtn.GetComponentInChildren<Text>();
         UIRestartBtn.SetActive(true);
        }

        //Calculate Point
        totalPoint += stagePoint;
        stagePoint = 0;
    }

    public void HealthDown()
    {
        if(health > 1){
            health--;
            UIhealth[health].color = new Color(1, 0, 0, 0.4f);
        }
            else{
                //Player Die Effect
                player.OnDie();
                //Result UI
                Debug.Log("죽었습니다!");
                //Retry Button UI
                UIRestartBtn.SetActive(true);
            }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            //Player Reposition
            if(health > 1)
            PlayerReposition();

            //Health Down
            HealthDown();
        }
    }

    void PlayerReposition()
    {
        player transform.position = new Vector3(0, 0, -1);
        player.VelocityZero();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}




