using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;
using Utilities;

namespace Poucet
{
    public class PoucetFightHandler : SingletonMonoBehaviour<PoucetFightHandler>
    {
        [SerializeField, LabelText("Walls")] private GameObject[] wallGOs;
        [SerializeField] private PolygonCollider2D originalConfiner, fightConfiner;
        [SerializeField] private CinemachineConfiner confinerComponent;

        private bool _didFight;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            if (_didFight) return;
            StartFight();
        }

        private void StartFight()
        {
            foreach (var go in wallGOs) go.SetActive(true);
            confinerComponent.m_BoundingShape2D = fightConfiner;
        }

        public void EndFight()
        {
            _didFight = true;
            confinerComponent.m_BoundingShape2D = originalConfiner;
            foreach (var go in wallGOs) go.SetActive(false);
        }
    }
}