using System.Collections;
using System.Collections.Generic;
using Input;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utilities;
using Utilities.Extensions;

namespace Managers
{
    public class CutSceneManager : SingletonMonoBehaviour<CutSceneManager>
    {
        [SerializeField] private GameObject CutSceneGO;
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text subtitleText;
        [SerializeField, Range(0.001f, 0.1f)] private float imageAnimationSpeed, textAnimationSpeed;

        private Queue<CutSceneSlide> _slides;
        private CutSceneSlide _currentSlide;
        private Queue<string> _sentences;
        private string _currentSentence;
        private Coroutine _animateTextCoroutine, _animateImageCoroutine;

        #region Input events

        private void OnStepInput()
        {
            if (_animateTextCoroutine != null || _animateImageCoroutine != null) SkipAnimation();
            else if (_slides.Count == 0) DisableCutSceneUI();
            else if (_sentences.Count == 0) AnimateNextCutScene();
            else AnimateNextSentence();
        }

        private void OnCloseInput()
        {
            
        }

        #endregion

        private void AnimateNextSentence()
        {
            subtitleText.text = "";
            if (_sentences.Count == 0) return;
            _currentSentence = _sentences.Dequeue();
            _animateTextCoroutine = StartCoroutine(AnimateText());
        }
        
        private void SkipAnimation()
        {
            if (_animateTextCoroutine != null)
            {
                StopCoroutine(_animateTextCoroutine);
                _animateTextCoroutine = null;
                subtitleText.text = _currentSentence;
            }

            if (_animateImageCoroutine != null)
            {
                StopCoroutine(_animateImageCoroutine);
                _animateImageCoroutine = null;
                image.SetAlpha(1f);
            }
        }
        
        private void AnimateNextCutScene()
        {
            _currentSlide = _slides.Dequeue();
            _sentences = new Queue<string>(_currentSlide.sentences);
            _animateImageCoroutine = StartCoroutine(FadeInImage(_currentSlide.sprite));
            AnimateNextSentence();
        }
        
        private IEnumerator AnimateText()
        {
            foreach (var c in _currentSentence)
            {
                subtitleText.text += c;
                yield return new WaitForSeconds(textAnimationSpeed);
            }

            _animateTextCoroutine = null;
        }

        private IEnumerator FadeInImage(Sprite sprite)
        {
            image.SetAlpha(0f);
            image.sprite = sprite;
            for (var i = 0; i <= 100; i++)
            {
                image.SetAlpha(i * 0.01f);
                yield return new WaitForSeconds(imageAnimationSpeed);
            }

            _animateImageCoroutine = null;
        }

        private void EnableCutSceneUI()
        {
            CutSceneGO.SetActive(true);
            InputReader.Instance.EnableDialogInput();
            InputReader.Instance.stepDialogEvent += OnStepInput;
            InputReader.Instance.closeDialogEvent += OnCloseInput;
        }

        private void DisableCutSceneUI()
        {
            InputReader.Instance.stepDialogEvent -= OnStepInput;
            InputReader.Instance.closeDialogEvent -= OnCloseInput;
            InputReader.Instance.EnableGameplayInput();
            CutSceneGO.SetActive(false);
        }
        
        public void StartCutScene(CutSceneSO cutSceneSO)
        {
            _slides = new Queue<CutSceneSlide>(cutSceneSO.slides);
            EnableCutSceneUI();
            AnimateNextCutScene();
        }
    }
}