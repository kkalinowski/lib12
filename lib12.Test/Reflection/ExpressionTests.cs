using lib12.Reflection;
using Should;
using System;
using System.Linq.Expressions;
using Xunit;

namespace lib12.Test.Reflection
{
    public class ExpressionTests
    {
        private class ExpressionTestsSource
        {
            public string Text { get; set; }

            public ExpressionTestsSource()
            {
                
            }

            public ExpressionTestsSource(string text)
            {
                Text = text;
            }
        }

        [Fact]
        public void get_name_works()
        {
            Expression<Func<ExpressionTestsSource, string>> expression = x => x.Text;

            expression.GetName().ShouldEqual("Text");
        }

        [Fact]
        public void get_value_works()
        {
            const string text = "Winter is coming...";
            var source = new ExpressionTestsSource(text);
            Expression<Func<ExpressionTestsSource, string>> expression = x => x.Text;

            expression.GetValue(source).ShouldEqual(text);
        }

        public void set_value_works()
        {
            const string text = "Winter is coming...";
            var source = new ExpressionTestsSource();
            Expression<Func<ExpressionTestsSource, string>> expression = x => x.Text;

            expression.SetValue(source, text);
            source.Text.ShouldEqual(text);
        }
    }
}