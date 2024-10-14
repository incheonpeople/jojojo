using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent; // Action�� ������ void�� ��ȯ�ؾ� �ƴϸ� Func
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;

    protected bool IsAttacking { get; set; } // ��ӹ޴� �Լ��� �����

    private float timeSinceLastAttack = float.MaxValue;
     
    protected CharacterStatHandler stats { get; private set; } // [�߰�] // �̰��� ���ؼ� stats.CurrentStat.attackSO.delay ������ �Ǿ���
    // protected ������Ƽ�� �� ����: ���� �ٲٰ� ������ �������°� �� ��ӹ޴� Ŭ�����鵵 �� �� �ְ�!
    protected virtual void Awake() // protected�� �ٲ���
    {
        stats = GetComponent<CharacterStatHandler>(); // [�߰�]
    }

    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if(timeSinceLastAttack <= stats.CurrentStat.attackSO.delay) // [�߰�]
        {
            timeSinceLastAttack += Time.deltaTime;

        }
        if(IsAttacking && timeSinceLastAttack > stats.CurrentStat.attackSO.delay)
        {
            timeSinceLastAttack = 0f;
            CallAttackEvent(stats.CurrentStat.attackSO);
        }
    }


    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); // ?.������ ���� ������ ����
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    private void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }
}
