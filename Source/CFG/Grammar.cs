using System.Collections.Generic;

namespace Source.CFG
{
    public class Grammar
    {
        private readonly List<Rule> rules;
        public string Current { get; set; }

        public Grammar(string startSymbol)
        {
            Current = startSymbol;
            rules = new List<Rule>();
        }

        public void AddRule(Rule rule)
        {
            rules.Add(rule);
        }

        public string Iterate()
        {
            for (int i = 0; i < Current.Length; i++)
            {
                foreach (Rule rule in rules)
                {
                    if (i + rule.Input.Length < Current.Length)
                    {
                        string sub = Current.Substring(i, rule.Input.Length);
                        if (sub == rule.Input)
                        {
                            Current = Current.Remove(i, rule.Input.Length);
                            Current = Current.Insert(i, rule.ChooseOutput());
                        }
                    }
                }
            }
            
            return Current;
        }
    }
}