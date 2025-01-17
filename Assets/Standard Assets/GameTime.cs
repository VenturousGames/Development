﻿using UnityEngine;
using System.Collections;


public class GameTime : MonoBehaviour {
	
	public bool setClockWhenStarting;
	public int startDay;
	public int startHour;
	public int startMinute;
	public int setDayLengthInSeconds;
	//Scale of Time (How fast it goes by)
	//IF YOU change this, make sure to match it with the value in GameTime (secondsPerSecond)
	private float setGameTimeScale = 2000;
	
	public GameTime() {
		_GameClock = 0f;
	}
	
	private static GameTime _Instance;
	public static GameTime Instance() {
		if (_Instance == null) {
			_Instance = new GameTime();
			return _Instance;
		}
		else {
			return _Instance;
		}
	}
	
	public void Awake() {
		if (_Instance != null) {
			Destroy(this);
		}
		else {
			_Instance = this;
		}
		if (setClockWhenStarting == true) { SetClock(startDay, startHour, startMinute, 0); }
	}
	
	public const int FIRSTDAY = 1;
	public const float DAY = 24;
	public const float HOUR = 60;
	public const float MINUTE = 60;

	public float _GameClock;
	
	public float GameClockInDays {
		get { return _GameClock / (DAY * HOUR * MINUTE); }
		set { _GameClock = value * (DAY * HOUR * MINUTE); }
	}
	public int GameDay {
		get { return FIRSTDAY + (int)GameClockInDays; }
	}
	public int GameHour {
		get { return (int)((GameClockInDays * DAY) % DAY); }
	}
	public int GameMinute {
		get { return (int)((GameClockInDays * DAY * HOUR) % HOUR); }
	}
	public int GameSecond {
		get { return (int)((GameClockInDays * DAY * HOUR * MINUTE) % MINUTE); }
	}
	public void SetClock(int d, int h, int m, int s) {
		GameClockInSeconds = (float)(d-FIRSTDAY) * (DAY * HOUR * MINUTE) + (float)(h) * (HOUR * MINUTE) + (float)(m) * MINUTE + (float)(s);
	}
	public float GameClockInSeconds {
		get { return _GameClock; }
		set { _GameClock = value; }
	}
		
	private float _GameTimeScale;
	public float GameTimeScale {
		get { return _GameTimeScale; }
		set { if (value>0) { _GameTimeScale = value; } }
	}
	public float DayLengthInSeconds {
		get { if (_GameTimeScale > 0f) { return ((24f * 60f * 60f) / _GameTimeScale); } else { return 0f; } }
		set { if (value>0) { _GameTimeScale = (24f * 60f * 60f) / value; } }
	}
	
	public float _AutomaticAdvance;
	public float AutomaticAdvance {		
		get { return _AutomaticAdvance; } 
		set { if (value>=0) { _AutomaticAdvance = value; } }
	}

	public void Start () {
		if (setGameTimeScale > 0) {
			if (setDayLengthInSeconds > 0) {
				GameTimeScale = 2000;
			}
			else {
				GameTimeScale = setGameTimeScale;
			}
		}
		else {
			if (setDayLengthInSeconds > 0) {
				DayLengthInSeconds = setDayLengthInSeconds;
			}
			else {
				GameTimeScale = 2000;
			}
		}
	}
	
	public void Update () {
	 	if (AutomaticAdvance>0) {
			GameClockInSeconds = GameClockInSeconds + Time.deltaTime*GameTimeScale;
		}
	}

}
