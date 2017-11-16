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
            foreach (Rule rule in rules)
            {
                if (current.Contains(rule.input))
                {
                    current = current.Replace(rule.input, rule.ChooseOutput());
                }
            }
        }
    }
}