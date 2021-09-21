using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Superdigital.Tests.Core
{
    public class ElementsToAnalyze
    {
        public ElementsToAnalyze(int element, int position)
        {
            this.Element = element;
            this.Position = position;

        }
        public int Element { get; set; }
        public int Position { get; set; }
    }
    public class CalculateIdentifySumPattern : ICalculate<IDictionary<int[], int>, int[]>
    {
        public int[] Handle(IDictionary<int[], int> parameter) 
        {
            IList<ElementsToAnalyze> elements = ConvertToComplexObject(parameter.First().Key);
            return SumAndAnalyze(elements, parameter.First().Value);
        }

        private int[] SumAndAnalyze(IList<ElementsToAnalyze> listToAnalyze, int target)
        {
            int acumulatedValue = 0;
            IList<ElementsToAnalyze> contextElements = new List<ElementsToAnalyze>();
            int count = 0;
            foreach (var element in listToAnalyze)
            {
                acumulatedValue += element.Element;
                contextElements.Add(element);
                if (acumulatedValue == target)
                    return contextElements.Select(x => x.Position).ToArray();
                else if (acumulatedValue > target)
                {
                    var newListToAnalyze = listToAnalyze.ToList();
                    newListToAnalyze.RemoveAt(0);
                    return SumAndAnalyze(newListToAnalyze.ToArray(), target);
                }
                count++;
            }
            return new int[2] { -1, -1 };
        }

        private IList<ElementsToAnalyze> ConvertToComplexObject(int[] listToAnalyze)
        {
            IList<ElementsToAnalyze> elements = new List<ElementsToAnalyze>();
            for (int i = 0; i < listToAnalyze.Length; i++)
            {
                elements.Add(new ElementsToAnalyze(listToAnalyze[i], i));
            }

            return elements;
        }
    }
}