using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
public class BulletPatternRegistry
{
    private static Dictionary<string,BulletPattern> bulletPatternsRegistry = new Dictionary<string,BulletPattern>();
    private static int currentPatternIndex = 0;
    public static List<GameObject> models = new List<GameObject>();
    public static void loadGameModels(List<GameObject> bulletMods)
    {
        foreach (GameObject gO in bulletMods)
        {
            //Debug.Log(gO.ToString());
            models.Add(gO);
        }
    }
    public static int readPatternsFromFile(string fileName)
    {
        try
        {

            StreamReader reader = new StreamReader(@"Assets/"+fileName);
            string fullFile = reader.ReadToEnd(); //Read all the bullet patterns
            string[] patterns = fullFile.Split('{');
       
            while(currentPatternIndex < patterns.Length)
            {
                //Debug.Log(patterns[currentPatternIndex]);
                if (patterns[currentPatternIndex] != "")
                {
                    constructPattern(patterns[currentPatternIndex], patterns, currentPatternIndex);
                }
                currentPatternIndex++;

            }
            currentPatternIndex = 0;
        }
        catch (Exception e)
        {

            Debug.Log("Problem opening file " + fileName );
            Debug.Log(e.Message);
            return 1;
        }
        foreach (object Key in bulletPatternsRegistry.Keys)
        {
            Debug.Log(Key.ToString());
        }
        return 0;


            
    }
    private static BulletPattern constructPattern(string patternData, string[] restOfPatterns, int inx)
    {

       string[] passedParams = patternData.Split('\n');
       string key = null;
       string className = null;
       int model =-1;
       List<float> addlParams = new List<float>();
       List<BulletCommand> commands = new List<BulletCommand>();
       List<BulletPattern> subPatterns = new List<BulletPattern>();
       bool startActive = false;
       bool isBullet = false;
       BulletPattern patt;
     
       foreach (string param in passedParams)
       {
          
           string[] paramSeperated = param.Trim().Split(' ');
           //Debug.Log(param)
       
           switch (paramSeperated[0].Trim())
           {
               case "_name":
                   {
                       key = paramSeperated[1];
                       Debug.Log("Adding key " + key);
                       break;
                   }
               case "_class":
                   {
                       className = paramSeperated[1];
                       break;
                   }
               case "_params":
                   {
                       {
                           for (int i = 1; i < paramSeperated.Length; i++)
                           {
                               addlParams.Add(float.Parse(paramSeperated[i]));
                           }
                       }
                       break;
                   }
               case "_command":
                   {
                       List<float> floatList = new List<float>(paramSeperated.Length - 2);
                       for (int i = 2; i < paramSeperated.Length; i++)
                       {
                           floatList.Add(float.Parse(paramSeperated[i]));

                       }
                       if (floatList.Count > 0)
                       {

                           commands.Add(new BulletCommand(paramSeperated[1], floatList));
                       }
                       else
                       {
                           commands.Add(new BulletCommand(paramSeperated[1]));
                       }
                       break;
                   }
               case "_startActive":
                    {
                        startActive = true;
                        break;
                    }
               case "_isBullet":
                    {
                        isBullet = true;
                        break;
                    }
               case "_model":
                    {
                        model = int.Parse(paramSeperated[1]);
                        break;
                    }
               case "_sub":
                    {

                        if(paramSeperated.Length > 0)
                        {
                            if(bulletPatternsRegistry.ContainsKey(paramSeperated[1]))
                            {
                                subPatterns.Add((BulletPattern)bulletPatternsRegistry[paramSeperated[1]]);
                            }
                            else
                            {
                                throw new Exception("Pattern construction error: " + paramSeperated[1] + " does not exist.");
                            }
                        }
                        else
                        {
                            subPatterns.Add(constructPattern(restOfPatterns[currentPatternIndex+1],restOfPatterns,currentPatternIndex+1));
                            currentPatternIndex++;
                        }
                        break;
                    }
               default:
                    break;
           


           }
       }
       if (key == null)
       {
           throw new Exception("Problem with creating new pattern lack of _name field. double check creation script");
       }
       if (className == null)
       {
           throw new Exception("Problem with creating new pattern, lack of _class field.");
       }
       if (commands.Count == 0)
       {
           throw new Exception("Problem creating new patterns, no _command field");
       }
       
       patt = createPatternByName(className,commands,addlParams);
       patt.setActive(startActive);
       foreach (BulletPattern p in subPatterns)
       {
           patt.addSubPattern(p);
       }
       patt.setBullet(isBullet);
       if (model != -1)
       {
           patt.setModel(model);
       }
       bulletPatternsRegistry.Add(key, patt);
      
       return patt;
    

    }
    private static BulletPattern createPatternByName(string name, List<BulletCommand> commands, List<float> addlParms)
    {
        switch (name)
        {
            case "SimpleBullet":
                {
                    return new BulletPattern(commands, addlParms);
                }
    
            default:
                {
                    return new BulletPattern(commands, addlParms);
                }
        }
    }
    public static BulletPattern getPattern(string key) 
    {
        foreach (string Key in bulletPatternsRegistry.Keys)
        {
            Debug.Log(Key + "#" + key);
            Debug.Log(Key.Length + " " + key.Length);
        }
        if (bulletPatternsRegistry.ContainsKey(key))
        {
            BulletPattern patt = bulletPatternsRegistry[key];
            return patt;
        }
        else
        {
            throw new Exception("Key " +key +" not found in registered patterns.");
        }
    }
 }
