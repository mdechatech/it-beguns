using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Manager : MonoBehaviour
{
    [SerializeField] public GameObject Player;
    [SerializeField] public Boss Boss;

    public UnityAction BossDied;

    public int Wins;

    public void Awake()
    {
        Wins = 0;
    }

    public void OnLevelWasLoaded(int level)
    {
        if (!Player.gameObject)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }

        if (!Boss.gameObject)
        {
            Boss = GameObject.FindGameObjectWithTag("Boss")
                .GetComponent<Boss>();
            Boss.OnDeathEvent += OnBossDeath;
        }
    }

	void Start () {
	    DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Player == null || Boss == null) return;
	}

    public void OnBossDeath(object sender, EventArgs e)
    {
        ++Wins;
    }
}
