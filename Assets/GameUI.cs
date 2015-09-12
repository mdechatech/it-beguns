using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    private Manager _manager;

    public Image _healthBar;
	// Use this for initialization
	void Start ()
	{
        DontDestroyOnLoad(gameObject);
	    var managerObject = GameObject.FindGameObjectWithTag("Manager");
	    if(managerObject != null) _manager = GameObject.FindGameObjectWithTag("Manager")
	        .GetComponent<Manager>();
	}
	
	// Update is called once per frame
	public void Update ()
	{
	    if (_manager == null || _manager.Boss == null) return;
	    _healthBar.transform.localScale = Vector3.Lerp(_healthBar.transform.localScale,
            new Vector3(
            _manager.Boss.CurrentHealth / (float)_manager.Boss.Health,
            _healthBar.transform.localScale.y,
            _healthBar.transform.localScale.z),
            Time.deltaTime * 5.0f);
	}
}
