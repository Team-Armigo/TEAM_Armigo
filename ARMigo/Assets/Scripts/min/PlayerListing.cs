using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
 

public class PlayerListing : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject playerListingPrefab;
    [SerializeField]
    private Transform playerListContent;

    //var newPlayerListing = Instantiate(playerListingPrefab, playerListContent);
 
    #region PUN 2 Callbacks
    public override void OnEnable()
    {
        base.OnEnable();
        //first we need to clear the list of any prior player listings
        //from previous games
        foreach (Transform child in playerListContent)
        {
            GameObject.Destroy(child.gameObject);
        }
        //then we trigger our refresh list function
        refreshPlayerListing();
    }
 
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        //create the players name object
        var newPlayerListing = Instantiate(playerListingPrefab, playerListContent);
        //and set the players name
        newPlayerListing.gameObject.transform.GetChild(0).GetComponent<Text>().text = newPlayer.NickName;
    }
 
    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        foreach (Transform child in playerListContent)
        {
            GameObject.Destroy(child.gameObject);
        }
        //then we trigger our refresh list function
        refreshPlayerListing();
    }
    #endregion
 
    private void refreshPlayerListing()
    {
        //this adds a player listing prefab for every player in the list
        foreach (var playersName in PhotonNetwork.PlayerList)
        {
            //create the players name object
            var newPlayerListing = Instantiate(playerListingPrefab, playerListContent);
            //and set the players name
            newPlayerListing.gameObject.transform.GetChild(0).GetComponent<Text>().text = playersName.NickName;
        }
    }
}
