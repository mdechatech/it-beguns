using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    public int Health;

    [SerializeField] 
    public UnityEvent OnDeath;

    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        var bullet = collider2D.GetComponent<Bullet>();
        if (bullet == null) return;

        Destroy(bullet.gameObject);
        --Health;

        if (Health <= 0)
        {
            OnDeath.Invoke();
        }
    }
}
