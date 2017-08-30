using UnityEngine;

namespace NGT2.TreasureBox
{ 
    public class TreasureBox : MonoBehaviour
    {
        public GameObject chestTop;
        public GameObject sackTreasure;
        public Animator treasureboxAnimator;

        // bflags to determine state of animations
        bool isOpen = false;
        bool isRemove = false;
	
	    void Start ()
        {
            // if any of the public variable is null, reference it
            if (!chestTop)              chestTop = transform.Find("Chest_Top").gameObject;
            if (!sackTreasure)          sackTreasure = transform.Find("Sack_Treasure").gameObject;
            if (!treasureboxAnimator)   treasureboxAnimator = GetComponent<Animator>();

            // check if objects contains colliders, if not. add one
            if (!chestTop.GetComponent<Collider>())         chestTop.AddComponent<MeshCollider>();
            if (!sackTreasure.GetComponent<Collider>())     sackTreasure.AddComponent<MeshCollider>();        
	    }

        // if chest top is clicked do the following
        void ChestTopClick()
        {
            isOpen = !isOpen;

            if(isOpen)
                treasureboxAnimator.SetTrigger("Open Chest");
            else
                treasureboxAnimator.SetTrigger("Close Chest");
        }

        // if treasure is clicked do the following
        void SackTreasureClick()
        {
            if (!isOpen) return;    // do not proceed if chest is false (closed)

            isRemove = !isRemove;

            if(isRemove)
                treasureboxAnimator.SetTrigger("Remove Treasure");
            else
                treasureboxAnimator.SetTrigger("Put Treasure");
        }

        void Update()
        {
            // check what part is clicked
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                    if (hit.collider != null)
                    {
                        if (hit.collider.gameObject == chestTop)
                            ChestTopClick();
                        if (hit.collider.gameObject == sackTreasure)
                            SackTreasureClick();
                    }
            }
        }
    }
}
