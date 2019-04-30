using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class D_GunScript : MonoBehaviour
{
    public GameObject Enemy;
    private float offset = 0.5f;
    public int AmmoCount = 10;
    public float fireTime = 0f;
    public float MaxFireTime = 1f;
    public GameObject BulletPrefab;
    private float Bullet_rotation_z;
    private Vector3 EnemyDir;
    public float BulletSpeed = 3f;
    bool enemyExists = true;

    // Start is called before the first frame update
    void Start()
    {
        //need bullet prefab;
    }

    // Update is called once per frame
    void Update()
    {
        //look towards enemy
        LookAtEnemy();
        //if hit key, then shoot
        if (Input.GetKey(KeyCode.Space) && fireTime <= 0 && AmmoCount > 0 && enemyExists)
        {
            //spawn bullet
            fireTime = MaxFireTime;
            GameObject BulletClone = Instantiate(BulletPrefab, this.transform.position + (Vector3)(EnemyDir * 0.5f), Quaternion.identity);
            BulletClone.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Bullet_rotation_z);
            BulletClone.GetComponent<Rigidbody2D>().velocity = EnemyDir * BulletSpeed;
            AmmoCount--;
        }
        if(fireTime >=0)
        {
            fireTime -= Time.deltaTime;
        }
    }

    void LookAtEnemy()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy == null)
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            enemyExists = false;
            return;
        }
        Vector3 EnemyPos = enemy.transform.position;
        EnemyDir = EnemyPos - this.transform.position;
        EnemyDir.Normalize();
        Bullet_rotation_z = Mathf.Atan2(EnemyDir.y, EnemyDir.x) * Mathf.Rad2Deg;
        if (Bullet_rotation_z > -90 && Bullet_rotation_z < 90)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            this.transform.localScale = new Vector3(1, -1, 1);
        }
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Bullet_rotation_z + offset);
    }
}
