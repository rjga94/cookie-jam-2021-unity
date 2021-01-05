using UnityEngine;
using UnityEngine.UI;

namespace Utilities.Extensions
{
    public static class ImageExtensions
    {
        public static void SetAlpha(this Image image, float alphaNormalized)
        {
            var color = image.color;
            image.color = new Color(color.r, color.g, color.b, alphaNormalized);
        }
    }
}