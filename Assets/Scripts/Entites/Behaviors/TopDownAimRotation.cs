using UnityEngine;

public class TopDownAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;

    [SerializeField] private SpriteRenderer characterRenderer;

    private TopDownController controller;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
    }

    private void Start()
    {
        controller.OnLookEvent += OnAim; //컨트롤 점해서 안생기는데?
    }

    private void OnAim(Vector2 direction)
    {
        RotateArm(direction);
    }

    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;

        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
        // 90도보다 크면 뒤집어라 라는 뜻

        armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}