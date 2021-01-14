using UnityEngine;
using Utilities;

namespace Character
{
    [CreateAssetMenu(fileName = "Dialog", menuName = ScriptableObjectConstants.dialogDataPath + "Dialog", order = 0)]
    public class DialogSO : ScriptableObject
    {
        public bool disableNPCWhenDialogEnds;
        public Paragraph[] paragraphs;
    }
}