using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour {

    public GoogleStaticMap mainMap;
    public UiController UiController;
    private float lastSpawnAttempt;
    public int activeSpawns;
    public int maxSpawns;
    public int spawnSeconds;
    public int spawnChancePercent;
    GameObject rustlingGrass;

	void Start () {
        lastSpawnAttempt = Time.time;
        activeSpawns = 0;
        rustlingGrass = Resources.Load("Map/RustlingGrass", typeof(GameObject)) as GameObject;
    }
	
	void Update () {
        AttemptToSpawnMonsterInGrass();
    }

    void AttemptToSpawnMonsterInGrass()
    {
        if (mainMap.isDrawn)
        {
            if (Time.time > lastSpawnAttempt + spawnSeconds && activeSpawns < maxSpawns)
            {
                var rand = Random.Range(1, 101);
                if (rand <= spawnChancePercent)
                {
                    var randMon = Random.Range(0, 3); //obviously, dont leave this like this
                    var northeastCorner = mainMap.mapRectangle.getCornerLatLon(GoogleStaticMap.MapRectangle.GetCorner.NE);
                    var southwestCorner = mainMap.mapRectangle.getCornerLatLon(GoogleStaticMap.MapRectangle.GetCorner.SW);
                    var grassLat = Random.Range(southwestCorner.lat_d, northeastCorner.lat_d);
                    var grassLon = Random.Range(southwestCorner.lon_d, northeastCorner.lon_d);
                    var grassGeoPoint = new GeoPoint(grassLat, grassLon);
                    var rustlingGrassObj = Instantiate(rustlingGrass);
                    var grassLoc = rustlingGrassObj.GetComponent<ObjectPosition>();
                    grassLoc.setPositionOnMap(grassGeoPoint);
                    var mapMonster = rustlingGrassObj.GetComponent<MapMonster>();
                    mapMonster.LoadMonsterById(randMon);
                    mapMonster.Level = Random.Range(2, 6);
                    mapMonster.CurrentHp = mapMonster.MaxHp;
                    mapMonster.spawner = this;
                    mapMonster.uiController = UiController;
                    activeSpawns += 1;
                }
                lastSpawnAttempt = Time.time;
            }
        }
    }
}
