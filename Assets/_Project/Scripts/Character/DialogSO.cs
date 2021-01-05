using Sirenix.OdinInspector;
using UnityEngine;
using Utilities;

namespace Character
{
    [CreateAssetMenu(fileName = "Dialog", menuName = ScriptableObjectConstants.dialogDataPath + "Dialog", order = 0)]
    public class DialogSO : ScriptableObject
    {
        [MultiLineProperty(8)]
        public string[] paragraphs;
    }
}