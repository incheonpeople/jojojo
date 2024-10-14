using System;
using UnityEngine;

    public class TopDownMovement : MonoBehaviour
    {
    // 실제로 이동이 일어날 컴포넌트

    private TopDownController controller;
    private Rigidbody2D movementRigidbody;
    private CharacterStatHandler characterStatHandler;

    private Vector2 movementDirection;

    private void Awake()
        
        // 주로 내 컴포넌트 안에 끝나는거
    {
        //controller랑 TopDownMovement랑 같은 게임 오브젝트 안에 있다라는 가정
        controller = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        characterStatHandler = GetComponent<CharacterStatHandler>();
        

    }

    private void Start()
    {
        controller.OnMoveEvent += Move; // ctrl+ . +Enter 치면 밑에 move 정의하는 스크립트 나옴

    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction; //정의 안되어 있어서 필드생성으로 해줘서 빨간줄 지움
    }

    private void FixedUpdate()
    {
        // FixedUpdate는 물리 업데이트 관련
        // rigidbody의 값을 바꾸니까 FixedUpdate
        ApplyMovement(movementDirection);

    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * characterStatHandler.CurrentStat.speed;
        movementRigidbody.velocity = direction;
    }
}
