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
            transform.rotation = Quaternion.Euler(0F, headTransform.localRotation.y * transform.localRotation.y, 0F);
            transform.Rotate(new Vector3(headTransform.position.x, transform.position.y, headTransform.position.z));
            //transform.localPosition = transform.localPosition + new Vector3 (headTransform.localPosition.x, headTransform.localPosition.y * transform.localPosition.y, headTransform.localPosition.z);
        }
    }
}

//using System;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//namespace Vrsys
//{
//	public class VerticalTorsoEstimation : MonoBehaviour
//	{
//		[Tooltip("The head transform which is used to align the body to. If nothing is specified, transform of parent GameObject will be used.")]
//		public Transform headTransform;
//		public Transform body;
//		private float xAngle;
//		public bool isMoved = false;
//		public float fraction;
//		private Vector3 startPosition;
//		private Vector3 currentPosition;
//		private Vector3 endPosition;


//		public Vector3 newPosition;

//		private void Awake()
//		{
//			if (headTransform == null)
//			{
//				headTransform = transform.parent;
//			}
//		}

//		void Update()
//		{

//			// TODO Exercise 1.6- Need to set postion of the avtar together.Torso is moving as per head movement but getting moved in x direction 
//			fraction = (Mathf.Sin(Time.time * 1) + 1.0f) / 2.0f;
//			xAngle = headTransform.transform.localEulerAngles.x;
//			currentPosition = getCurrentPosition();
//			Debug.Log("CurrentPosition : " + currentPosition);
//			Debug.Log("startPosition : " + startPosition);

//			endPosition = getEndPosition();
//			Debug.Log("EndPosition : " + endPosition);

//			var distance = getDistance(startPosition, endPosition);
//			Debug.Log("Distance : " + distance);

//			if (xAngle >= 45 && isMoved == false){

//				body.transform.position = Vector3.Lerp(startPosition, endPosition, fraction);
//				isMoved = true;
//				StartCoroutine(MoveForward());

//			}
//		}
//		public IEnumerator MoveForward(){

//			var newDistance = getDistance(getCurrentPosition(), endPosition);
//			Debug.Log("New Distance:" + newDistance);
//			body.transform.position = Vector3.Lerp(startPosition, this.transform.position, fraction);
//			isMoved = false;
//			Debug.Log("Body Position :" + getCurrentPosition());
//			yield return null;
//		}
//		public float getDistance(Vector3 startPosition, Vector3 endPosition){
//			return Vector3.Distance(startPosition, endPosition);
//		}
//		public Vector3 getCurrentPosition(){
//			currentPosition = this.transform.position;
//			startPosition = currentPosition;
//			return currentPosition;
//		}
//		public Vector3 getEndPosition(){
//			return getCurrentPosition() + Vector3.back * .30f;
//		}
//	}
//}
