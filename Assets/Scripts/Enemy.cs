using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float startSpeed = 10f;
    private float speed;

    public int startHealth = 100;
    private float health;

    public int value = 50;
    public GameObject deathEffect;
    private Transform target;
    private int wayPointIndex = 0;

    [Header("Unity Stuff")]
    public Image healthBar;

    void Start()
    {
        target = WayPoints.points[0];
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    public void SlowDown(float slowDownSpeed)
    {
        speed = slowDownSpeed;
        StartCoroutine(ResetToNormalSpeed());
    }

    IEnumerator ResetToNormalSpeed()
    {
        yield return new WaitForSeconds(2f);
        speed = startSpeed;
    }
    void Die()
    {
        PlayerStats.Money += value;
        GameObject deathEffectInt=(GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deathEffectInt, 3f);
        WaveSpawner.enemiesAlive--;

        Destroy(gameObject);
        
        

    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World);

        if(Vector3.Distance(transform.position,target.position)<=0.4)
        {
            GetNextWayPoint();
        }

    }
    void GetNextWayPoint()
    {
        if(wayPointIndex>= WayPoints.points.Length-1)
        {
            EndPath();
            return;
        }
        wayPointIndex++;
        target = WayPoints.points[wayPointIndex];
    }
	void EndPath()
    {
        Destroy(gameObject);
        WaveSpawner.enemiesAlive--;
        PlayerStats.lives--;
    }

    IEnumerator BumpFont()
    {
        yield return new WaitForSeconds(.1f);
    }
    
}
