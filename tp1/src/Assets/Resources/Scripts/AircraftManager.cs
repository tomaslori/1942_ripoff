using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AircraftManager
{
	public Dictionary <string, AircraftData> aircrafts;
	
	public AircraftManager ()
	{
		aircrafts = new Dictionary<string, AircraftData> ();
		aircrafts.Add("F-22B",   new AircraftData (17.5f, 25.0f, 1, new GunsData (1.75f, 8.0f, 0.25f)));
		aircrafts.Add("F-35D",   new AircraftData (10.0f, 16.0f, 1, new GunsData (1.5f, 6.0f, 0.1f)));
		aircrafts.Add("FA-28A",  new AircraftData (14.0f, 21.0f, 2, new GunsData (2.5f, 6.5f, 0.2f)));
		aircrafts.Add("MiG-51",  new AircraftData (10.0f, 17.0f, 3, new GunsData (2.0f, 5.25f, 0.25f)));
		aircrafts.Add("MiG-51S", new AircraftData (10.0f, 17.0f, 1, new GunsData (5.0f, 5.25f, 0.25f)));
		aircrafts.Add("SR-91A",  new AircraftData ( 7.5f, 12.0f, 5, new GunsData (1.0f, 4.0f, 0.4f)));
	}
	
	public AircraftData getAircraft (string aircraftName)
	{
		return aircrafts[aircraftName];
	}
}

