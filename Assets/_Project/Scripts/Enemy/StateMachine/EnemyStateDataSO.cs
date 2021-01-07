using UnityEngine;
using Utilities;

namespace Enemy.StateMachine
{
    [CreateAssetMenu(fileName = "EnemyStateData", menuName = ScriptableObjectConstants.stateDataPath + "Enemy State Data")]
    public class EnemyStateDataSO : ScriptableObject
    {
        public float moveSpeed;
        public float attackPower;
    }
}