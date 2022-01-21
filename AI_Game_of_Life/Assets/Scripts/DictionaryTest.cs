using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryTest : MonoBehaviour
{
    class Soldier
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        //Dictionary is unordered collection
        Dictionary<string, Vector3> dictionary = new();

        dictionary.Add("bob", new Vector3(0, 1, 1));
        dictionary.Add("eliza", new Vector3(0, 10, 30));
        dictionary.Add("jon", new Vector3(20, 10, 30));
        dictionary.Add("garfield", new Vector3(3, 10, 54));
        dictionary.Add("jeff", new Vector3(44, 18, 88));

        //dictionary.Add("bob", new Vector3(0, 1, 1)); //If we try to add a new bob, ERROR! bob already exist! You cannot add the same key again! But Value can be the same

        //If you want to replace the value of an existing key:
        dictionary["bob"] = new Vector3(99, 99, 99); //if bob exists, the value will be replaced with (99, 99, 99) //if bob did not exist, then a bob will be added to the dictionary

        //Cannot use this -> Debug.Log(dictionary[0]); because dictionary is an unordered collection

        Debug.Log(dictionary["bob"]); // Prints (0, 1, 1)
        Debug.Log(dictionary["garfield"]); // Prints (3, 10, 54)

        //if using dictionary, you can only use foreach to iterate
        //Check MSDN C# if have any issue or trouble with dictionary
        foreach(KeyValuePair<string, Vector3> kvp in dictionary) //or u can use foreach(var kvp in dictionary),
        {
            string key = kvp.Key;
            Vector3 value = kvp.Value;

            Debug.Log($"{key}: {value}"); // example print: bob (0, 1, 1)
        }

        //dictionary.ContainsKey(...)
        //bool hasValue = dictionary.TryGetValue(key, out ValueType val);


        //------------------------------------------------------------------------------------------------------------------------
        //storing a dictionary of Vector2 as a key and a list as value
        Dictionary<Vector2, List<Soldier>> soldiersInTiles = new();

        soldiersInTiles.Add(new Vector2(8, 8), new List<Soldier>
        {
            new Soldier(),
            new Soldier(),
            new Soldier(),
            new Soldier(),
            new Soldier(),
            new Soldier(),
        });

        Dictionary<string, Dictionary<string, string>> localizationBank = new();

        localizationBank["zh"] = new Dictionary<string, string>();
        // add localization to dictionary

        Debug.Log(localizationBank["zh"]["greet"]);

        localizationBank["my"] = new Dictionary<string, string>();
        //add localization to dictionary
        Debug.Log(localizationBank["my"]["greet"]);
        //------------------------------------------------------------------------------------------------------------------------

        List<Vector3> list = new();

        list.Add(new Vector3(0, 1, 1)); //list[0]
        list.Add(new Vector3(0, 10, 30)); //list[1]
        list.Add(new Vector3(20, 10, 30)); //list[2]
        list.Add(new Vector3(3, 10, 54)); //list[3]
        list.Add(new Vector3(44, 18, 88)); //list[4]

        Debug.Log(list[0]); //prints (0, 1, 1)
        Debug.Log(list[5]); //error, out of bounds

        //normally we use for loop when you have a limit, not to iterate everything 
        for(int i =0; i < list.Count; i++)
        {
            Vector3 element = list[i];
            Debug.Log(element);
        }

        //Difference: no built-in way to get currect index
        foreach(Vector3 element in list)
        {
            Debug.Log(element);
        }
        //------------------------------------------------------------------------------------------------------------------------


        Dictionary<int, Vector3> otherDictionary = new();

        otherDictionary.Add(0, new Vector3(0, 1, 1));
        otherDictionary.Add(-1000, new Vector3(0, 10, 30));
        otherDictionary.Add(2, new Vector3(20, 10, 30));
        otherDictionary.Add(30, new Vector3(3, 10, 54));
        otherDictionary.Add(4, new Vector3(44, 18, 88));

        Debug.Log(otherDictionary[0]); // Prints (0, 1, 1);
                                       //------------------------------------------------------------------------------------------------------------------------

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
