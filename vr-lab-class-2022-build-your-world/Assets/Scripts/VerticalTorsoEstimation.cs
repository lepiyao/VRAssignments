using UnityEngine;

namespace Vrsys
{
    public class VerticalTorsoEstimation : MonoBehaviour
    {
        [Tooltip("The head transform which is used to align the body to. If nothing is specified, transform of parent GameObject will be used.")]
        public Transform headTransform;

        private void Awake()
        {
            if (headTransform == null)
            {
                Debug.Log("headTransform = null");
                headTransform = transform.parent;
            }
        }

        void Update()
        {

            // TODO Exercise 1.6
            // Body already stays in Y Axis, but still do a rotation
            //transform.Rotate(new Vector3(headTransform.position.x, transform.position.y, headTransform.position.z));
            transform.rotation = Quaternion.Euler(0F, headTransform.rotation.y * transform.rotation.y, 0F);
            //transform.localPosition = transform.localPosition + new Vector3 (headTransform.localPosition.x, headTransform.localPosition.y * transform.localPosition.y, headTransform.localPosition.z);
        }
    }
}
