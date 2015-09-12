using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class Manager : MonoBehaviour
{
    public List<string> LevelOrder;
    private int _currentLevel;

    [SerializeField] public GameObject Player;
    [SerializeField] public Boss Boss;
    [SerializeField] public GameUI GameUI;

    public UnityAction BossDied;

    public int Wins;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);

        Wins = 0;
        _currentLevel = -1;
    }

    public void OnLevelWasLoaded(int level)
    {
        FindCharacters();
        if (Boss != null)
        {
            GameUI.gameObject.SetActive(true);
        }
        else
        {
            GameUI.gameObject.SetActive(false);
        }
    }

    public void FindCharacters()
    {
        if (Player == null || !Player.gameObject)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }

        if (Boss == null || !Boss.gameObject)
        {
            var bossObject = GameObject.FindGameObjectWithTag("Boss");
            if (bossObject != null)
            {
                Boss = bossObject.GetComponent<Boss>();
                Boss.OnDeathEvent += OnBossDeath;
            }
        }
    }

	void Start ()
	{
        FindCharacters();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Player == null || Boss == null) return;
	}

    public void OnBossDeath(object sender, EventArgs e)
    {
        ++Wins;
        NextLevel();
    }

    public void NextLevel()
    {
        if (_currentLevel == LevelOrder.Count - 1) return;
        ++_currentLevel;

        Application.LoadLevel(LevelOrder[_currentLevel]);
    }
}
