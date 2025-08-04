using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting;
using NCalc;

namespace ScallingLaws_example.Model
{
    public class ScalingLaw
    {
        #region public Properties
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> RequeiredInputs { get; set; }
        public string Formula { get; set; }
        public Interpreter Interpreter { get; set; }
        public List<string> Expression { get; set; }
        public ApplicableTo ApplicableTo { get; set; }
        #endregion

        #region Other methods

        /// <summary>
        ///     EvaluateExpression(args) method caluclate values for THIS scalingLaw. It can use either IronPython or NCalc and returns the results in a dictionary.
        ///     In case of NCalc the dictionary has only one item called: result, value.
        ///     
        ///     Additional documantation for NCalc can be found here: https://riptutorial.com/ncalc/learn/100000/getting-started
        /// </summary>
        /// <param name="args">
        ///     Arguments shall use a format such as: "variable1=1.542", "variable=2.34"
        /// </param>
        /// <returns>
        ///     The method returns a ScalingLawResult record. 
        ///     The record has two iterms:
        ///         - Type of interpreter (Interpreter)
        ///         - Dictionarry of results. In case of NCalc, this dicutionary has only one item (result, value), 
        ///           in case of Python this returns or internal variables and their values.
        /// </returns>
        /// 
        /// TODO: Does not have exception handling. Needs to implement. 
        public ScalingLawResults EvaluateExpression(params string[] args)
        {
            string expressionToEvaluate = "";
            ScalingLawResults output = new(null, null);

            if (Expression.Count == 1)
                expressionToEvaluate = Expression[0];
            else if (Expression.Count > 1)
                expressionToEvaluate = String.Join("\n", Expression);

            // Evaluation of what interepreter shall be used and evaluating the expression
            if (this.Interpreter == Interpreter.NCalc)
                output = new ScalingLawResults(Interpreter.NCalc, NCalcInterprerter(expressionToEvaluate, InputParameters(args)));
            else if (this.Interpreter == Interpreter.IronPython)
                output = new ScalingLawResults(Interpreter.IronPython, IronPythonInterprerter(expressionToEvaluate, InputParameters(args)));

            return output;
        }

        /// <summary>
        ///     This method translate the input parameters to a Dictionary(varibale name, value).
        ///     This format is then used in NCalcInterpreter and IronPythonInterpreter.
        /// </summary>
        /// <param name="args">
        ///     Arguments shall use a format such as: "variable1=1.542", "variable=2.34"
        /// </param>
        /// <returns>
        ///     The method returns all input parameters in Dictionary.
        /// </returns>
        /// 
        /// TODO: Implement exception handling. Check if the input is successfully transformed to double. 
        /// TODO: Maybe of interest to enable arrays?
        private Dictionary<string, object> InputParameters(string[] args)
        {
            Dictionary<string, object> parameters = new();

            foreach (string arg in args)
            {
                string[] inputParamaters;
                inputParamaters = arg.Split('=');
                parameters.Add(inputParamaters[0].Trim().ToLower(), Convert.ToDouble(inputParamaters[1]));
            }

            return parameters;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expressionToEvaluate"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private Dictionary<string, object> NCalcInterprerter(string expressionToEvaluate, Dictionary<string, object> parameters)
        {
            Dictionary<string, object> output = new();
            Expression expression = new(expressionToEvaluate.ToLower(), EvaluateOptions.IgnoreCase)
            {
                Parameters = parameters
            };

            output.Add("result", expression.Evaluate());

            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// TODO: Implement exception handling (e.g. invalid input parameters)
        private Dictionary<string, object> IronPythonInterprerter(string code, Dictionary<string, object> parameters)
        {
            ScriptEngine engine = Python.CreateEngine();
            ScriptSource source = engine.CreateScriptSourceFromString(code, SourceCodeKind.File);
            ScriptScope scope = engine.CreateScope();

            foreach (KeyValuePair<string, object> parameter in parameters)
                scope.SetVariable(parameter.Key, parameter.Value);


            source.Execute(scope);

            List<string> variables = scope.GetVariableNames().ToList();
            Dictionary<string, object> results = new Dictionary<string, object>();

            foreach (string item in variables)
            {
                if (item != "__file__" && item != "__name__" && item != "__package__" && item != "__spec__" && item != "__doc__" && item != "__builtins__")
                    results.Add(item, (object)scope.GetVariable(item));
            }
            return results;
        }
        #endregion 
    }
}
