using System.Collections;
using System.Collections.Generic;
using Character;
using Input;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class DialogManager : MonoBehaviour
    {
        [SerializeField] private GameObject dialogBoxGO;
        [SerializeField] private Image characterImage;
        [SerializeField] private TMP_Text textBox;
        [SerializeField, Range(0.01f, 1f)] private float textAnimationSpeed;

        private Queue<string> _paragraphs;
        private string _currentParagraph;
        private Coroutine _animateTextCoroutine;

        #region Lifecycle

        private void OnEnable()
        {
            InputReader.Instance.stepDialogEvent += OnStepDialogInput;
            InputReader.Instance.closeDialogEvent += OnCloseDialogInput;
        }

        private void OnDisable()
        {
            InputReader.Instance.stepDialogEvent -= OnStepDialogInput;
            InputReader.Instance.closeDialogEvent -= OnCloseDialogInput;
        }

        #endregion

        #region Input events

        private void OnStepDialogInput()
        {
            if (_animateTextCoroutine != null) SkipAnimation();
            else if (_paragraphs.Count == 0) DisableDialogBox();
            else AnimateNextParagraph();
        }

        private void OnCloseDialogInput() => DisableDialogBox();

        #endregion

        private IEnumerator AnimateText()
        {
            foreach (var c in _currentParagraph)
            {
                textBox.text += c;
                yield return new WaitForSeconds(textAnimationSpeed);
            }

            _animateTextCoroutine = null;
        }
        
        private void AnimateNextParagraph()
        {
            textBox.text = "";
            _currentParagraph = _paragraphs.Dequeue();
            _animateTextCoroutine = StartCoroutine(AnimateText());
        }

        private void SkipAnimation()
        {
            if (_animateTextCoroutine == null) return;
            
            StopCoroutine(_animateTextCoroutine);
            _animateTextCoroutine = null;
            textBox.text = _currentParagraph;
        }

        private void EnableDialogBox()
        {
            dialogBoxGO.SetActive(true);
            InputReader.Instance.EnableDialogInput();
        }

        private void DisableDialogBox()
        {
            InputReader.Instance.EnableGameplayInput();
            dialogBoxGO.SetActive(false);
        }
        
        public void StartDialog(DialogSO dialogSO)
        {
            _paragraphs = new Queue<string>(dialogSO.paragraphs);
            EnableDialogBox();
            AnimateNextParagraph();
        }
    }
}