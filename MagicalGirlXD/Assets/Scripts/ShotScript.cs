﻿using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {
	public bool isEnemyShot = false;
	public float speed = 10f;
	public float playerRange = 10f;
    public float enemyRange = 100f;
	public int damage = 1;
    public Vector3 direction;

	float elapsedDistance;
    BoxCollider2D shotCollider;
    Rigidbody2D body;
	Vector3 movement;

	void Start() {
		body = GetComponent<Rigidbody2D>();
        shotCollider = GetComponent<BoxCollider2D>();
		elapsedDistance = 0;
	}

	void FixedUpdate() {
		movement = new Vector3(
			speed * direction.x * Time.deltaTime,
			speed * direction.y * Time.deltaTime, 0f);
		body.MovePosition(transform.position + movement);
		elapsedDistance += movement.magnitude;
		if((!isEnemyShot && elapsedDistance >= playerRange) || (isEnemyShot && elapsedDistance >= enemyRange))
			Destroy(gameObject, 0f);
	}

	void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Something something shot " + other.name);
	    if (!isEnemyShot && (other.name == "MeleeEnemy(Clone)" || other.name == "RangedEnemy(Clone)")) {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
			enemy.TakeDamage(damage);
            if (shotCollider != null)
                shotCollider.enabled = false;
			Destroy(gameObject, 0.1f);
		}

        if (isEnemyShot && other.name == "Player") {
            Player player = other.gameObject.GetComponent<Player>();
            player.TakeDamage(damage);
            if(shotCollider != null)
                shotCollider.enabled = false;
            Destroy(gameObject, 0.1f);
        }
	}
}