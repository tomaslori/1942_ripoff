using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AircraftManager
{
	public Dictionary <string, AircraftData> aircrafts;
	
	public AircraftManager ()
	{
		aircrafts = new Dictionary<string, AircraftData> ();
		aircrafts.Add("F-22B",   new AircraftData (70.0f, 110.0f,  1, new GunsData (1.75f, 8.0f, 0.25f)));
		aircrafts.Add("F-35D",   new AircraftData (40.0f, 70.0f,  1, new GunsData (1.5f, 6.0f, 0.1f)));
		aircrafts.Add("FA-28A",  new AircraftData (55.0f, 90.0f,  2, new GunsData (2.5f, 6.5f, 0.2f)));
		aircrafts.Add("MiG-51",  new AircraftData (40.0f, 65.0f,  3, new GunsData (2.0f, 5.25f, 0.25f)));
		aircrafts.Add("MiG-51S", new AircraftData (40.0f, 65.0f,  1, new GunsData (5.0f, 5.25f, 0.25f)));
		aircrafts.Add("SR-91A",  new AircraftData (27.5f, 45.0f, 5, new GunsData (1.0f, 4.0f, 0.4f)));
	}
	
	public AircraftData getAircraft (string aircraftName)
	{
		return aircrafts[aircraftName];
	}
}

