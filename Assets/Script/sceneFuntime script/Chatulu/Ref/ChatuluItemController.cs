using UnityEngine;
namespace ChatuluSystem2
{
    public class ChatuluItemController : MonoBehaviour
    {
        [SerializeField] private bool chatuluShelf = false;
        [SerializeField] private bool chatuluOutside = false;

        [SerializeField] private ChatuluInventory _chatuluInventory = null;

        private ChatuluShelfController chatuluObject;

        private void Start(){

        if(chatuluShelf){
        chatuluObject = GetComponent<ChatuluShelfController>();
        }
        }

        public void ObjectInterraction(){

        if(chatuluOutside){
            _chatuluInventory.hasChatulu = true;
            gameObject.SetActive(false);
        }
        }
    }


}

