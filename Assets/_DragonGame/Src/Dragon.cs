using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dragon : Character
{
    [SerializeField] float closeEnoughDistance = 3f;
    [SerializeField] float damagePerSecond = 10f;
    [SerializeField] Transform sightOrigin;
    [SerializeField] LayerMask sightMask = ~0;

    Animator _animator;
    NavMeshAgent _navmeshAgent;

    public Vector3 HeroPosition => GameManager.instance.Hero.transform.position + Vector3.up * 0.5f;

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
        Vector3 heroPosition = HeroPosition;
        float distanceToHero = Vector3.Distance(transform.position, heroPosition);

        switch (CurrentState)
        {
            case State.Idle:
                if (CanSeePlayer()) CurrentState = State.Following;
                break;
            case State.Following:
            case State.Attacking:
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
                break;
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

    bool CanSeePlayer()
    {
        Vector3 heroPosition = HeroPosition;
        bool canSee = false;
        Vector3 hitPos = heroPosition;

        Vector3 dir = (heroPosition - sightOrigin.position).normalized;

        if (Physics.Raycast(sightOrigin.position, dir, out RaycastHit hit, 30f, sightMask))
        {
            if (hit.transform.gameObject.CompareTag("Player")) canSee = true;

            hitPos = hit.point;

            Debug.DrawLine(
                sightOrigin.position,
                hit.point,
                canSee ? Color.green : Color.yellow
            );
        }
        else
        {
            Debug.DrawRay(sightOrigin.position, dir, Color.red);
        }
        return canSee;
    }
}
