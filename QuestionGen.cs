using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Project2_BuildAapi
{
    public class QuestionGen
    {
        Random rnd = new Random();

        List<String>  questionArray = new List<String>();
        string[] operators = new[]
        {
             "*", "-", "+"
        };
        
        public String question()
        {
            Debug.WriteLine("Start");
            int noExpr = rnd.Next(1, 3);
            String expr = "";
            var listOfStrings = new List<string>();
            listOfStrings.Add(rnd.Next(1, 11).ToString());
            
            for (int i = 0; i < noExpr; i++)
            {
                listOfStrings.Add(operators[rnd.Next(0, 3)]);
                listOfStrings.Add(rnd.Next(1, 11).ToString());

            }
            string[] arrayOfStrings = listOfStrings.ToArray();
            for(int i = 0; i < arrayOfStrings.Length; i++)
                expr+=arrayOfStrings[i];
            Debug.WriteLine(expr);

          
            return expr;
        }
        public int[] genOptions(String expr)
        {
            int[] options = {0, 0, 0, 0};
            DataTable dt = new DataTable();
            var v = dt.Compute(expr, "");
            options[rnd.Next(0, 2)]=(int)v;
            options[3]=(int)v;
            for (int i = 0; i < options.Length; i++)
            {
                if (options[i]==0)
                    options[i] = rnd.Next(-10, 20);
            }
            string opt="";
            for (int i = 0; i < options.Length; i++)
                opt+=options[i].ToString();
            Debug.WriteLine(opt);

            return options;
        }
    }
}
