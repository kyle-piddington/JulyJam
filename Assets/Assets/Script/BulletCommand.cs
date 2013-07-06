using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
public class BulletCommand
{

    public enum CommandType {cmd_fire, cmd_delay, cmd_move, cmd_rotate, cmd_stop, cmd_start };
    private CommandType myType;
    private List<float> args = new List<float>();


    public BulletCommand(string type)
    {
        myType = selectType(type);
    }
    public BulletCommand(string type, List<float> args)
    {
        myType = selectType(type);
        this.args = args;
    }

    public CommandType getType()
    {
        return myType;
    }
    public float getArg(int inx)
    {
        if (inx >= 0 && inx < args.Count)
        {
            return args[inx];
        }
        else
        {
            throw new IndexOutOfRangeException();
        }
    }
    public int getArgCount()
    {
        return args.Count;
    }
    private CommandType selectType(string type)
    {
        type = type.Trim();
        Debug.Log(type + ":"+type.Length);
            if(type.Equals("fire"))
                {
                    return CommandType.cmd_fire;
                    
                }
            else if(type.Equals( "delay"))
                {

                    return CommandType.cmd_delay;
                    
                }
            if(type.Equals("move"))
                {
                
                    return CommandType.cmd_move;
                    
                }

            if(type.Equals("rotate"))
                {
                    return CommandType.cmd_rotate;
                    
                }
            if(type.Equals( "stop"))
                {
                    return CommandType.cmd_stop;
                    
                }
            if(type.Equals( "start"))
                {
                    return CommandType.cmd_start;
                    
                }                {
            return CommandType.cmd_start;
                
        }
    


                       
    }


	
}
