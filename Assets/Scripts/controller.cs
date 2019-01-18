using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class controller : MonoBehaviour 
{
	AudioSource ass;
	public Button menuu;
	Image btt;
	Text bt;
	public Text statuss;
	bool auuto=false;
	bool founConsecutive=false;
	bool gameOver = false;
	bool pw = false,cw =false;
	public GameObject s1,s11, s2,s21, s3,s31, s4,s41, s5,s51, s6,s61, s7,s71, s8,s81, s9,s91;
	SpriteRenderer a1,a2,b1,b2,c1,c2,d1,d2,e1,e2,f1,f2,g1,g2,h1,h2,i1,i2;
	int p1,p2,p3,p4,p5,p6,p7,p8,p9;
	// Use this for initialization
	void Start () 
	{
		ass = GetComponent<AudioSource> ();
		menuu.enabled = false;
		btt = menuu.GetComponent<Image> ();
		bt = menuu.GetComponentInChildren<Text> ();
		bt.enabled = false;
		btt.enabled = false;
		statuss.text = " ";
		a1 = s1.GetComponent<SpriteRenderer> ();
		a2 = s11.GetComponent<SpriteRenderer> ();
		b1 = s2.GetComponent<SpriteRenderer> ();
		b2 = s21.GetComponent<SpriteRenderer> ();
		c1 = s3.GetComponent<SpriteRenderer> ();
		c2 = s31.GetComponent<SpriteRenderer> ();
		d1 = s4.GetComponent<SpriteRenderer> ();
		d2 = s41.GetComponent<SpriteRenderer> ();
		e1 = s5.GetComponent<SpriteRenderer> ();
		e2 = s51.GetComponent<SpriteRenderer> ();
		f1 = s6.GetComponent<SpriteRenderer> ();
		f2 = s61.GetComponent<SpriteRenderer> ();
		g1 = s7.GetComponent<SpriteRenderer> ();
		g2 = s71.GetComponent<SpriteRenderer> ();
		h1 = s8.GetComponent<SpriteRenderer> ();
		h2 = s81.GetComponent<SpriteRenderer> ();
		i1 = s9.GetComponent<SpriteRenderer> ();
		i2 = s91.GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!gameOver)
			detecct ();
		else {
			menuu.enabled = true;
			btt.enabled = true;
			bt.enabled = true;
		}
		checkGameOver ();
	}
	void checkGameOver()
	{
		// You loose
		if ((p1 == 2 && p2 == 2 && p3 == 2)&& !gameOver) 
		{
			cw = true;
			gameOver = true;
		}
		if ((p4 == 2 && p5 == 2 && p6 == 2) && !gameOver) 
		{
			cw = true;
			gameOver = true;
		}
		if ((p7 == 2 && p8 == 2 && p9 == 2) && !gameOver) 
		{
			cw = true;
			gameOver = true;
		}
		/*Column detect*/
		if ((p1 == 2 && p4 == 2 && p7 == 2) && !gameOver) 
		{
			cw = true;
			gameOver = true;
		}
		if ((p2 == 2 && p5 == 2 && p8 == 2) && !gameOver) 
		{
			cw = true;
			gameOver = true;
		}
		if ((p3 == 2 && p6 == 2 && p9 == 2) && !gameOver) 
		{
			cw = true;
			gameOver = true;
		}
		/* Diagonal check*/
		if ((p1 == 2 && p5 == 2 && p9 == 2) && !gameOver) 
		{
			cw = true;
			gameOver = true;
		}
		if ((p3 == 2 && p5 == 2 && p7 == 2) && !gameOver) 
		{
			cw = true;
			gameOver = true;
		}
		//Debug.Log (gameOver);
		// You Win
		if ((p1 == 1 && p2 == 1 && p3 == 1)&& !gameOver) 
		{
			pw = true;
			gameOver = true;
		}
		if ((p4 == 1 && p5 == 1 && p6 == 1) && !gameOver) 
		{
			pw = true;
			gameOver = true;
		}
		if ((p7 == 1 && p8 == 1 && p9 == 1) && !gameOver) 
		{
			pw = true;
			gameOver = true;
		}
		/*Column detect*/
		if ((p1 == 1 && p4 == 1 && p7 == 1) && !gameOver) 
		{
			pw = true;
			gameOver = true;
		}
		if ((p2 == 1 && p5 == 1 && p8 == 1) && !gameOver) 
		{
			pw = true;
			gameOver = true;
		}
		if ((p3 == 1 && p6 == 1 && p9 == 1) && !gameOver) 
		{
			pw = true;
			gameOver = true;
		}
		/* Diagonal check*/
		if ((p1 == 1 && p5 == 1 && p9 == 1) && !gameOver) 
		{
			pw = true;
			gameOver = true;
		}
		if ((p3 == 1 && p5 == 1 && p7 == 1) && !gameOver) 
		{
			pw = true;
			gameOver = true;
		}
		//check draw
		if (!gameOver)
		{
			if (p1 != 0 && p2 != 0 && p3 != 0 && p4 != 0 && p5 != 0 && p6 != 0 && p7 != 0 && p8 != 0 && p9 != 0) {
				gameOver = true;
			}
			}
		if (gameOver) {
			if (pw && cw)
				statuss.text = " Draw ";
			else if (!pw && !cw)
				statuss.text = " Draw ";
			else if (pw && !cw)
				statuss.text = " You Win ";
			else if (!pw && cw)
				statuss.text = " You Loose ";
		}
	}
	void detecct ()
	{
		if (!auuto) {
			if (Input.GetMouseButtonDown (0)) {
				//	Debug.Log ("Clicked");
				ass.Play();
				Vector2 pos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
				RaycastHit2D hitInfo = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (pos), Vector2.zero);
				// RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
				if (hitInfo) {
					Debug.Log (hitInfo.transform.gameObject.name);
					player (hitInfo.transform.gameObject.name);
					// Here you can check hitInfo to see which collider has been hit, and act appropriately.
				}
			}
		}
		else{
			auutoPlay ();
			auuto = false;
	      }
	}
	void auutoPlay()
	{
		//Defensive stragey
		founConsecutive = false;
		if (p1==0)
		{
			if ((p2 == 1 && p3 == 1) || (p4 == 1 && p7 == 1) || (p5 == 1 && p9 ==1))
			{
				founConsecutive = true;
				p1 = 2;
				a2.enabled = true;
			}
	    }
		if (p2 == 0 && !founConsecutive)
		{
			if ((p1 == 1 && p3 == 1) || (p8 == 1 && p5 == 1)) 
			{
				founConsecutive = true;
				p2 = 2;
				b2.enabled = true;
			}
	    }
		if (p3 == 0 && !founConsecutive)
		{
			if ((p1 == 1 && p2 == 1) || (p6 == 1 && p9 == 1) || (p5 == 1 && p7 == 1 ) )
			{
				founConsecutive = true;
				p3 = 2;
				c2.enabled = true;
			}
		}
		if (p4 == 0 && !founConsecutive)
		{
			if ((p1 == 1 && p7 == 1) || (p5 == 1 && p6 == 1)) 
			{
				founConsecutive = true;
				p4 = 2;
				d2.enabled = true;
			}
		}
		if (p5 == 0 && !founConsecutive)
		{
			if ((p4 == 1 && p6 == 1) || (p2 == 1 && p8 == 1)) 
			{
				founConsecutive = true;
				p5 = 2;
				e2.enabled = true;
			}
		}
		if (p6 == 0 && !founConsecutive)
		{
			if ((p3 == 1 && p9 == 1) || (p4 == 1 && p5 == 1)) 
			{
				founConsecutive = true;
				p6 = 2;
				f2.enabled = true;
			}
		}
		if (p7 == 0 && !founConsecutive)
		{
			if ((p1 == 1 && p4 == 1) || (p8 == 1 && p9 == 1)) 
			{
				founConsecutive = true;
				p7 = 2;
				g2.enabled = true;
			}
		}
		if (p8 == 0 && !founConsecutive)
		{
			if ((p7 == 1 && p9 == 1) || (p2 == 1 && p5 == 1)) 
			{
				founConsecutive = true;
				p8 = 2;
				h2.enabled = true;
			}
		}
		if (p9 == 0 && !founConsecutive)
		{
			if ((p7 == 1 && p8 == 1) || (p3 == 1 && p6 == 1)) 
			{
				founConsecutive = true;
				p9 = 2;
				i2.enabled = true;
			}
		}
		//Attacking stragey
		if (p1==0 && !founConsecutive)
		{
			if ((p2 == 2 && p3 == 2) || (p4 == 2 && p7 == 2))
			{
				founConsecutive = true;
				p1 = 2;
				a2.enabled = true;
			}
		}
		if (p2 == 0 && !founConsecutive)
		{
			if ((p1 == 2 && p3 == 2) || (p8 == 2 && p5 == 2)) 
			{
				founConsecutive = true;
				p2 = 2;
				b2.enabled = true;
			}
		}
		if (p3 == 0 && !founConsecutive)
		{
			if ((p1 == 2 && p2 == 2) || (p6 == 2 && p9 == 2)) 
			{
				founConsecutive = true;
				p3 = 2;
				c2.enabled = true;
			}
		}
		if (p4 == 0 && !founConsecutive)
		{
			if ((p1 == 2 && p7 == 2) || (p5 == 2 && p6 == 2)) 
			{
				founConsecutive = true;
				p4 = 2;
				d2.enabled = true;
			}
		}
		if (p5 == 0 && !founConsecutive)
		{
			if ((p4 == 2 && p6 == 2) || (p2 == 2 && p8 == 2)) 
			{
				founConsecutive = true;
				p5 = 2;
				e2.enabled = true;
			}
		}
		if (p6 == 0 && !founConsecutive)
		{
			if ((p3 == 2 && p9 == 2) || (p4 == 2 && p5 == 2)) 
			{
				founConsecutive = true;
				p6 = 2;
				f2.enabled = true;
			}
		}
		if (p7 == 0 && !founConsecutive)
		{
			if ((p1 == 2 && p4 == 2) || (p8 == 2 && p9 == 2)) 
			{
				founConsecutive = true;
				p7 = 2;
				g2.enabled = true;
			}
		}
		if (p8 == 0 && !founConsecutive)
		{
			if ((p7 == 2 && p9 == 2) || (p2 == 2 && p5 == 2)) 
			{
				founConsecutive = true;
				p8 = 2;
				h2.enabled = true;
			}
		}
		if (p9 == 0 && !founConsecutive)
		{
			if ((p7 == 2 && p8 == 2) || (p3 == 2 && p6 == 2)) 
			{
				founConsecutive = true;
				p9 = 2;
				i2.enabled = true;
			}
		}

		if (!founConsecutive) {
			int count = 0;
			if (p1==0)
				count++;
			if (p2==0)
				count++;
			if (p3==0)
				count++;
			if(p4==0)
				count++;
			if(p5==0)
				count++;
			if (p6==0)
				count++;
			if (p7==0)
				count++;
			if (p7==0)
				count++;
			if (p8==0)
				count++;
			if (p9==0)
				count++;
			int tmp = -1;
			if (count > 0) {
				do {
					tmp = Random.Range (1, 10);
					if (tmp == 1)
					if (p1 != 0)
						continue;
					else
						break;
					if (tmp == 2)
					if (p2 != 0)
						continue;
					else
						break;
					if (tmp == 3)
					if (p3 != 0)
						continue;
					else
						break;
					if (tmp == 4)
					if (p4 != 0)
						continue;
					else
						break;
					if (tmp == 5)
					if (p5 != 0)
						continue;
					else
						break;
					if (tmp == 6)
					if (p6 != 0)
						continue;
					else
						break;
					if (tmp == 7)
					if (p7 != 0)
						continue;
					else
						break;
					if (tmp == 8)
					if (p8 != 0)
						continue;
					else
						break;
					if (tmp == 9)
					if (p9 != 0)
						continue;
					else
						break;
				
				} while (true);
				if (tmp != -1) {
					if (tmp == 1) {
						a2.enabled = true;
						p1 = 2;
					}
					if (tmp == 2) {
						b2.enabled = true;
						p2 = 2;
					}
					if (tmp == 3) {
						c2.enabled = true;
						p3 = 2;
					}
					if (tmp == 4) {
						d2.enabled = true;
						p4 = 2;
					}
					if (tmp == 5) {
						e2.enabled = true;
						p5 = 2;
					}
					if (tmp == 6) {
						f2.enabled = true;
						p6 = 2;
					}
					if (tmp == 7) {
						g2.enabled = true;
						p7 = 2;
					}
					if (tmp == 8) {
						h2.enabled = true;
						p8 = 2;
					}
					if (tmp == 9) {
						i2.enabled = true;
						p9 = 2;
					}


				}
			}
		}
		auuto = false;
	}
				
	void player(string detectorr)
	{
		if ((detectorr == "detector1") && p1 == 0) 
		{
			a1.enabled = true;
			p1 = 1;
		}
		if ((detectorr == "detector2") && p2 == 0) 
		{
			b1.enabled = true;
			p2 = 1;
		}
		if ((detectorr == "detector3") && p3 == 0) 
		{
			c1.enabled = true;
			p3 = 1;
		}
		if ((detectorr == "detector4") && p4 == 0) 
		{
			d1.enabled = true;
			p4 = 1;
		}
		if ((detectorr == "detector5") && p5 == 0) 
		{
			e1.enabled = true;
			p5 = 1;
		}
		if ((detectorr == "detector6") && p6 == 0) 
		{
			f1.enabled = true;
			p6 = 1;
		}
		if ((detectorr == "detector7") && p7 == 0) 
		{
			g1.enabled = true;
			p7 = 1;
		}
		if ((detectorr == "detector8") && p8 == 0) 
		{
			h1.enabled = true;
			p8 = 1;
		}
		if ((detectorr == "detector9") && p9 == 0) 
		{
			i1.enabled = true;
			p9 = 1;
		}
		auuto = true;
	}
	public void mmenu()
	{
		SceneManager.LoadScene (0);
	}
}
