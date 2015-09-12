using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Boss : MonoBehaviour
{
    [SerializeField] private string _bulletTag = "Bullet";

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    public int Health;

    [SerializeField] 
    public UnityEvent OnDeath;

    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag != _bulletTag) return;

        Destroy(collider2D.gameObject);
        --Health;

        if (Health <= 0)
        {
            OnDeath.Invoke();
        }
    }
}
