using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScreenUIPassThrough : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler {

	[SerializeField]
	GraphicRaycaster raycaster;

	[SerializeField]

	Camera mainCamera;


	[SerializeField]
	LayerMask layerMask;

	private List<RaycastResult> results = new List<RaycastResult>();
	public void OnPointerClick(PointerEventData eventData)
    {
		RaycastHit hit;
		if( Physics.Raycast( mainCamera.ViewportPointToRay(eventData.position), out hit, 1000f, layerMask ) ){
			eventData.position = hit.textureCoord;
			results.Clear();
			raycaster.Raycast(eventData, results );

		}
		
    }

    public void OnPointerDown(PointerEventData eventData)
    {
		results.Clear();
        raycaster.Raycast(eventData, results );
    }

    public void OnPointerUp(PointerEventData eventData)
    {
		results.Clear();
        raycaster.Raycast(eventData, results );
    }
}
