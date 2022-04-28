using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournamentDisplay : MonoBehaviour
{
   [SerializeField]
   private Transform content;

   [SerializeField]
   private GameObject tournamentGO;

   const int PADDING = 100;

   private void Start() {
      APIManager.onGetTournaments += DisplayTournaments;
   }

   private void DisplayTournaments()
   {
      Tournament tournament = APIManager.GetTournamentInfo();
      if(tournament != null)
      {
         RectTransform rectTransform = content.GetComponent<RectTransform>();
         //rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, PADDING*tournament.data.Length);
         foreach (var item in tournament.data)
         {
            GameObject go = GameObject.Instantiate(tournamentGO,content);
            go.name = go.name +"_"+item.id;
            TournamentInfo ti = go.GetComponent<TournamentInfo>();
            ti.ID = item.id;
            ti.DATE = item.attributes.createdAt;
            
         }
      }
   }

   
}
