// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.4.0.0
//      Runtime Version:4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
namespace ChessBoard.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Taking a piece.")]
    public partial class TakingAPiece_Feature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "TakingAPiece.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Taking a piece.", "In order to play chess\r\nAs a Player\r\nI want to be able to take the oppositions pi" +
                    "ece.", GenerationTargetLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Pawn Takes the Knight")]
        public virtual void PawnTakesTheKnight()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Pawn Takes the Knight", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
testRunner.Given("I have a White Pawn at D3");
#line 8
testRunner.And("I have a Black Knight at C4");
#line 9
testRunner.When("the Pawn moves to C4");
#line 10
testRunner.Then("the Knight should be taken");
#line 11
testRunner.And("the Pawn should be at C4");
#line 12
testRunner.And("I should be shown \"Pawn takes Knight. Pawn wins\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Pawn collides with Knight.")]
        public virtual void PawnCollidesWithKnight_()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Pawn collides with Knight.", ((string[])(null)));
#line 14
this.ScenarioSetup(scenarioInfo);
#line 15
testRunner.Given("I have a White Pawn at C3");
#line 16
testRunner.And("I have a Black Knight at C4");
#line 17
testRunner.When("the Pawn moves to C4");
#line 18
testRunner.Then("the Knight should be at C4");
#line 19
testRunner.And("the Pawn should be at C3");
#line 20
testRunner.And("I should be shown \"Pawn collides with Knight. Draw\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Knight takes Pawn.")]
        public virtual void KnightTakesPawn_()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Knight takes Pawn.", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
testRunner.Given("I have a Black Knight at D6");
#line 24
testRunner.And("I have a White Pawn at F6");
#line 25
testRunner.And("the Pawn moves to F7");
#line 26
testRunner.When("I move the Knight to F7");
#line 27
testRunner.Then("the Pawn should be taken");
#line 28
testRunner.And("I should be shown \"Knight takes Pawn. Knight Wins\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
