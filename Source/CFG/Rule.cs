using System.Collections.Generic;
using UnityEngine;

namespace Source.CFG
{
    public class Rule
    {
        public string Input { get; private set; }
        private readonly List<string> outputs;
        private readonly List<float> probs;

        public Rule(string newInput)
        {
            Input = newInput;
            outputs = new List<string>();
            probs = new List<float>();
        }

        public void AddOutput(float prob, string output)
        {
            outputs.Add(output);
            probs.Add(prob);
        }

        public string ChooseOutput()
        {
            float val = Random.value;
            for (int i = 0; i < probs.Count; i++)
            {
                if (val < probs[i])
                {
                    return outputs[i];
                }
                else
                {
                    val -= probs[i];
                }
            }

            return Input;
        }
    }
}