using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.CFG
{
    public class Generator
    {
        public Grammar grammar { get; private set; }
        public Vector2 start { get; private set; }
        public Vector2 goal { get; private set; }
        
        public Generator()
        {
            grammar = new Grammar(GenerateStartPath());
            
            // Right turn.
            Rule rightRule = new Rule("RFF");
            rightRule.AddOutput(0.3f, "FRFRFLF");
            // Left turn.
            Rule leftRule = new Rule("LFF");
            leftRule.AddOutput(0.3f, "FLFLFRF");
            // Straight away.
            Rule straightRule = new Rule("FFF");
            straightRule.AddOutput(0.25f, "FRFLFLFRF");
            straightRule.AddOutput(0.25f, "FLFRFRFLF");
            
            grammar.AddRule(rightRule);
            grammar.AddRule(leftRule);
            grammar.AddRule(straightRule);
        }

        private string GenerateStartPath()
        {
            // Choose start and goal.
            start = new Vector2((int)(Random.value * MapVars.width), (int)(Random.value * MapVars.height));
            do
            {
                // This should probably be a bit smarter.
                goal =  new Vector2((int)(Random.value * MapVars.width), (int)(Random.value * MapVars.height));
                
            } while (Vector2.Distance(start, goal) < GeneratorRules.toGoalMin * MapVars.width);

            string result = "";
            if (start.x < goal.x)
            {
                result += "R";
            }
            else
            {
                result += "L";
            }
            result += new string('F', (int)Math.Abs(start.x - goal.x));
            
            if (start.y < goal.y)
            {
                if (result[0] == 'R') result += "L";
                else result += "R";
            }
            else
            {
                if (result[0] == 'R') result += "R";
                else result += "L";
            }
            result += new string('F', (int)Math.Abs(start.y - goal.y));
            return result;
        }
    }
}