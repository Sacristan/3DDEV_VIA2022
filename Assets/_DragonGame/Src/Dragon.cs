using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Character
{
    [SerializeField] float closeEnoughDistance = 3f;
    [SerializeField] float damagePerSecond = 10f;
    Animator _animator;

    enum State
    {
        None,
        Idle,
        Attacking
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

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        CurrentState = State.Idle;
    }

    private void Update()
    {
        Vector3 heroPosition = GameManager.instance.Hero.transform.position;
        float distanceToHero = Vector3.Distance(transform.position, heroPosition);

        if (distanceToHero < closeEnoughDistance)
        {
            GameManager.instance.Hero.AddDamage(Time.deltaTime * damagePerSecond);
            CurrentState = State.Attacking;
        }
        else
        {
            CurrentState = State.Idle;
        }
    }

    void UpdateState()
    {
        Debug.Log("UpdateState: " + CurrentState);

        int animState = _animator.GetInteger("state");
        if ((int)CurrentState != animState) _animator.SetInteger("state", (int)CurrentState);
    }

}
