using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour
{
    [SerializeField]
    protected float speed = 1.0f;
    [SerializeField]
    protected int power = 1;

    protected Transform trans;
    private string myTag;

    private void Awake()
    {
        myTag = gameObject.tag;
        trans = GetComponent<Transform>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        Move();
    }
    protected abstract void Move();
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<IHealth>() != null && !other.CompareTag(myTag))
        {
            other.GetComponent<IHealth>().Damage(power);
        }
    }
}
