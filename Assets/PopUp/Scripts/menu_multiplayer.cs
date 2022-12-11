using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class menu_multiplayer : MonoBehaviour {

    // Declare a variable to hold the menu
    public GameObject panel;
    public GameObject buttom;
    public GameObject list_buttom;
    public GameObject add_buttom;
    public GameObject inv_buttom;
    public GameObject Quit_buttom;



    // This is the function that will be called when the user clicks on "Item 1"
    public void listFriendsMenu() {

        panel.SetActive(false);
        list_buttom.SetActive(false);
        add_buttom.SetActive(false);
        inv_buttom.SetActive(false);
        Quit_buttom.SetActive(false);

        // Shows list fo friends
        // We need here the funtion for showing the list of friends
        print("List friends funtion");
    }

    // This is the function that will be called when the user clicks on "Item 2"
    public void AddFriendsMenu() {

        panel.SetActive(false);
        list_buttom.SetActive(false);
        add_buttom.SetActive(false);
        inv_buttom.SetActive(false);
        Quit_buttom.SetActive(false);

        // Let you add friends
        print("Add");
    }

    // This is the function that will be called when the user clicks on "Item 3"
    public void InviteFriendsMenu() {

        panel.SetActive(false);
        list_buttom.SetActive(false);
        add_buttom.SetActive(false);
        inv_buttom.SetActive(false);
        Quit_buttom.SetActive(false);

        // Let you invite friends
        print("Invite");
    }

    // This is the function that will be called when the user clicks on "Item 4"
    public void QuitMenu() {
    
        // it will quit the menu
        panel.SetActive(false);
        list_buttom.SetActive(false);
        add_buttom.SetActive(false);
        inv_buttom.SetActive(false);
        Quit_buttom.SetActive(false);
        buttom.SetActive(true);
    }
}

