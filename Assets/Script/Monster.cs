using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour,IHealth
{
    private BoxCollider2D coll;
    private Renderer rend;
    private Transform trans;

    [SerializeField]
    private float repeatRate = 1;
    [SerializeField]
    private GameObject bulletPrefab;


    private float MaxX;
    private float MaxY;
    private float MinX;
    private float MinY;
    private Vector3 direction;
    private int health = 10;

    public int Health { get { return health; } set { health = value; } }

    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
        rend = GetComponent<Renderer>();
        trans = GetComponent<Transform>();
    }
    private void Start()
    {
        InvokeRepeating("Fire",0f,repeatRate);
        MaxX = ScreenXY.MaxX;
        MaxY = ScreenXY.MaxY;
        MinX = ScreenXY.MinX;
        MinY = ScreenXY.MinY;
        direction = Vector3.left;
    }

    private void Update()
    {
        if (trans.position.x > MaxX)
        {
            direction = Vector3.left;
        }
        else if (trans.position.x < MinX)
        {
            direction = Vector3.right;
        }
        LBMove();      
    }
    private void LBMove()
    {
        trans.Translate(direction * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void Fire()
    {
        Instantiate(bulletPrefab, this.trans.position, Quaternion.identity);
    }
    public void Damage(int value)
    {
        Health -= value;
        print("怪兽血量：" + Health);
        if (Health <=0)
        {
            Destroy(this.gameObject);
        }
    }
}
