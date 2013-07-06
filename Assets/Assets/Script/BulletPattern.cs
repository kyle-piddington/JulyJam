using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BulletPattern
{

    // Use this for initialization


    private bool isActive = false;
    private bool isBullet = false;
    private int currCommandInx = 0;

    private float delay = 0;
    private float delayTime;

    protected Vector3 position;
    protected float angle; //Degrees

    protected Vector2 position2d;
    protected BulletCommand currCommand;
    protected List<BulletCommand> commandList;
    protected List<BulletPattern> subPatterns = new List<BulletPattern>();
    private GameObject bulletModel;
    private int bulletModelInt = -1;
    protected List<float> addlParams; 
    //Addl params used by super classes. 
    public BulletPattern(List<BulletCommand> commandList, List<float> addlParams)
    {
        this.commandList = commandList;
        if (addlParams != null)
        {
            this.addlParams = addlParams;
        }

    }
    public BulletPattern() { }
    public void addParams(List<BulletCommand> cmd, List<float> args)
    {
        for (int i = 0; i < cmd.Count; i++)
        {
            this.commandList.Add(cmd[i]);
        }
        if (args != null)
        {
            this.addlParams = new List<float>(args.Count);
            for (int i = 0; i <args.Count; i++)
            {
                this.addlParams.Add(args[i]);
            }
        }
    }
    public BulletPattern(BulletPattern copy)
    {
        this.commandList = new List<BulletCommand>(copy.commandList.Count);
        for (int i = 0; i < copy.commandList.Count; i++)
        {
            this.commandList.Add(copy.commandList[i]);
        }
        if (copy.addlParams != null)
        {
            this.addlParams = new List<float>(copy.addlParams.Count);
            for (int i = 0; i < copy.addlParams.Count; i++)
            {
                this.addlParams.Add(copy.addlParams[i]);
            }
        }
        this.angle = copy.angle;
        this.bulletModelInt = copy.bulletModelInt;

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

    public void Start()
    {
        if (bulletModelInt != -1)
        {
            bulletModel = Object.Instantiate(BulletPatternRegistry.models[bulletModelInt],
                            position, Quaternion.identity) as GameObject;
        }
    }
    public List<BulletCommand> getBulletCommands()
    {
        return commandList;
    }
    public List<float> getParams()
    {
        return addlParams;
    }
    // Update is called once per frame
    public virtual void Update()
    {

        if (isActive)
        {


            if (bulletModel != null)
            {
                bulletModel.transform.position = this.get3DPosition();
            }
            if (delay > 0)
            {
                delay -= Time.deltaTime * 1000;

            }

            currCommand = commandList[currCommandInx];
            currCommandInx++;//Get command and increment
            BulletCommand.CommandType nextCommandType = currCommand.getType();

            if (currCommandInx >= commandList.Count)
            {
                currCommandInx = 0;
            }
            switch (nextCommandType)
            {
                case BulletCommand.CommandType.cmd_delay:
                    {

                        setDelay((int)currCommand.getArg(0));
                        break;
                    }
                case BulletCommand.CommandType.cmd_fire:
                    {
                        Fire();
                        if (currCommand.getArgCount() > 0)
                        {
                            setDelay((int)currCommand.getArg(0));
                        }
                        break;
                    }
                case BulletCommand.CommandType.cmd_move:
                    {

                        move();
                        break;
                    }
                case BulletCommand.CommandType.cmd_rotate:
                    {
                        if (currCommand.getArgCount() > 0)
                        {
                            rotate(currCommand.getArg(0));
                        }
                        else
                        {
                            rotate();
                        }
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
    public virtual void Fire()
    {
        if (delay <= 0)
        {

        }
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
        position.x += delta.x;
        position.y += delta.y;

    }
    public void setPosition(Vector2 position2d)
    {
        position.x = position2d.x;
        position.y = position2d.y;
        position = new Vector3(position2d.x, position2d.y, 0);
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
    public void setModel(int model)
    {
        this.bulletModelInt = model;

    }
    public void setActive(bool active)
    {
        this.isActive = active;
    }
    public bool getActive()
    {
        return this.isActive;
    }
}
