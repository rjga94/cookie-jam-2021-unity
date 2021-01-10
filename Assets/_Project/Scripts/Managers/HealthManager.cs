using Character;
using UnityEngine;
using UnityEngine.UI;
using Utilities;
using Utilities.Extensions;

namespace Managers
{
    public class HealthManager : SingletonMonoBehaviour<HealthManager>
    {
        [SerializeField] private HealthHandler _healthHandler;
        [SerializeField] private Image _image;

        private float _maxHealth;
        
        private void Awake()
        {
            _maxHealth = _healthHandler.Health;
        }

        private void Update()
        {
            var calculatedAlpha = _healthHandler.Health * 0.5f / _maxHealth;
            _image.SetAlpha(-calculatedAlpha + 0.5f);
        }
    }
}