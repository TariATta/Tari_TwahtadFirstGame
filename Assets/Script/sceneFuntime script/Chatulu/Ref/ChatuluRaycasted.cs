using UnityEngine;
using UnityEngine.UI;
namespace ChatuluSystem2{
    public class ChatuluRaycasted : MonoBehaviour
    {
        [SerializeField] private int rayLenght = 5;
        [SerializeField] private LayerMask layerMaskInterract;
        [SerializeField] private string excluseLayerName = null;

        private ChatuluItemController raycastedObject;

        [SerializeField] private KeyCode placeChatuluShelf = KeyCode.E;

        [SerializeField] private Image crosshair = null;

        private bool isCrosshairActive;
        private bool doOnce;

        private string interactableTag = "InteractiveObject";

        private void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(excluseLayerName) | layerMaskInterract.value;

            if(Physics.Raycast(transform.position,fwd, out hit, rayLenght, mask)){
                if(hit.collider.CompareTag(interactableTag)){
                    if(!doOnce){
                        raycastedObject = hit.collider.gameObject.GetComponent<ChatuluItemController>();
                        CrosshairChange(true);
                    }

                    isCrosshairActive = true;
                    doOnce = true;

                    if (Input.GetKeyDown(placeChatuluShelf)){
                        raycastedObject.ObjectInterraction();
                    }
                }
            }
            else
            {
                if (isCrosshairActive)
                {
                    CrosshairChange(false);
                    doOnce = false;
                }
            }
        }

        void CrosshairChange (bool on){
            if(on && !doOnce){
                crosshair.color = Color.red;
            }
            else{
                crosshair.color = Color.white;
                isCrosshairActive = false;
            }
        }
    }
}
