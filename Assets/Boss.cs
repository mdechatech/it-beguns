using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Boss : MonoBehaviour
{
    [SerializeField] private string _bulletTag = "Bullet";

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    public int Health = 20;

    [SerializeField] 
    public UnityEvent OnDeath;

    [HideInInspector]
    public event EventHandler<EventArgs> OnDeathEvent;

    [SerializeField] public UnityEvent OnHit;

    public event EventHandler<EventArgs> OnHitEvent;

    private SpriteRenderer _spriteRenderer;

    public void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag != _bulletTag) return;

        Destroy(collider2D.gameObject);
        --Health;

        OnHit.Invoke();
        if (OnHitEvent != null)
        {
            OnHitEvent(this, EventArgs.Empty);
        }

        _spriteRenderer.color = new Color(1.0f, 0.5f, 0.5f, 1.0f);

        if (Health <= 0)
        {
            Health = 0;
            OnDeath.Invoke();
            if (OnDeathEvent != null) OnDeathEvent(this, EventArgs.Empty);
        }
    }

    public void Update()
    {
        _spriteRenderer.color = Color.Lerp(_spriteRenderer.color, Color.white, Time.deltaTime);
    }
}
