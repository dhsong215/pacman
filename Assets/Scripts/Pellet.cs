using UnityEngine;

public class Pellet : MonoBehaviour
{

    public int points = 10;

    protected virtual void Eat()
    {

    }

    private void OnTriggerEnter2D(Collider2Dother)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman")) {
            Eat();
        }
    }
}
