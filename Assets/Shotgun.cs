using UnityEngine;
using System.Collections;

public class Shotgun : MonoBehaviour
{
    [SerializeField] public GameObject Bullet;
    [SerializeField] public GameObject Target;

    [SerializeField] public float FireRate;
    [SerializeField] public int FireAmount;
    [SerializeField] public float FireSpread;
    [SerializeField] public float FireSpeed;

    private float _fireTimer;
    [HideInInspector] public bool CanFire;


	// Use this for initialization
	void Start ()
	{
	    _fireTimer = 0.0f;
	}
	
	// Update is called once per frame
	public void Update ()
	{
	    _fireTimer += Time.deltaTime;
	    if (_fireTimer >= FireRate)
	    {
	        CanFire = true;
	    }
	}

    public void Fire()
    {
        if (!CanFire) return;
        _fireTimer = 0.0f;

        var targetVector = Target.transform.position - transform.position;
        var targetAngle = Mathf.Atan2(targetVector.y, targetVector.x)*Mathf.Rad2Deg - FireSpread/2;
        for (var i = 0; i < FireAmount; i++)
        {
            FireBullet(targetAngle * Mathf.Deg2Rad);
            targetAngle += FireSpread/FireAmount;
        }
    }

    private void FireBullet(float angle)
    {
        var bullet = Instantiate(Bullet);
        bullet.transform.position = transform.position;
        bullet.tag = "EnemyBullet";

        var rigidbody2D = bullet.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = (new Vector2(Mathf.Cos(angle), Mathf.Sin(angle))) * FireSpeed;
    }
}
