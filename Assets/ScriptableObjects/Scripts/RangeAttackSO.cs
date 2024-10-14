using UnityEngine;

[CreateAssetMenu(fileName = "RangedAttackSo", menuName = "TopDownController/Attacks/Ranged", order = 1)]
public class RangeAttackSO : AttackSO
{
    [Header("Ranged Attack Info")]
    public string bulletNameTag;
    public float duration;
    public float spread;
    public int numberOfprojectilePerShot;
    public float multipleProjectilesAngle;
    public Color projectileColor;
}