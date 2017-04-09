using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSimulator { 
//excluding : MonoBehavior to avoid updating when not required (I think)

	protected bool DEGUB_INVINCIBLE = false;
	protected bool invincible = false;
	protected int invincibility_period = 0;

	protected Player player;
	protected CaptureGoal goal;
	protected ScenarioPrompt prompt;
	protected List<Enemy> enemies;
	protected ScoreView scoreView;
	protected LivesView livesView;
	protected ResourceManager resourceManager;

	protected int lives = 0;
	protected int score = 0;
	bool playerAlive = false;
	bool goalReached = false;

	public void Init(Player newPlayer, CaptureGoal newGoal, ScenarioPrompt newPrompt, List<Enemy> newEnemies, 
			ScoreView newScoreView, LivesView newLivesView, ResourceManager newResourceManager) {
		player = newPlayer;
		goal = newGoal;
		prompt = newPrompt;
		enemies = newEnemies;
		scoreView = newScoreView;
		livesView = newLivesView;
		resourceManager = newResourceManager;
	}

	public void StartGame () {
		goalReached = false;
		playerAlive = true;
		score = 0;
		lives = 3;
	}

	public void Update() {
		if (playerAlive) {
			ResolveMovement ();
			ResolveCollisions ();
			ResolveCleanUp ();
			scoreView.UpdateScore (score);
			livesView.UpdateLives (lives);
			//if the player is temporarily invincible after getting hit
			if (invincible) {
				invincibility_period++;
				if (invincibility_period > 20) {
					invincible = false;
					invincibility_period = 0;
				}
			}
		}
	}

	protected void ResolveMovement () {
		player.OnMove ();
		foreach (Enemy enemy in enemies) {
			enemy.OnMove ();
		}
	}

	protected bool HasCollision(Collider collider1, Collider collider2) {
		return collider1.bounds.Intersects(collider2.bounds);
	}

	protected bool HasCollision (Collider2D collider1, Collider2D collider2) {
		return collider1.bounds.Intersects (collider2.bounds);
	}

	protected void ResolveCollisions() {
		if (HasCollision (player.Collider2D, goal.Collider2D)) {
			score += 10;
			//remove goal and replace with new goal instantiated elsewhere
			goalReached = true;
		} else if (HasCollision (player.Collider2D, prompt.Collider2D)) {
			prompt.StartHarassmentScene ();
			//trigger harassment scenario
		} else {
			foreach (Enemy enemy in enemies) {
				if (HasCollision (player.Collider2D, enemy.Collider2D) && !invincible) {
					lives -= 1;
					invincible = true;
					if (lives == 0) {
						playerAlive = false;
						livesView.UpdateLives (lives);
						scoreView.UpdateScore (score);
						resourceManager.LoadDialog (ResourceManager.GAME_OVER);
					}
				}
			}
		}
	}

	protected void ResolveCleanUp() {
		if (goalReached == true) {
			SpawnNewGoal ();
			goalReached = false;
		}
	}

	protected void SpawnNewGoal () {
		//check out spawn gem in the demo project
		/*Vector3 oldPosition = goal.transform.position;
		GameObject.Destroy (goal);
		GameObject go = resourceManager.LoadPrefab(ResourceManager.TARGET);*/

	}
		

	// Use this for initialization
	void Start () {
		
	}

}
