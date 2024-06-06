using UnityEngine;

// PowerPellet 클래스는 Pellet 클래스를 상속받습니다.
// PowerPellet은 특정 기간 동안 특별한 능력을 부여하는 펠릿입니다.
public class PowerPellet : Pellet 
{
    public float duration = 8.0f; // duration 변수는 PowerPellet의 효과 지속 시간을 나타냅니다. (기본 값 : 8.0초)

    protected override void Eat() // Eat 메소드는 PowerPellet이 먹힐 때 호출합니다. Pellet 클래스의 Eat 메소드를 override 합니다.
    {
        FindObjectOfType<GameManager>().PowerPelletEaten(this);
        // GameManager 객체를 찾아서 PowerPelletEaten 메서드를 호출합니다. 
        // 현재 PowerPellet 인스턴스를 매개변수로 전달합니다.
    }
    
}
