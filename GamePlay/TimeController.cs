 using System;
 using System.Collections.Generic;
 using UnityEngine;

 public class TimeController
 {
     public List<ITimeDependenced> Dependences => _timeCells;


     private List<ITimeDependenced> _timeCells = new(10);
     private float _timeGap;

     private const string PREVIOS_UPDATE = "PreviousDataUpdate"; 
     
     public TimeController( float hoursTimeGap)
     {
         _timeGap = hoursTimeGap;

         CheackDataActuallity();
     }
     
     
     public void CheackDataActuallity()
     {
         var currentTime = DateTime.Now;
         
         if (GetParsedTime().AddHours(_timeGap) <= currentTime)
         {
             SetPreviousUpdateTime();
             foreach (var cell in _timeCells)
             {
                 cell.ResetData();
             }
         }
     }

     private DateTime GetParsedTime()
     {
         DateTime parsedTime = new DateTime();

         if (DateTime.TryParse(PlayerPrefs.GetString(PREVIOS_UPDATE), out parsedTime) == false)
         {
             SetPreviousUpdateTime();
         }

         return parsedTime;
     }

     public TimeSpan GetGap()
     {
         var go = GetParsedTime().AddHours(_timeGap) - DateTime.Now;
         return go;
     }

     private void SetPreviousUpdateTime()
     {
         PlayerPrefs.SetString(PREVIOS_UPDATE, DateTime.Now.ToString());
     }
 }