using UnityEngine;

public class Passage : MonoBehaviour // 이 클래스는 다른 게임 오브젝트가 이 오브젝트의 Collider에 들어갈 때 다른위치로 텔레포트 시키는 역할을 함.
{
    public Transform connection; // Public 변수를 통해 Unity 에디터에서 연결된 Transform을 설정할 수 있음.
    private void OnTriggerEnter2D(Collider2D other) // 2D Collider가 이 오브젝트의 Trigger에 들어갈 때 호출됨.
    {
        Vector3 position = other.transform.position; // 충돌한 오브젝트의 현재위치를 가져옴.
        position.x = this.connection.position.x; // 충돌한 오브젝트의 위치를 이 오브젝트의 connection 위치로 바꿈.
        position.y = this.connection.position.y;
        other.transform.position = position; // 변경된 위치를 충돌한 오브젝트에 적용함.
    }
}
