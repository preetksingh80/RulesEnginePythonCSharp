using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using Subject;

namespace Rules
{
    public class RulesEngine
    {
        public LoanApplication LoanApplication { get; private set; }
        public LoanShark LoanShark { get; private set; }

        public RulesEngine(LoanApplication loanApplication, LoanShark loanShark)
        {
            LoanApplication = loanApplication;
            LoanShark = loanShark;
        }

        public bool IsEligible()
        {
            CreateScriptingParts();
            return LoanShark.EligibilityRules.All(Eligible);
        }


        private bool Eligible(string eligibiltyRule)
        {
            var script = _engine.CreateScriptSourceFromString(eligibiltyRule); // create the python script out of the rule at hand
            _scope.SetVariable("loanApplication", LoanApplication); // in the rule "loanApplication.LoanAmount > 0", replace the "loanApplication" with the real loanApplication Object
            return script.Execute<bool>(_scope);// execute and get the result as a boolean
        }

        private void CreateScriptingParts()
        {
            _engine = Python.CreateEngine(); // create python engine
            _runtime = _engine.Runtime; // create the runtime for the engine
            _scope = _runtime.CreateScope(); // create the scope in which you are going to execute the script
        }


        private ScriptEngine _engine;
        private ScriptRuntime _runtime;
        private ScriptScope _scope;

    }
}
