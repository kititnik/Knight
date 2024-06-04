using UnityEngine;
using UnityEngine.Serialization;

namespace ConfigurationScripts
{
    [CreateAssetMenu(fileName = "EnemyConfiguration", menuName = "Configurations/EnemyConfiguration", order = 2)]
    public class EnemyConfiguration : ScriptableObject
    {
        public float movementSpeed;
        public float meleeAttackDelay;
        public float resetSwordAttackDelay;
        public int maxSwordAttack;
        public float swordDamage;
    }
}
