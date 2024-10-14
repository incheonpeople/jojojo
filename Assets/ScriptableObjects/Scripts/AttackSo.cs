using UnityEngine;

[CreateAssetMenu(fileName = "DefaultAttackSo", menuName = "TopDownCoitroller/Attacks/Default", order = 0)]

public class AttackSO : ScriptableObject
{
    [Header("Attack Info")]
    public float size;
    public float delay;
    public float power;
    public float speed;
    public LayerMask target;

    [Header("knock Back Info")]
    public bool isOnKnockBack;
    public float knockbackPower;
    public float knockbackTime;

}
