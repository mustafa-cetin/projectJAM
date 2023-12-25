using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CitizenGenerator : MonoBehaviour
{

    public RoomManager roomManager;

    public Citizen citizenObject;

    public Citizen SelectedCitizen{get;private set;}

    public GameObject panel;
    public TMP_Text textObject;

    private string[] names = { "John", "Jane", "Bob", "Lisa", "Mike", "Anna", "Alex", "Ella", "Paul", "Mara" };

    public void defineCitizen(){
        BaseDefineCitizen(new Vector3(-12,-1.25f,0));

    }
    public void defineCitizenP(Vector3 position){

        BaseDefineCitizen(position);
    }
    public void BaseDefineCitizen(Vector3 position){
        Citizen citizen = Instantiate(citizenObject);
        citizen.transform.position=position;
        citizen.state = "Idle";
        citizen.citizenName = GenerateRandomName();
        citizen.strength = Random.Range(1,11);
        citizen.intel = Random.Range(1,11);
        citizen.cooking = Random.Range(1,11);
        citizen.endurance = Random.Range(1,11);

        Shelter.Instance.citizens.Add(citizen);
    }
    public void ShowStatPanel(){
                     panel.gameObject.SetActive(true);

                    string name = SelectedCitizen.citizenName;
                    int endu = SelectedCitizen.endurance;
                    int cook = SelectedCitizen.cooking;
                    int intel = SelectedCitizen.intel;
                    int strength = SelectedCitizen.strength;
                    string currentWork ="None";
                    if (SelectedCitizen.currentRoom!=null)
                    {
                        currentWork=SelectedCitizen.currentRoom.ToString();
                    }
                    textObject.text = "Name: " + name + "\nEndurance: " + endu + "\nCooking: " + cook + "\nIntelligence: " + intel + "\nStrength: " + strength+"\nCurrent Work: "+currentWork;

    }
    public void HideStatPanel(){
                panel.gameObject.SetActive(false);
    }

    void Start(){
        for(int i=0;i<4;i++){
            defineCitizen();
        }
    }
    private void  Update() {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject()) // Eğer UI üzerinde tıklama yoksa devam et
            {

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if(hit.collider != null)
        {
            if (hit.transform.CompareTag("Citizen"))
            {
                Debug.Log("worked");
                Citizen clickedCitizen=hit.transform.GetComponent<Citizen>();

                /*

                    */


            if (clickedCitizen==SelectedCitizen)
            {

                Shelter.Instance.CitizenMode.init(panel,this);
                Shelter.Instance.currentMode.exitMode();

            }
            else
            {

                Shelter.Instance.CitizenMode.init(panel,this);
                Shelter.Instance.currentMode.exitMode();
                if (SelectedCitizen!=null)
                {
                    SelectedCitizen.ChangeSelectedValue(false);
                }
                SelectedCitizen=clickedCitizen;
                Shelter.Instance.currentMode=Shelter.Instance.CitizenMode;
                Shelter.Instance.currentMode.enterMode();
            }
            }

        }
        else if(Shelter.Instance.currentMode.Equals(Shelter.Instance.CitizenMode))
        {


            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Room clickedRoom = roomManager.GetRoom(worldPosition);
            if (clickedRoom!=null)
            {

                if (SelectedCitizen.currentRoom!=null)
                {
                    if (SelectedCitizen.currentRoom.CompareTag("ResourceRoom"))
                    {
                        SelectedCitizen.currentRoom.GetComponent<ResourceRoom>().SetWorker(null);
                    }
                }



                if (clickedRoom.CompareTag("ResourceRoom"))
                {
                    if (clickedRoom.GetComponent<ResourceRoom>().Worker!=null)
                    {
                        return;
                    }else{

                        clickedRoom.GetComponent<ResourceRoom>().SetWorker(SelectedCitizen);
                    }
                }

                Vector3 targetRoomCoordinates=roomManager.GetRoomCoordinates(worldPosition);
                Vector3[] targetRoomPositions;

                if (roomManager.GetElevation(targetRoomCoordinates)==roomManager.GetElevation(SelectedCitizen.transform.position))
                {

                    //DIRECTLY GO ROOM
                targetRoomPositions=new Vector3[]{new Vector3(targetRoomCoordinates.x,SelectedCitizen.transform.position.y,SelectedCitizen.transform.position.z)};

                }else{
                    if (Shelter.Instance.Electric<=10) return;
                    // selected citizen go to own elevation ladder room
                    targetRoomPositions=new Vector3[3];
                    targetRoomPositions[0]=new Vector3(
                        roomManager.GetLadderRoomCoordinatesByY(roomManager.GetElevation(SelectedCitizen.transform.position)).x,
                        SelectedCitizen.transform.position.y,
                        SelectedCitizen.transform.position.z);
                    // teleport
                    targetRoomPositions[1]=new Vector3(roomManager.GetLadderRoomCoordinatesByY(roomManager.GetElevation(targetRoomCoordinates)).x,
                    roomManager.GetLadderRoomCoordinatesByY(roomManager.GetElevation(targetRoomCoordinates)).y-1.5f,
                    SelectedCitizen.transform.position.z);
                    // directly go room

                    targetRoomPositions[2]=new Vector3(targetRoomCoordinates.x,
                    targetRoomCoordinates.y-1.5f,
                    SelectedCitizen.transform.position.z);

                }
                    SelectedCitizen.SetTargetPosition(targetRoomPositions);
                     SelectedCitizen.currentRoom=clickedRoom;

                         ShowStatPanel();
            }
        }
            }

        }
    }


    private string GenerateRandomName()
    {
        int randomIndex = Random.Range(0, names.Length);
        string randomName = names[randomIndex];

        if (randomName.Length >= 4)
        {
            int startIndex = Random.Range(0, randomName.Length - 4);
            return randomName.Substring(startIndex, 4);
        }

        return randomName;
    }

    public void SetSelectedCitizenNull(){
        SelectedCitizen=null;
    }
}
