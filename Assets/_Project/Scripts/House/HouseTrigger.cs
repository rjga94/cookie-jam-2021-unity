using System;
using System.Collections;
using UnityEngine;

namespace House
{
    public class HouseTrigger : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer sprite;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(FadeOut());
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(FadeIn());
            }
        }

        private float _alpha = 0f;
        
        private IEnumerator FadeIn()
        {
            while (_alpha < 1f)
            {
                yield return new WaitForSeconds(0.01f);
                _alpha += .1f;
                var color = sprite.color;
                sprite.color = new Color(color.r, color.g, color.b, _alpha);   
            }
        }
        
        private IEnumerator FadeOut()
        {
            while (_alpha > 0f)
            {
                yield return new WaitForSeconds(0.01f);
                _alpha -= .1f;
                var color = sprite.color;
                sprite.color = new Color(color.r, color.g, color.b, _alpha);   
            }
        }
    }
}