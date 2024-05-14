using UnityEngine;

public class Pellet : MonoBehaviour
{

    public int points = 10;

    protected virtual void Eat()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) // Collider2Dother --> Collider2D other
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman")) {
            Eat();
        }
    }
}
