using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour 
{
    public int number = 0;

    private GameObject playgame, levelselect, quit, back, ch1, ch2, ch3, lvlslct;

    private Color backTextColor;
	
	private bool levelselectcam = false;

    private void Start()
    {
        playgame = GameObject.Find("/newgame");
        levelselect = GameObject.Find("/level select");
        quit = GameObject.Find("/exit");

        backTextColor = renderer.material.color;
        backTextColor.a = 0;

        back = GameObject.Find("/back");
        ch1 = GameObject.Find("/ch1");
        ch2 = GameObject.Find("/ch2");
        ch3 = GameObject.Find("/ch3");
        lvlslct = GameObject.Find("/level heading");
    }

    public bool getLevelSelect()
    {
    	return levelselectcam;
    }

    private void Update()
    {
        switch(number)
        {
            case 0:
                playgame.renderer.material.color = Color.white;
                levelselect.renderer.material.color = Color.white;
                quit.renderer.material.color = Color.white;
                break;
            case 1:
                playgame.renderer.material.color = Color.red;
                levelselect.renderer.material.color = Color.white;
                quit.renderer.material.color = Color.white;
                break;
            case 2:
                playgame.renderer.material.color = Color.white;
                levelselect.renderer.material.color = Color.red;
                quit.renderer.material.color = Color.white;
                break;
            case 3:
                playgame.renderer.material.color = Color.white;
                levelselect.renderer.material.color = Color.white;
                quit.renderer.material.color = Color.red;
                break;
            case 4:
            	if(Camera.main.transform.position.x > 349)
            	{
		            	ch1.renderer.material.color = Color.red;
		                ch2.renderer.material.color = Color.white;
		                ch3.renderer.material.color = Color.white;
		                back.renderer.material.color = Color.white;
            	}
                break;
            case 5:
            	if(Camera.main.transform.position.x > 349)
            	{
	            	ch1.renderer.material.color = Color.white;
	                ch2.renderer.material.color = Color.red;
	                ch3.renderer.material.color = Color.white;
	                back.renderer.material.color = Color.white;
            	}
                break;
            case 6:
            	if(Camera.main.transform.position.x > 349)
            	{
	            	ch1.renderer.material.color = Color.white;
	                ch2.renderer.material.color = Color.white;
	                ch3.renderer.material.color = Color.red;
	                back.renderer.material.color = Color.white;
            	}
                break;
            case 7:
           		if(Camera.main.transform.position.x > 349)
            	{
	            	ch1.renderer.material.color = Color.white;
	                ch2.renderer.material.color = Color.white;
	                ch3.renderer.material.color = Color.white;
	                back.renderer.material.color = Color.red;
            	}
                break;
        }

        if (Input.GetMouseButtonDown (0) && number != 0)
        {
            switch (number)
            {
                case 1:
					//Application.LoadLevel ( level1 name here);
                    break;
                case 2:
					levelselectcam = true;
                    break;
                case 3:
                    Application.Quit();
                    break;
                case 4:
                	//Application.LoadLevel (level1);
                	break;
                case 5:
                	//Application.LoadLevel (level2);
                	break;
                case 6:
                	//Application.LoadLevel(level3);
                	break;
                case 7:
                	levelselectcam = false;
                	break;
            }
        }
		
		if(Camera.main.transform.position.x < 350 && levelselectcam)
		{
			Camera.main.transform.Translate(new Vector3(0,0,2*(350 - Camera.main.transform.position.x + 5)*Time.deltaTime));
		}

		if(Camera.main.transform.position.x > 90 && !levelselectcam)
		{
			Camera.main.transform.Translate(new Vector3(0,0,(90 - Camera.main.transform.position.x + 5)*Time.deltaTime));
		}

		if(!levelselectcam && Camera.main.transform.position.x < 300)
		{
			backTextColor.a = 0;
			ch1.renderer.material.color = backTextColor;
			ch2.renderer.material.color = backTextColor;
			ch3.renderer.material.color = backTextColor;
			back.renderer.material.color = backTextColor;
			lvlslct.renderer.material.color = backTextColor;
		}

		if(Camera.main.transform.position.x > 340)
		{
			backTextColor = ch1.renderer.material.color;
			backTextColor.a = (Camera.main.transform.position.x - 340)/10;
			ch1.renderer.material.color = backTextColor;

			backTextColor = ch2.renderer.material.color;
			backTextColor.a = (Camera.main.transform.position.x - 340)/10;
			ch2.renderer.material.color = backTextColor;

			backTextColor = ch3.renderer.material.color;
			backTextColor.a = (Camera.main.transform.position.x - 340)/10;
			ch3.renderer.material.color = backTextColor;

			backTextColor = back.renderer.material.color;
			backTextColor.a = (Camera.main.transform.position.x - 340)/10;
			back.renderer.material.color = backTextColor;

			backTextColor = lvlslct.renderer.material.color;
			backTextColor.a = (Camera.main.transform.position.x - 340)/10;
			lvlslct.renderer.material.color = backTextColor;
		}
	}
}
