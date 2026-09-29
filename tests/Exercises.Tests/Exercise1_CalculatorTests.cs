using Exercises.Exercise1;

namespace Exercises.Tests;

/// <summary>
/// EXERCISE 1: testing existing code.
///
/// Write a test plan first (copy tasks/TEST_PLAN_TEMPLATE.md), then turn each row into a test
/// down here. Aim for at least three cases per method: a normal one, and the borderline
/// values at the edges of what a double can hold.
///
/// Every test below that is still a TODO carries [Ignore], so the suite passes on a fresh
/// clone. Delete the [Ignore] line once you have written the test.
/// </summary>
[TestFixture]
public class Exercise1_CalculatorTests
{
    private Calculator _calculator;

    [SetUp]
    public void SetUp()
    {
        _calculator = new Calculator();
    }

    // ---------------------------------------------------------------------------------
    // Add
    // ---------------------------------------------------------------------------------

    [Test]
    public void Add_TwoSmallNumbers_ReturnsTheirSum()
    {
        double num1 = 10;
        double num2 = 30;
        double expected = 40;

        double actual = _calculator.Add(num1, num2);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Add_TwoNegativeNumbers_ReturnsNegativeSum()
    {
        double num1 = -25;
        double num2 = -30;
        double expected = -55;

        double actual = _calculator.Add(num1, num2);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Add_MaxValueToMaxValue_ReturnsPositiveInfinity()
    {
        double num1 = double.MaxValue;
        double num2 = double.MaxValue;
        double expected = double.PositiveInfinity;

        double actual = _calculator.Add(num1, num2);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Add_TwoVerySmallNumbers_ReturnsSumOfSmallestValues()
    {
        double num1 = double.Epsilon;
        double num2 = double.Epsilon;
        double expected = double.Epsilon * 2;

        double actual = _calculator.Add(num1, num2);

        Assert.That(actual, Is.EqualTo(expected));
    }

    // ---------------------------------------------------------------------------------
    // Subtract
    // ---------------------------------------------------------------------------------

    [Test]
    public void Subtract_LargerFromSmaller_ReturnsNegativeResult()
    {
        double num1 = 30;
        double num2 = 60;
        double expected = -30;

        double actual = _calculator.Subtract(num1, num2);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Subtract_NumberFromItself_ReturnsZero()
    {
        double num1 = 50;
        double num2 = num1;
        double expected = 0;

        double actual = _calculator.Subtract(num1, num2);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Subtract_MinValueMinusMaxValue_ReturnsNegativeInfinity()
    {
        double num1 = double.MinValue;
        double num2 = double.MaxValue;
        double expected = double.NegativeInfinity;

        double actual = _calculator.Subtract(num1, num2);

        Assert.That(actual, Is.EqualTo(expected));
    }

    // ---------------------------------------------------------------------------------
    // Multiply
    // ---------------------------------------------------------------------------------

    [Test]
    public void Multiply_TwoNormalNumbers_ReturnsProduct()
    {
        double num1 = 6;
        double num2 = 7;
        double expected = 42;

        double actual = _calculator.Multiply(num1, num2);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Multiply_AnyNumberByZero_ReturnsZero()
    {
        double num1 = 25;
        double num2 = 0;
        double expected = 0;

        double actual = _calculator.Multiply(num1, num2);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Multiply_MaxValueByTwo_ReturnsPositiveInfinity()
    {
        double num1 = double.MaxValue;
        double num2 = 2;
        double expected = double.PositiveInfinity;

        double actual = _calculator.Multiply(num1, num2);

        Assert.That(actual, Is.EqualTo(expected));
    }

    // ---------------------------------------------------------------------------------
    // Divide
    // ---------------------------------------------------------------------------------

    [Test]
    public void Divide_TwoNormalNumbers_ReturnsQuotient()
    {
        double num1 = 10;
        double num2 = 4;
        double expected = 2.5;

        double actual = _calculator.Divide(num1, num2);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Divide_ByZero_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(
            () => _calculator.Divide(10, 0));

        Assert.That(exception.Message, Is.EqualTo(
            "Division by zero: divisor must not be 0"));
    }

    [Test]
    public void Divide_ZeroByNonZero_ReturnsZero()
    {
        double num1 = 0;
        double num2 = 10;
        double expected = 0;

        double actual = _calculator.Divide(num1, num2);

        Assert.That(actual, Is.EqualTo(expected));
    }
}

