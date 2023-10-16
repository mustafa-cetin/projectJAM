using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CitizenGenerator : MonoBehaviour
{

    public RoomManager roomManager;

    public Citizen citizenObject;

    public Citizen selectedCitizen;

    public GameObject panel;
    public TMP_Text textObject;
    

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

                    string name = selectedCitizen.citizenName;
                    int endu = selectedCitizen.endurance;
                    int cook = selectedCitizen.cooking;
                    int intel = selectedCitizen.intel;
                    int strength = selectedCitizen.strength;
                    
                    Debug.Log("name");
                    Debug.Log(name);
                    Debug.Log("name");
                    textObject.text = "Name : " + name + "\nEndurance : " + endu + "\nCooking : " + cook + "\nIntelligence : " + intel + "\nStrength : " + strength; 

    }
    public void HideStatPanel(){
        
                panel.gameObject.SetActive(false);
    }
    private void  Update() {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject()) // Eğer UI üzerinde tıklama yoksa devam et
            {
             


        if (Shelter.Instance.currentMode!=Mode.None && Shelter.Instance.currentMode!=Mode.Character) return;

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        
        if(hit.collider != null)
        {
            if (hit.transform.CompareTag("Citizen"))
            {
                Debug.Log("worked");
                Citizen clickedCitizen=hit.transform.GetComponent<Citizen>();

                /*
                
                    */

                
            if (clickedCitizen==selectedCitizen)
            {
                
                HideStatPanel();
                Shelter.Instance.currentMode=Mode.None;
                selectedCitizen.ChangeSelectedValue(false);
                selectedCitizen=null;
            }else
            {
                if (selectedCitizen!=null)
                {
                    

                    selectedCitizen.ChangeSelectedValue(false);
                }

                selectedCitizen=clickedCitizen;
                ShowStatPanel();
                selectedCitizen.ChangeSelectedValue(true);
                Shelter.Instance.currentMode=Mode.Character;
            }
            }
        }else if(Shelter.Instance.currentMode==Mode.Character)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            if (roomManager.GetRoom(worldPosition)!=null)
            {

                HideStatPanel();
            Room clickedRoom = roomManager.GetRoom(worldPosition);
                if (selectedCitizen.currentRoom!=null)
                {
                    if (selectedCitizen.currentRoom.CompareTag("ResourceRoom"))
                    {
                        selectedCitizen.currentRoom.GetComponent<ResourceRoom>().SetWorker(null);
                    }
                }



                if (clickedRoom.CompareTag("ResourceRoom"))
                {
                    if (clickedRoom.GetComponent<ResourceRoom>().Worker!=null)
                    {
                        return;
                    }else{
                        clickedRoom.GetComponent<ResourceRoom>().SetWorker(selectedCitizen);
                    }
                }

                Vector3 targetRoomCoordinates=roomManager.GetRoomCoordinates(worldPosition);
                Vector3[] targetRoomPositions;

                if (roomManager.GetElevation(targetRoomCoordinates)==roomManager.GetElevation(selectedCitizen.transform.position))
                {

                    //DIRECTLY GO ROOM
                targetRoomPositions=new Vector3[]{new Vector3(targetRoomCoordinates.x,selectedCitizen.transform.position.y,selectedCitizen.transform.position.z)};

                }else{
                    if (Shelter.Instance.Electric<=10) return;
                    // selected citizen go to own elevation ladder room
                    targetRoomPositions=new Vector3[3];
                    targetRoomPositions[0]=new Vector3(
                        roomManager.GetLadderRoomCoordinatesByY(roomManager.GetElevation(selectedCitizen.transform.position)).x,
                        selectedCitizen.transform.position.y,
                        selectedCitizen.transform.position.z);
                    // teleport
                    targetRoomPositions[1]=new Vector3(roomManager.GetLadderRoomCoordinatesByY(roomManager.GetElevation(targetRoomCoordinates)).x,
                    roomManager.GetLadderRoomCoordinatesByY(roomManager.GetElevation(targetRoomCoordinates)).y-1.5f,
                    selectedCitizen.transform.position.z);
                    // directly go room
                    
                    targetRoomPositions[2]=new Vector3(targetRoomCoordinates.x,
                    targetRoomCoordinates.y-1.5f,
                    selectedCitizen.transform.position.z);

                }
                    selectedCitizen.SetTargetPosition(targetRoomPositions);
                     selectedCitizen.currentRoom=clickedRoom;
            }
        }



   // Oyun dünyası üzerinde bir şey yap
            }

        }
    }

    private string[] names = { "John", "Jane", "Bob", "Lisa", "Mike", "Anna", "Alex", "Ella", "Paul", "Mara" };

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

    void Start(){
        for(int i=0;i<4;i++){
            defineCitizen();
        }
    }
}
