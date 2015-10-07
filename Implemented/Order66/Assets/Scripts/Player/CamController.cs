using UnityEngine;
using System.Collections;

public class CamController : MonoBehaviour {
	public	Transform	camTarget;
	private float		x = 0.0f;
	private  float		y = 0.0f;
	public  int			mouseXSpeed;
	public int			mouseYSpeed;

	public float		maxViewDistance;
	public float		minViewDistance;
	public int			zoomRate;
	public int			lerpRate = 10;
	private float		distance = 3;
	private float		desiredDistance;
	private float		correctedDistance;
	public float		camTargetHeight;
	private float		currentDistance;

	void Start() {
		transform.rotation = Quaternion.Euler(0, 0, 0);
		Vector3 angels = transform.eulerAngles;
		x = angels.x;
		y = angels.y;

		currentDistance = distance;
		desiredDistance = distance;
		correctedDistance = distance;
	}
	
	void LateUpdate () {
		if (Input.GetMouseButton(0)) {
			x += Input.GetAxis("Mouse X") * mouseXSpeed;
			y -= Input.GetAxis("Mouse Y") * mouseYSpeed;
		}
		else if(Input.GetAxis("Vertical") != 0) {
			float targetRotationAngle = camTarget.eulerAngles.y;
			float cameraRotationAngle = transform.eulerAngles.y;
			x = Mathf.LerpAngle(cameraRotationAngle, targetRotationAngle, lerpRate * Time.deltaTime);
		}
		y = ClampAngle(y, -10, 40);

		Quaternion rotation = Quaternion.Euler(y, x, 0);

		desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs(desiredDistance);
		desiredDistance =ClampAngle(desiredDistance, minViewDistance, maxViewDistance);
		correctedDistance = desiredDistance;

		Vector3 position = camTarget.position - (rotation * Vector3.forward * desiredDistance);

		RaycastHit collisionHit;
		bool isCorrected = false;
		Vector3 cameraTargetPosition = new Vector3(camTarget.position.x, camTarget.position.y + camTargetHeight, camTarget.position.z);
		if(Physics.Linecast(cameraTargetPosition,position, out collisionHit)) {
			position = collisionHit.point;
			correctedDistance = Vector3.Distance(cameraTargetPosition, position);
			isCorrected = true;
		}

		currentDistance = !isCorrected || correctedDistance > currentDistance ? Mathf.Lerp(currentDistance, correctedDistance, Time.deltaTime * zoomRate) : correctedDistance;
		position = camTarget.position - (rotation * Vector3.forward * currentDistance + new Vector3(0, camTargetHeight, 0));

		transform.rotation = rotation;
		transform.position = position;
	}

	private static float ClampAngle(float angle, float min, float max) {
		return Mathf.Clamp(angle, min, max);
	}
}
