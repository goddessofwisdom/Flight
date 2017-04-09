using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainGame : MonoBehaviour {

	public ResourceManager ResourceManager;
	public Player Player;
	public CaptureGoal Goal;
	public ScenarioPrompt Prompt;
	public Enemy FirstEnemy;
	public ScoreView ScoreView;
	public LivesView LivesView;

	protected UpdateSimulator updateSimulator = new UpdateSimulator();

	//Initialization methods
	public void Start() {
		Screen.orientation = ScreenOrientation.Portrait;
		List<Enemy> Enemies = new List<Enemy> ();
		Enemies.Add (FirstEnemy);
		updateSimulator.Init(Player, Goal, Prompt, Enemies, ScoreView, LivesView, ResourceManager);
		updateSimulator.StartGame();
	}

	public void Update() {
		updateSimulator.Update();
	}
}
