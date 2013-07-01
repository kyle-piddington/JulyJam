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

    private CommandType selectType(string type)
    {
        switch (type)
        {
            case "fire":
                {
                    return CommandType.cmd_fire;
                    
                }
            case "delay":
                {
                    return CommandType.cmd_delay;
                    
                }
            case "move":
                {
                    return CommandType.cmd_move;
                    
                }

            case "rotate":
                {
                    return CommandType.cmd_rotate;
                    
                }
            case "stop":
                {
                    return CommandType.cmd_stop;
                    
                }
            case "start":
                {
                    return CommandType.cmd_start;
                    
                }
            default:
                {
                    return CommandType.cmd_start;
                }
        }
    


                       
    }


	
}
