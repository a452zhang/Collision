using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelDirector : MonoBehaviour {
    
    private int planeLife = 3;
    public int PlaneLife
    { get {
            return planeLife;
        } private 
      set {
            planeLife = value;
        }
    }
    public Action GameStartAction;
    public Action GameOverAction;
    private static LevelDirector instance;
    public static LevelDirector Instance
    {
        get
        {
            if (instance == null)
            {
                throw new NullReferenceException("No LevelDirector in scene");
            }
            return instance;
        }
    }
    [SerializeField] private Plane plane;
    [SerializeField] private GameObject monster;
    [SerializeField] private PlayerData date;
    

    private int score;
    private int maxScore;

    public int Score
    {
        get { return score; }
        set {
            score = value;
            if (score >= maxScore)
            {
                date.maxScore = value;
                maxScore = value;
            }
        }
    }

    public int MaxScore
    {
        get { return maxScore; }
    }

    private Plane currentAirPlane;

    private void Awake()
    {
        
        instance = this;
        Init();
        
        // Instantiate(monster, monster.transform.position, Quaternion.identity);
    
    }
	
	private void Start () {
        StartCoroutine(Decorate());
    }

    private void Init()
    {
        plane = Resources.Load<Plane>("Prefabs/Plane");
        monster = Resources.Load<GameObject>("Prefabs/Monster");
        date = Resources.Load<PlayerData>("PlayerData");
        maxScore = date.maxScore;
    }

    private IEnumerator Decorate()
    {
        yield return new WaitForSeconds(2);
        currentAirPlane = Instantiate(plane, plane.transform.position, Quaternion.identity);
        Instantiate(monster, monster.transform.position, Quaternion.identity);
        currentAirPlane.OnDeadEvent += OnPlaneDead;
    }
    private void OnPlaneDead()
    {
        PlaneLife--;
        if (PlaneLife > 0)
        {
            StartCoroutine(Decorate());
        }
        else
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        if (GameOverAction != null)
        {
            GameOverAction();
        }
    }

}
