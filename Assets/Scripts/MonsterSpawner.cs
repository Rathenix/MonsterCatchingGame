using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour {

    public GoogleMap mainMap;
    public UiController UiController;
    private float lastSpawnAttempt;
    public int activeSpawns;
    public int maxSpawns;
    public int spawnSeconds;
    public int spawnChancePercent;
    public GameObject[] mapMonsters;

	void Start () {
        lastSpawnAttempt = Time.time;
        activeSpawns = 0;	
	}
	
	void Update () {
        if (Time.time > lastSpawnAttempt + spawnSeconds && activeSpawns < maxSpawns)
        {
            var rand = Random.Range(1, 101);
            if (rand <= spawnChancePercent)
            {
                var randMon = Random.Range(0, mapMonsters.Length);

                var monMarker = new GoogleMapMarker();
                var monMarkerLoc = new GoogleMapLocation();

                var latadj = Random.Range(-mainMap.LAT_DIST_CENTER_TO_EDGE, mainMap.LAT_DIST_CENTER_TO_EDGE);
                var lonadj = Random.Range(-mainMap.LON_DEST_CENTER_TO_EDGE, mainMap.LON_DEST_CENTER_TO_EDGE);
                monMarkerLoc.latitude = mainMap.centerLocation.latitude + latadj;
                monMarkerLoc.longitude = mainMap.centerLocation.longitude + lonadj;

                monMarkerLoc.address = "";
                var monMarkerLocArray = new GoogleMapLocation[1];
                monMarkerLocArray[0] = monMarkerLoc;
                monMarker.locations = monMarkerLocArray;
                monMarker.size = GoogleMapMarker.GoogleMapMarkerSize.Tiny;
                monMarker.label = "";
                if (randMon == 0) //obviously, dont leave this like this
                {
                    monMarker.color = GoogleMapColor.green;
                }
                if (randMon == 1)
                {
                    monMarker.color = GoogleMapColor.red;
                }
                if (randMon == 2)
                {
                    monMarker.color = GoogleMapColor.blue;
                }
                var mainMapMarkers = mainMap.markers;
                var monMarkerArray = new GoogleMapMarker[mainMapMarkers.Length + 1];
                for (var i = 0; i < mainMapMarkers.Length; i++)
                {
                    monMarkerArray[i] = mainMapMarkers[i];
                }
                monMarkerArray[mainMapMarkers.Length] = monMarker;
                mainMap.markers = monMarkerArray;

                var _monster = Instantiate(mapMonsters[randMon], new Vector3((lonadj * 10000f) * mainMap.X_PER_0P0001_LON, (latadj * 10000f) * mainMap.Y_PER_0P0001_LAT, 0), new Quaternion());
                _monster.GetComponent<MapMonster>().mainMap = mainMap;
                _monster.GetComponent<MapMonster>().lastLatCenter = mainMap.centerLocation.latitude;
                _monster.GetComponent<MapMonster>().lastLonCenter = mainMap.centerLocation.longitude;
                _monster.GetComponent<MapMonster>().spawner = this;
                _monster.GetComponent<MapMonster>().uiController = UiController;
                activeSpawns += 1;

                mainMap.Refresh();
            }
            lastSpawnAttempt = Time.time;
        }
	}
}
