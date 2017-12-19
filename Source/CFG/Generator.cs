using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.CFG
{
    public class Generator
    {
        public Grammar Grammar { get; private set; }
        public Grammar CleanGrammar { get; private set; }
        public Vector2 Start { get; private set; }
        public Vector2 Goal { get; private set; }
        
        public Generator()
        {
            Grammar = new Grammar(GenerateStartPath());
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
            
            Grammar.AddRule(rightRule);
            Grammar.AddRule(leftRule);
            Grammar.AddRule(straightRule);
            
            // Set up the grammar for cleaning up the path.
            CleanGrammar = new Grammar("");
            // Right loop.
            Rule rightLoopRule = new Rule("FLFLFLF");
            rightLoopRule.AddOutput(0.5f, "FLFLFRF");
            rightLoopRule.AddOutput(0.5f, "FLFLFF");
            // Left loop.
            Rule leftLoopRule = new Rule("FRFRFRF");
            leftLoopRule.AddOutput(0.5f, "FRFRFLF");
            leftLoopRule.AddOutput(0.5f, "FRFRFF");
            
            CleanGrammar.AddRule(rightLoopRule);
            CleanGrammar.AddRule(leftLoopRule);
        }

        private string GenerateStartPath()
        {
            // Choose start and goal.
            Start = new Vector2((int)(Random.value * MapVars.width), (int)(Random.value * MapVars.height));
            do
            {
                // This should probably be a bit smarter.
                Goal =  new Vector2((int)(Random.value * MapVars.width), (int)(Random.value * MapVars.height));
            } while (Vector2.Distance(Start, Goal) < GeneratorRules.toGoalMin * MapVars.width);

            string result = "";
            if (Start.x < Goal.x)
            {
                result += "R";
            }
            else
            {
                result += "L";
            }
            result += new string('F', (int)Math.Abs(Start.x - Goal.x));
            
            if (Start.y < Goal.y)
            {
                if (result[0] == 'R') result += "L";
                else result += "R";
            }
            else
            {
                if (result[0] == 'R') result += "R";
                else result += "L";
            }
            result += new string('F', (int)Math.Abs(Start.y - Goal.y));
            return result;
        }
    }
}