using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Events")]
public class Events : ScriptableObject
{
    public string EventTitle;

    public string Event;

    public string[] EventChoices = new string[2];

    public string[] EventAffects = new string[2];

    /*
    // Event 1: Resource Scarcity
    string Event1 = "Your city faces a severe shortage of a crucial resource (e.g., food, fuel, or medicine). Citizens are getting desperate.";
    string[] Event1Choices = {
        "Implement rationing", gider azaltımı / mutluluk azalımı
        "Send scouts to search for resources", gidecek kişi sayısını ver arasından rastgele kişileri seç / kişilerin gücüne göre constant değer ekle kaynaklara 

        Mutluluk +
        Population
        Sağlık
        İsyan Oranı
        Genel Vault Sağlığı +

    };

    // Event 2: Outsider Arrival
    string Event2 = "A group of outsiders arrives at your city, seeking shelter and assistance.";
    string[] Event2Choices = {
        "Welcome them with open arms", kaynak gelir ve populasyon artar/ %50 ihtimalle mutluluk constant azalır veya artar / sağlık constant düşer
        "Turn them away"    hiçbirşey olmaz
    };

    // Event 3: Epidemic Outbreak
    string Event3 = "A deadly disease begins to spread among your citizens.";
    string[] Event3Choices = {
        "Isolate the sick", hasta kişiler kullanılamaz halde revirde kalır sabit kaynak harcamaya devam eder
        "Conduct medical research to find a cure" her kaynaktan constant miktar azalır %50 ihtimalle tüm hastalar iyileşir
    };

    // Event 4: Discontent Rebellion
    string Event4 = "Discontent among your citizens reaches a critical point, and they're threatening to rebel.";
    string[] Event4Choices = {
        "Suppress the rebellion with force", metal ve yemek constant azalır ve isyan oranı %50 azalır (70 ise 35   90 ise 45)
        "Negotiate with the leaders", %50 ihtimalle 
    };

    // Event 5: Resource Discovery
    string Event5 = "Scouts discover a hidden cache of valuable resources in the wilderness.";
    string[] Event5Choices = {
        "Extract the resources immediately", %50 ihtimalle adamların ölür yoksa hayatta kalır malzemeleri toplar
        "Set up a more efficient operation", constant kaynak harcanır ve malzemeler toplanır
    };

    // Event 6: Moral Dilemma
    string Event6 = "A desperate mother pleads with you to allow her child to work in dangerous conditions to help her family.";
    string[] Event6Choices = {
        "Allow the child to work",  mutluluk azalır constant kaynak artar
        "Refuse and provide support to the family", mutluluk artar constant kaynak azalır
    };

    // Event 7: Natural Disaster
    string Event7 = "The shelter flooded";
    string[] Event7Choices = {
        "Let the citizens drain the water", mutluluk azalır 
        "Strengthen the sewer system", kaynak azalır mutluluk artar
    };

    */
}
