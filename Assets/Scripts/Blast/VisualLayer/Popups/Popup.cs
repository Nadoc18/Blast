using UnityEngine;

namespace Blast.VisualLayer.Popups
{
    public class Popup : MonoBehaviour
    {
        protected virtual void Close()
        {
            Destroy(gameObject);
        }
    }
}