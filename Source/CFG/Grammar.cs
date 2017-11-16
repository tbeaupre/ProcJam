using System.Collections.Generic;

namespace Source.CFG
{
    public class Grammar
    {
        private readonly List<Rule> rules;
        public string current { get; private set; }

        public Grammar(string startSymbol)
        {
            current = startSymbol;
            rules = new List<Rule>();
        }

        public void AddRule(Rule rule)
        {
            rules.Add(rule);
        }

        public void Iterate()
        {
            for (int i = 0; i < current.Length - 2; i++)
            {
                string sub = current.Substring(i, 3);
                
                foreach (Rule rule in rules)
                {
                    if (sub.Equals(rule.input))
                    {
                        current = current.Remove(i, 3);
                        current = current.Insert(i, rule.ChooseOutput());
                    }
                }
            }
        }
    }
}