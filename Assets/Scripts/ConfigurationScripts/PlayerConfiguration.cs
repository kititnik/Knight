using UnityEngine;
using UnityEngine.Serialization;

namespace ConfigurationScripts
{
    [CreateAssetMenu(fileName = "PlayerConfiguration", menuName = "Configurations/PlayerConfiguration", order = 1)]
    public class PlayerConfiguration : ScriptableObject
    {
        public float playerMovementSpeed;
        public float swordAttackDelay;
        public float resetSwordAttackDelay;
        public int maxSwordAttack;
        public float swordDamage;
    }
}
