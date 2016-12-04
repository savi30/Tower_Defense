using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int wayPointIndex = 0;

    void Start()
    {
        target = WayPoints.points[0];
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
            Destroy(gameObject);
            return;
        }
        wayPointIndex++;
        target = WayPoints.points[wayPointIndex];
    }
	
}
