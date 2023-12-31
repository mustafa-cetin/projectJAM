using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// [CreateAssetMenu(menuName = "Citizens/Citizen")]
public class Citizen : MonoBehaviour
{
    public string citizenName;

    public string state;

    public int endurance;

    public int strength;

    public int intel;

    public int cooking;

    public Vector3[] targetPosition; // Gitmek istediğiniz pozisyon
    public float arrivalThreshold = 0.1f; // Hedefe varma eşiği
    public float moveSpeed = 5f; // Hareket hızı


    private bool hasArrived = false; // Hedefe ulaşıldı mı?

    public Room currentRoom;
    public GameObject selectIcon;

    int i=0;
    private Collider2D col;
    private void Start() {
        col=GetComponent<Collider2D>();
        targetPosition=new Vector3[1];
        targetPosition[0]=transform.position;
        selectIcon.SetActive(false);
    }

    void Update()
    {
        Move();
    }
    public void SetTargetPosition(Vector3[] position){

        i=0;
        targetPosition=position;
        hasArrived=false;

    }
    public void ChangeSelectedValue(bool state){
        selectIcon.SetActive(state);
    }
    void Move(){

         if (!hasArrived)
        {
            col.isTrigger=true;
            if (i!=1)
            {

            // Karakterin hedef pozisyona doğru hareket etmesini sağlar.
            transform.position = Vector3.MoveTowards(transform.position, targetPosition[i], moveSpeed * Time.deltaTime);


            }else{
                transform.position=targetPosition[i];
                Shelter.Instance.ChangeElectric(-10);
            }

            if (transform.position.x-targetPosition[i].x>=0)
            {
                transform.localEulerAngles=new Vector3(0,0,0);
            }else{

                transform.localEulerAngles=new Vector3(0,180,0);
            }
            // Hedefe ulaşma durumunu kontrol et
            if (Vector3.Distance(transform.position, targetPosition[i]) < arrivalThreshold)
            {
                // Hedefe ulaşıldığında yapılacak işlemler buraya yazılır

                hasArrived = true; // Hedefe ulaşıldı

                col.isTrigger=false;
            }
        }
        else{
            if (i<targetPosition.Length-1)
            {
                hasArrived=false;
                i++;
            }
        }

    }





}
