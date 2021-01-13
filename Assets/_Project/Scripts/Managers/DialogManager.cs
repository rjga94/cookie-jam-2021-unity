using System.Collections;
using System.Collections.Generic;
using Character;
using Input;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace Managers
{
    public class DialogManager : SingletonMonoBehaviour<DialogManager>
    {
        [SerializeField] private GameObject dialogBoxGO;
        [SerializeField] private GameObject interactMessageGO;
        [SerializeField] private Image characterImage;
        [SerializeField] private TMP_Text textBox;
        [SerializeField, Range(0.01f, 1f)] private float textAnimationSpeed;

        private GameObject _npcGO;
        private bool _disableNPCWhenDialogEnds;
        private Queue<Paragraph> _paragraphs;
        private Paragraph _currentParagraph;
        private Coroutine _animateTextCoroutine;
        private Transform _teleportLocation;

        #region Input events

        private void OnStepInput()
        {
            if (_animateTextCoroutine != null) SkipAnimation();
            else if (_paragraphs.Count == 0) DisableDialogBox();
            else AnimateNextParagraph();
        }

        private void OnCloseInput() => DisableDialogBox();

        #endregion

        private IEnumerator AnimateText()
        {
            foreach (var c in _currentParagraph.text)
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

            characterImage.sprite = _currentParagraph.frame;
            
            AudioManager.Instance.SecondaryAudioSource.Stop();
            if (_currentParagraph.voice != null)
                _currentParagraph.voice.Play(AudioManager.Instance.SecondaryAudioSource);
        }

        private void SkipAnimation()
        {
            if (_animateTextCoroutine == null) return;
            
            StopCoroutine(_animateTextCoroutine);
            _animateTextCoroutine = null;
            textBox.text = _currentParagraph.text;
        }

        private void EnableDialogBox()
        {
            dialogBoxGO.SetActive(true);
            InputReader.Instance.EnableDialogInput();
            InputReader.Instance.stepDialogEvent += OnStepInput;
            InputReader.Instance.closeDialogEvent += OnCloseInput;
        }

        private void DisableDialogBox()
        {
            if (_teleportLocation != null) FindObjectOfType<PlayerController>().transform.position = _teleportLocation.position;
            if (_disableNPCWhenDialogEnds) _npcGO.SetActive(false);

            InputReader.Instance.stepDialogEvent -= OnStepInput;
            InputReader.Instance.closeDialogEvent -= OnCloseInput;
            InputReader.Instance.EnableGameplayInput();
            dialogBoxGO.SetActive(false);
        }
        
        public void StartDialog(DialogSO dialogSO, GameObject npcGO)
        {
            _npcGO = npcGO;
            _disableNPCWhenDialogEnds = dialogSO.disableNPCWhenDialogEnds;
            _teleportLocation = dialogSO.teleportLocation;
            _paragraphs = new Queue<Paragraph>(dialogSO.paragraphs);
            EnableDialogBox();
            AnimateNextParagraph();
        }

        public void ShowInteractMessage() => interactMessageGO.SetActive(true);

        public void DismissInteractMessage() => interactMessageGO.SetActive(false);
    }
}