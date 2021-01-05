using System;
using UnityEngine;

namespace Managers
{
    public class ApplicationManager : MonoBehaviour
    {
        private float _timeScale;

        private void Awake() => _timeScale = Time.timeScale;

        public void ResumeGame() => Time.timeScale = _timeScale;

        public void PauseGame() => Time.timeScale = 0f;
    }
}