using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Enemy : MonoBehaviour {
    
    private Transform _Player;
    [SerializeField]
    private float _Health;
    [SerializeField]
    private float _Speed;
    [SerializeField]
    private float _Force;
    private float _HealthModifier =1;
    private float _SpeedModifier =1;
    private NavMeshAgent _Agent;
    private Rigidbody _Body;
    
	// Use this for initialization
	void Start () {
        _Health = 100f;
        _Speed = 5f;
        _Health *= _HealthModifier;
        _Speed *= _SpeedModifier;
        _Agent = GetComponent<NavMeshAgent>();
        _Agent.speed = _Speed;
        
	}
	
	// Update is called once per frame
	void Update () {
        _Agent.destination = _Player.position;


        if (_Health <= 0)
        {
            gameObject.SetActive(false);
        }
        
        
	}

    public void Modifie(float modifier)
    {
        _HealthModifier = modifier;
        _SpeedModifier = modifier;
    }

    public void OnTriggerEnter(Collider collider)
    {
        
        if(collider.gameObject.tag == "Player")
        {
            _Agent.isStopped = true;
        }
        
    }

    public void Set_player(GameObject player)
    {
        _Player = player.transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Bullet")
        {
            _Health -= collision.gameObject.GetComponent<Bullet>().Dammage;
            //_Body.AddForce(collision.gameObject.GetComponent<Bullet>().GetDir * _Force, ForceMode.Impulse);
            collision.gameObject.SetActive(false);
            
        }
    }
}
