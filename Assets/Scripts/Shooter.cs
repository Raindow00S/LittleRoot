using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FPoint;

    public float bulletRate;//发射子弹的速度
    public float lastFireTime;//上一次发射子弹的时间
    
    public List<float> listShootAngle = new List<float>(); // 发射方向

    public bool isAutoShoot;
    public KeyCode shootKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAutoShoot)
        {
            if (lastFireTime + bulletRate > Time.time)
                return;
            lastFireTime = Time.time;
            GenBullets();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GenBullets();
            }
        }
    }

    private void GenBullets()
    {
        foreach (var angle in listShootAngle)
        {
            var newBullet = Instantiate(Bullet, FPoint.position, FPoint.rotation).GetComponent<Bullet>();
            newBullet.angle = angle;
        }  
    }
}
