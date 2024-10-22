using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable
{
  //Create enemy personality
  //    - Don't look at the enemy all the  time
  //    - Random Attack coldDown
  //    - Don't regenerate
  //    - Offer a reward when Die 

  //Animator AC_ChestMonster
  // IsPlayerNear -> bool when player collider 
  // IsHitting    -> trigger when enemy get hit by Player
  // WalkSpeed    -> float magnitude speed
  // IsDie        -> bool when enemy die, don't recover.


  [SerializeField] private int _health = 50;
  [SerializeField] private float _walkSpeed = 2f;
  [SerializeField] private float _attackRange = 1.5f;
  [SerializeField] private int _attackDamage = 10;

  private enum EnemyState
  {
    Idle,
    IdleBattle,
    Walk,
    Attack,
    Die
  }

  private EnemyState _currentState;
  private Animator _anim;

  private Transform target;
  private IDamagable damagable;

  private void Start()
  {
    _anim = GetComponent<Animator>();
    _currentState = EnemyState.Idle;

  }


  private void Update() 
  {
       switch (_currentState)
        {
            case EnemyState.Idle:
                // Lógica para el estado "idle"
                _anim.SetBool("IsPlayerNear",false);
                break;

            case EnemyState.IdleBattle:
                // Lógica para el estado "IdleBattle"
                _anim.SetBool("IsPlayerNear",true);
                //Debug.Log("PlayerDetected");
                LookAtPlayer();
                // Follow Player
                break;

            case EnemyState.Walk:
                // Lógica para el estado "walk"
                
                break;

            case EnemyState.Attack:
                // Lógica para el estado "attack"
                  _anim.SetTrigger("Attack");
                  damagable.Damage(_attackDamage);
                                   
                break;

            case EnemyState.Die:
                // Lógica para el estado "die"
                  _anim.SetBool("IsDie", true);
                  Debug.Log("Just Die");
                  Destroy(gameObject, 3f);  
                break;
        }
  }

  public void Damage(int damageAmount)
  {
    _health -= damageAmount;
    //refresh Enemy HUD
    _anim.SetTrigger("IsHitting");

    //check if health is greater than zero
    if (_health <= 0) SetStateDie();
    
    Debug.Log("Get Some Damage, Health on " + _health);
    
  }

    public void SetStateIdle()
    {
        _currentState = EnemyState.Idle;
    }

    public void SetStateIdleBattle()
    {
        _currentState = EnemyState.IdleBattle;
    }

    public void SetStateWalk()
    {
        _currentState = EnemyState.Walk;
    }

    public void SetStateAttack()
    {
        _currentState = EnemyState.Attack;
    }

    public void SetStateDie()
    {
        _currentState = EnemyState.Die;
         Debug.Log("Marked to Die");
    }

  private void OnTriggerStay(Collider other)
  {
    if(other.tag == "Player" && _currentState != EnemyState.Die) SetStateIdleBattle();
    target = other.transform;

  }

  private void OnTriggerExit(Collider other)
  {
    if (other.tag == "Player" && _currentState != EnemyState.Die) SetStateIdle();
  }


  private void LookAtPlayer()
  {
    //if(Random.Range(0f, 1f) < 0.8f) return;
    
    var directionVector = (target.position - transform.position).normalized;
   

    Quaternion lookAtRotation = Quaternion.LookRotation(directionVector, Vector3.up);
    
    transform.rotation = Quaternion.Slerp(transform.rotation, lookAtRotation, Time.deltaTime);

  }

}
