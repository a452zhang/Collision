using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour, IHealth
{
    private Transform trans;
    private Vector2 v1;
    private Rigidbody2D rig;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject explosion;
    private Collider2D coll;

    private AudioSource bulletMusic;
    private float MaxX;
    private float MaxY;
    private float MinX;
    private float MinY;
    private int health = 1;

    public int Health { get { return health; } set { health = value; } }

    public delegate void OnDead();
    public event OnDead OnDeadEvent;
    private void Awake()
    {
        trans = GetComponent<Transform>();
        rig = GetComponent<Rigidbody2D>();
        bulletMusic = GetComponent<AudioSource>();
        coll = GetComponent<Collider2D>();
    }

    private void Start()
    {
        MaxX = ScreenXY.MaxX;
        MinX = ScreenXY.MinX;
        MaxY = ScreenXY.MaxY;
        MinY = ScreenXY.MinY;

        coll.enabled = false;
        StartCoroutine(Decorate());
    }

    private void Update()
    {
        v1 = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        trans.Translate(v1 * Time.deltaTime * speed);
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
            bulletMusic.Play();
        }
        ClampFrame();
    }
    private void FixedUpdate()
    {
        Move(v1);
    }
    private void ClampFrame()
    {
        trans.position = new Vector3(Mathf.Clamp(trans.position.x, MinX, MaxX),
                                     Mathf.Clamp(trans.position.y, MinY, MaxY),
                                     trans.position.z
                                    );
    }
    private void Move(Vector2 v1)
    {
        rig.velocity = v1 * speed;
    }

    private IEnumerator Decorate()
    {
        yield return new WaitForSeconds(2);
        coll.enabled = true;
    }
   

    private void Fire()
    {
        Instantiate(bullet, trans.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (!coll.gameObject.CompareTag(gameObject.tag))
        {
            Damage(100);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            Destroy(collision.gameObject);
        }
    }

    public void Damage(int value)
    {
        Health -= value;
        print("飞机血量：" + Health);
        if (Health <= 0)
        {
            DestroySelf();
        }
    }
    public void DestroySelf()
    {
        Instantiate(explosion, trans.position, Quaternion.identity);
        if (OnDeadEvent != null)
        {
            OnDeadEvent();
        }
        Destroy(this.gameObject);
    }
}
