using UnityEngine;
using System.Collections;

public class ObjectPosition : MonoBehaviour {
	GoogleStaticMap mainMap;


	public float lat_d = 0.0f, lon_d = 0.0f;

	private GeoPoint pos;


	void Awake (){
		pos = new GeoPoint ();
		pos.setLatLon_deg (lat_d, lon_d);
	}

	public void setPositionOnMap () {
		Vector2 tempPosition = GoMapGameManager.Instance.getMainMapMap ().getPositionOnMap (this.pos);
        transform.position = new Vector3 (tempPosition.x, tempPosition.y, transform.position.z);
	}

	public void setPositionOnMap (GeoPoint pos) {
		this.pos = pos;
        lat_d = pos.lat_d;
        lon_d = pos.lon_d;
		setPositionOnMap ();
	}

}
