using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dragon : Character
{
    [SerializeField] float closeEnoughDistance = 3f;
    [SerializeField] float damagePerSecond = 10f;
    Animator _animator;
    NavMeshAgent _navmeshAgent;

    enum State
    {
        None = 0,
        Idle = 1,
        Following = 2,
        Attacking = 3
    }

    State _state = State.None;

    State CurrentState
    {
        get => _state;
        set
        {
            if (_state != value)
            {
                _state = value;
                UpdateState();
            }
        }
    }

    protected override void Start()
    {
        base.Start();
        _animator = GetComponentInChildren<Animator>();
        _navmeshAgent = GetComponent<NavMeshAgent>();
        CurrentState = State.Idle;
    }

    private void Update()
    {
        Vector3 heroPosition = GameManager.instance.Hero.transform.position;
        float distanceToHero = Vector3.Distance(transform.position, heroPosition);

        if (distanceToHero < closeEnoughDistance)
        {
            _navmeshAgent.velocity = Vector3.zero;
            // GameManager.instance.Hero.AddDamage(Time.deltaTime * damagePerSecond);
            CurrentState = State.Attacking;
        }
        else
        {
            CurrentState = State.Following;
        }

        switch (CurrentState)
        {
            case State.Following:
                _navmeshAgent.SetDestination(heroPosition);
                break;
        }
    }

    void UpdateState()
    {
        Debug.Log("UpdateState: " + CurrentState);

        int animState = _animator.GetInteger("state");
        if ((int)CurrentState != animState) _animator.SetInteger("state", (int)CurrentState);
    }

    public void Bite()
    {
        if (CurrentState == State.Attacking) GameManager.instance.Hero.AddDamage(damagePerSecond);
    }
}
