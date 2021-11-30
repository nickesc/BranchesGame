using UnityEngine;

namespace HighlightPlus.Demos {

    public class HitFxDemo : MonoBehaviour {

        public AudioClip hitSound;

        void Update() {

            if (!Input.GetMouseButtonDown(0)) return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo)) {
                HighlightEffect effect = hitInfo.collider.GetComponent<HighlightEffect>();
                if (effect == null) return;
                AudioSource.PlayClipAtPoint(hitSound, hitInfo.point);
                effect.HitFX(hitInfo.point);
            }

        }
    }

}