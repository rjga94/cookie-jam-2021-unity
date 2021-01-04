using UnityEngine;
using Utilities;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerStateData", menuName = ScriptableObjectConstants.stateDataPath + "Player State Data")]
    public class PlayerStateDataSO : ScriptableObject
    {
        public float movementSpeed;
        public float jumpForce;
    }
}