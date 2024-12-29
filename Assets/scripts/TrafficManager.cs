using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour
{
    [SerializeField]Transform[]lane;
    [SerializeField]Transform[]trafficVechicle;
    
    [SerializeField] carMove carMove;
    [SerializeField] float minSpawnTime=30f;
    [SerializeField] float maxSpawnTime=60f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TrafficSpawner());
    }

    // Update is called once per frame
   IEnumerator TrafficSpawner(){
    yield return new WaitForSeconds(2f);
    while(true){
        float dynamicTimer = Random.Range(minSpawnTime,maxSpawnTime)/carMove.CarSpeed();
         if (carMove.CarSpeed()>20f){
            SpawnTrafficVechicle();
         }
        yield return new WaitForSeconds(2f);
    }
   }
   void SpawnTrafficVechicle(){
      int randomLaneIndex=Random.Range(0,lane.Length);
        int randomTrafficIndex=Random.Range(0,trafficVechicle.Length);
        Instantiate(trafficVechicle[randomLaneIndex],lane[randomTrafficIndex].position,Quaternion.identity);

   }

}



