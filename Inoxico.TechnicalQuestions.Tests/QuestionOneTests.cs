using Inoxico.TechnicalQuestions.Answers;
using Xunit;

namespace Inoxico.TechnicalQuestions.Tests
{
    public class QuestionOneTests
    {
        [Fact]
        public void ExampleTest()
        {
            var input = $"We test coders. Give us a try?";
            var outcome = QuestionOne.GetLongestSentance(input);

            Assert.Equal(4, outcome);
        }
    }
}