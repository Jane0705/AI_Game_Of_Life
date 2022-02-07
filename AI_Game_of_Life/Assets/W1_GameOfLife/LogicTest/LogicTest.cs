using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LogicTest : MonoBehaviour
{
    private class TestData
    {
        public bool isAlive;
        public int neighbourCount;
        public bool nextState;

        // C#7 Object Destructuring
        internal void Deconstruct(out bool a, out int neighbourCount)
        {
            a = isAlive;
            neighbourCount = this.neighbourCount;
        }
    }

    private TextMeshProUGUI label;

    private void Awake()
    {
        label = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        // C#7 Local Function
        bool MiddleMan(bool livingState, int aliveCount)
        {
            return GameOfLifeUtility.DecideNextState(livingState, aliveCount);
        }

        List<TestData> currentIsLiving = new();
        List<TestData> currentIsDead = new();

        //List<TestData> currentIsLiving = new List<TestData>();
        //List<TestData> currentIsDead = new List<TestData>();

        for (var i = 0; i <= 8; i++)
        {
            currentIsLiving.Add(new TestData { isAlive = true, neighbourCount = i });
            currentIsDead.Add(new TestData { isAlive = false, neighbourCount = i });
        }

        StringBuilder sb1 = new();
        sb1.AppendLine("Logic Test:\n");
        StringBuilder sb2 = new();

        for (var i = 0; i <= 8; i++)
        {
            // C#7 Object Destructuring
            (var isAlive, int neighbourCount) = currentIsLiving[i];
            var nextState = MiddleMan(isAlive, neighbourCount);

            currentIsLiving[i].nextState = nextState;
            sb1.AppendLine($"[ <color=green>Alive</color>, Living Neighbours: {neighbourCount} ] Next State is {PrettyStatus(nextState)}");

            (isAlive, neighbourCount) = currentIsDead[i];
            nextState = MiddleMan(isAlive, neighbourCount);
            currentIsDead[i].nextState = nextState;
            sb2.AppendLine($"[ <color=red>Dead</color>, Living Neighbours: {neighbourCount} ] Next State is {PrettyStatus(nextState)}");
        }

        sb1.AppendLine();
        sb1.Append(sb2);

        label.text = sb1.ToString();
    }

    private static string PrettyStatus(bool isAlive)
    {
        return $"{(isAlive ? "<color=green>Alive" : "<color=red>Dead")}</color>";
    }
}