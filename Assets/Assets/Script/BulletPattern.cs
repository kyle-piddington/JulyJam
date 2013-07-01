using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BulletPattern{

	// Use this for initialization
    
   
    private bool isActive = false;
    private bool isBullet = false;
    private int currCommandInx = 0;
   
    private float delay = 0;
    private float delayTime;

    protected Vector3 position;
    protected float angle;
    protected BulletPattern bullet = null;
    protected Vector2 Pos;
    protected BulletCommand currCommand;
    private List<BulletCommand> commandList;
    private List<BulletPattern> subPatterns = new List<BulletPattern>();
    private GameObject bulletModel;
    protected List<float> addlParams; //nullable
    //Addl params used by super classes. 
    public BulletPattern(List<BulletCommand> commandList, List<float> addlParams)
    {
        this.commandList = commandList;
        if (addlParams!=null)
        {
            this.addlParams = addlParams;
        }
        
    }

    public BulletPattern(List<BulletCommand> commandList, List<float> addlParams, bool isActiveOnStart)
    {
        this.commandList = commandList;
        if (addlParams != null)
        {
            this.addlParams = addlParams;
        }
        this.isActive = isActiveOnStart;
    }
    public void addSubPattern(BulletPattern pattern)
    {
        subPatterns.Add(pattern);
    }

    void Start () {
	
	}
	
	// Update is called once per frame
	public virtual void Update () {
        if (isActive)
        {
            if (bulletModel != null)
            {
                bulletModel.transform.position = this.get3DPosition();
            }
            if (delay > 0)
            {
                if (currCommandInx + 1 == commandList.Count)
                {
                    currCommandInx = 0;
                  
                }
                
                
                    currCommand = 
                            commandList[currCommandInx];
                    currCommandInx++;//Get command and increment
                    BulletCommand.CommandType nextCommandType = currCommand.getType();
                    switch(nextCommandType)
                    {
                        case BulletCommand.CommandType.cmd_delay:
                            {
                                
                                setDelay((int)currCommand.getArg(0)); 
                                break;
                            }
                        case BulletCommand.CommandType.cmd_fire:
                            {
                                Fire();
                                break;
                            }
                        case BulletCommand.CommandType.cmd_move:
                            {
                                move();
                                break;
                            }
                        case BulletCommand.CommandType.cmd_rotate:
                            {
                                rotate();
                                break;
                            }
                        case BulletCommand.CommandType.cmd_start:
                            {
                                start();
                                break;
                            }
                        case BulletCommand.CommandType.cmd_stop:
                            {
                                stop();
                                break;
                            }             
                    }
                
            }
            if (subPatterns.Count > 0)
            {
                foreach (BulletPattern b in subPatterns)
                {
                    b.Update();
                }
            }

        }
	}
    public virtual void Fire()
    {
        //Default fire, does nothing
    }
    private void setDelay(int milliSeconds)
    {
        delay = milliSeconds;
    }
    protected virtual void rotate()
    {

    }
    public void rotate(float angle)
    {
        this.angle += angle;
    }
    protected virtual void move()
    {
        //Default move, does nothing
    }
    public void move(Vector2 delta)
    {
        Pos.x += delta.x;
        Pos.y += delta.y;
    }
    public void setPosition(Vector2 pos)
    {
        position.x = pos.x;
        position.y = pos.y;
    }
    private void start()
    {
        isActive = true;
    }
    private void stop()
    {
        isActive = false;
    }
    public Vector3 get3DPosition()
    {
        return position;
    }
    public Vector2 getPosition()
    {
        return new Vector2(position.x, position.y);
    }
    public void setBullet(bool isBullet)
    {
        this.isBullet = isBullet;
    }
    public void setModel(GameObject model)
    {
        this.bulletModel = model;
    }
    public void setActive(bool active)
    {
        this.isActive = active;
    }
}
