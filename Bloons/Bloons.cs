using Fabric;
using UnityEngine;

namespace Bloons
{
    public class Bloons : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var balloon = BalloonUnderMouse();

                if (balloon != null)
                {
                    if (balloon.attachedTo == null)
                    {
                        EventManager.Instance.PostEvent(ScriptableSingleton<SoundAssetManager>.Instance.mapTurn.name);
                        balloon.Kill();
                    }
                }
            }
        }

        private Balloon BalloonUnderMouse()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            return Physics.Raycast(ray, out hit, Mathf.Infinity)
                ? hit.transform.gameObject.GetComponentInParent<Balloon>()
                : null;
        }
    }
}