using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Xunit_Exesize
{
    public class Test
    {

        //Nuget 引用:
        //1 Xunit 框架本身
        //2 xunit.runner.visualstudio 这使你可以在VS当中使用内置测试器运行测试

        //测试方法命名：遵守Arrange-Act-Assert(or "3A") 模式：即测试命名上“范围-作用-断言”规范。

        //Fact VS Theory
        //1 Fact试验总是正确的。他们测试条件不变。
        //2 Theory被测试的情况仅存在于特定的一组数据。

        //Ori/Fact/Theory参考:https://xunit.github.io/docs/getting-started/netfx/visual-studio
        //More 参考博客园文章:https://www.cnblogs.com/ccccc05/archive/2017/08/01/7266914.html 

        //Get：
        //1 当被除数或除数之一是double类型时并不会报错。当被除数，除数都是int类型时才会报错
        
        //更多：https://www.jianshu.com/p/f5a98a59b40d
            
        #region Ori_Method

        public int Add(int a, int b)
        {
            return a + b;
        }

        public double Devide(double up, double down)
        {
            var result = up / down;
            return result;
        }

        public double DevideWithErrorThrowException(int up, int down)
        {
            var result = up / down;
            return result;
        }

        #endregion

        #region Fact

        [Trait("Group", "Fact")]
        [Fact]
        public void TestTrue()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        [Trait("Group", "Fact")]
        public void TestFalse()
        {
            Assert.NotEqual(3, Add(1, 3));
        }

        #endregion

        #region Theory

        [Trait("Group", "Theory")]
        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 2)]
        [InlineData(3, 1)]
        [Trait("Group", "Theory")]
        public void TestTheoryTrue(int a,int b)
        {
            Assert.Equal(4, Add(a, b));
        }

        #endregion

        #region Exception

        /// <summary>
        /// 抛出异常
        /// 当被除数或除数之一是double类型时并不会报错。
        /// 当被除数，除数都是int类型时才会报错
        /// </summary>
        [Fact]
        [Trait("Group", "Exception")]
        public void ExceptionTestThrowException()
        {
            Assert.Throws<DivideByZeroException>(() => DevideWithErrorThrowException(2, 0));
        }


        #endregion

        #region 修改测试方法名称

        [Fact(DisplayName ="测试为真")]
        [Trait("Group", "DisplayName")]
        public void TestTrue2()
        {
            Assert.Equal(4, Add(2, 2));
        }

        #endregion

        #region 跳过测试用例

        /// <summary>
        /// 跳过测试表示为一个叹号
        /// </summary>
        [Fact(Skip = "跳过测试原因:还没有构建好",DisplayName ="跳过测试")]
        [Trait("Group", "Skip")]
        public void TestTrue3()
        {
            Assert.Equal(4, Add(2, 2));
        }

        #endregion

        #region 输出想输出的信息
        //https://xunit.github.io/docs/capturing-output.html
        private readonly ITestOutputHelper Output;
        public Test(ITestOutputHelper output)
        {
            this.Output = output;
        }

        [Trait("Group", "Output")]
        [Fact]
        public void TestOutput()
        {
            Output.WriteLine("测试输出");
            Assert.True(true);
        }


        #endregion



    }
}
