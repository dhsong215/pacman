using UnityEngine;

public class Pellets : MonoBehaviour /* MonoBehaviour을 상속받은 'Pellet' 클래스 
: 개임 내에서 플레이어가 상속받을 수 있는 아이템을 나타냄. */
{

    public int points = 10; // Pellet이 먹혔을 때 얻을 수 있는 점수를 나타냄.

    protected virtual void Eat()
    {
        
    } 

    private void OnTriggerEnter2D(Collider2D other) // Collider2Dother --> Collider2D other
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman")) {
            Eat();
        } // 충돌한 Object가 PacMan(Player) Object인지 확인하고, 맞다면 Eat()을 호출함.
    }   
}
