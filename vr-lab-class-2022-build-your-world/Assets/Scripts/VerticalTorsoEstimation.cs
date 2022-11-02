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
            //Debug.Log("headTransform = " + headTransform.rotation);
            //Debug.Log("headTransform X = " + headTransform.rotation.x);
            //Debug.Log("headTransform Z= " + headTransform.rotation.z);
            //Debug.Log("test= " + Quaternion.Euler(headTransform.rotation.x, 0, headTransform.rotation.z));

            //https://answers.unity.com/questions/1595364/how-can-i-move-a-gameobject-along-its-global-axis.html
            //transform.Rotate(Vector3.up* Time.deltaTime, Space.World);
            //transform.Translate(Vector3.up* Time.deltaTime, Space.World);
            //transform.position = new Vector3(headTransform.position.x, 0, headTransform.position.z);
            //transform.TransformDirection(new Vector3(headTransform.position.x, 0, headTransform.position.z));

            // Body already stays in Y Axis, but still do a rotation
            //transform.rotation = Quaternion.Euler(headTransform.localRotation.x * transform.localRotation.x, 0F, headTransform.localRotation.z * transform.localRotation.z);
            transform.rotation =  Quaternion.Euler(headTransform.localRotation.x * transform.localRotation.x, 0F, headTransform.localRotation.z * transform.localRotation.z);
            //transform.position = new Vector3(headTransform.position.x, headTransform.localPosition.y * transform.localPosition.y, headTransform.position.z);

            //transform.Rotate(new Vector3(headTransform.rotation.x, 0, headTransform.rotation.z)* Time.deltaTime, Space.World);
        }
    }
}
