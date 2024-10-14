using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent; // Action은 무조건 void만 반환해야 아니면 Func
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;

    protected bool IsAttacking { get; set; } // 상속받는 함수만 연결됨

    private float timeSinceLastAttack = float.MaxValue;
     
    protected CharacterStatHandler stats { get; private set; } // [추가] // 이것을 통해서 stats.CurrentStat.attackSO.delay 적용이 되었음
    // protected 프로퍼티를 한 이유: 나만 바꾸고 싶지만 가져가는건 내 상속받는 클래스들도 볼 수 있게!
    protected virtual void Awake() // protected로 바꾸자
    {
        stats = GetComponent<CharacterStatHandler>(); // [추가]
    }

    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if(timeSinceLastAttack <= stats.CurrentStat.attackSO.delay) // [추가]
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
        OnMoveEvent?.Invoke(direction); // ?.없으면 말고 있으면 실행
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
