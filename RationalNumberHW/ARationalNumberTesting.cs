using RationalNumberApp;
using NUnit.Framework;

namespace RationalNumberHW;

public class ARationalNumber
{

    //No-Argument Constructor
    [Test]
    public void ShouldInitializedNumberAndDenominatorWhenConstrucedWithNoArgument()
    {
        RationalNumber sut = new RationalNumber();
        Assert.That(sut.Numerator,Is.EqualTo(0));
        Assert.That(sut.Denominator, Is.EqualTo(1));

    }

    //ToString()
    [Test]
    public void CanReportItsValueAsAString()
    {
        // Arrange
        RationalNumber sut = new RationalNumber(1, 2);

        // Act
        string result = sut.ToString();

        // Assert
        Assert.That(result, Is.EqualTo("1/2"));
    }

    //Two-argument Constructor
    [Test]
    public void ShouldThrowArgumentExceptionWhenDenominatorIsZero()
    {
        
        Assert.Throws<ArgumentException>(() => new RationalNumber(1, 0));
    }

    //Test Cases: EP from Precondition
    [Test]
    public void ShouldInitializeNumeratorAndDenominatorWhenConstructedWithRegularFraction()
    {
        // Arrange
        var sut = new RationalNumber(2, 5);

        // Act & Assert
        Assert.That(sut.Numerator, Is.EqualTo(2));
        Assert.That(sut.Denominator, Is.EqualTo(5));
    }

    [Test]
    public void ShouldInitializeNumeratorAndDenominatorWhenConstructedWithReducedFraction()
    {
        // Arrange
        var sut = new RationalNumber(4, 10);

        // Assert
        Assert.That(sut.Numerator, Is.EqualTo(2));
        Assert.That(sut.Denominator, Is.EqualTo(5));
    }

    [Test]
    public void ShouldThrowArgumentExceptionWhenConstructedWithZeroDenominator()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new RationalNumber(2, 0));
    }

    [Test]
    public void ShouldThrowArgumentExceptionWhenConstructedWithZeroNumeratorAndDenominator()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new RationalNumber(0, 0));
    }

    //Additional Partitions
    [Test]
    [TestCase(3, 6, 1, 2, Description = "Regular fraction")] 
    [TestCase(6, 3, 2, 1, Description = "Irregular fraction")]
    [TestCase(12350, 42350, 247, 847, Description = "Large regular fraction")]
    public void ShouldConstructorReduceFraction(int inputNumerator, int inputDenominator, int expectedNumerator, int expectedDenominator)
    {
        // Arrange & Act
        var sut = new RationalNumber(inputNumerator, inputDenominator);

        // Assert
        Assert.That(sut.Numerator, Is.EqualTo(expectedNumerator)); 
        Assert.That(sut.Denominator, Is.EqualTo(expectedDenominator)); 
    } 

    //Multiply
    [Test]
    [Description("Multiplication of two regular fractions")]
    public void ShouldReturnCorrectResultWhenMultiplyTwoRegularFractions()
    {
        // Arrange
        var lhs = new RationalNumber(1, 2);
        var rhs = new RationalNumber(1, 3);

        // Act
        var sut = lhs.Multiply(rhs); // 1/2 * 1/3 = 1/6

        // Assert
        Assert.That(sut.Numerator, Is.EqualTo(1));
        Assert.That(sut.Denominator, Is.EqualTo(6));
    }
    [Test]
    [Description("Multiplication of two irregular fractions")]
    public void Multiply_TwoIrregularFractions_ShouldReturnCorrectResult()
    {
        // Arrange
        var lhs = new RationalNumber(5, 3);
        var rhs = new RationalNumber(2, 3);

        // Act
        var sut = lhs.Multiply(rhs); // 5/3 * 2/3 = 10/9

        // Assert
        Assert.That(sut.Numerator, Is.EqualTo(10));
        Assert.That(sut.Denominator, Is.EqualTo(9));
    }

    [Test]
    [Description("Multiplying with a whole number")]
    public void ShouldReturnCorrectResultWhenMultiplyWithWholeNumber()
    {
        // Arrange
        var lhs = new RationalNumber(1, 2);
        var rhs = new RationalNumber(2, 1);

        // Act
        var sut = lhs.Multiply(rhs); // 1/2 * 2/1 = 2/2

        // Assert
        Assert.That(sut.Numerator, Is.EqualTo(1));
        Assert.That(sut.Denominator, Is.EqualTo(1));
    }

    [Test]
    [Description("Multiplying resulting in a whole number")]
    public void ShouldReturnCorrectResultWhenMultiplyResultingInWholeNumber()
    {
        // Arrange
        var lhs = new RationalNumber(1, 2);
        var rhs = new RationalNumber(6, 1);

        // Act
        var sut = lhs.Multiply(rhs); // 1/2 * 6/1 = 6/2 = 3/1

        // Assert
        Assert.That(sut.Numerator, Is.EqualTo(3));
        Assert.That(sut.Denominator, Is.EqualTo(1));
    }

    //Divide
    [Test]
    [Description("Division of two regular fractions")]
    public void ShouldReturnCorrectResultWhenDivideTwoRegularFractions()
    {
        // Arrange
        var lhs = new RationalNumber(1, 2);
        var rhs = new RationalNumber(1, 3);

        // Act
        var sut = lhs.Divide(rhs);  // 1/2 / 1/3 = 3/2

        // Assert
        Assert.That(sut.Numerator, Is.EqualTo(3));
        Assert.That(sut.Denominator, Is.EqualTo(2));
    }

    [Test]
    [Description("Dividing by a whole number")]
    public void ShouldReturnCorrectResultWhenDivideByWholeNumber()
    {
        // Arrange
        var lhs = new RationalNumber(1, 2);
        var rhs = new RationalNumber(1, 1);

        // Act
        var sut = lhs.Divide(rhs); // 1/2 / 1/1 = 1/2

        // Assert
        Assert.That(sut.Numerator, Is.EqualTo(1));
        Assert.That(sut.Denominator, Is.EqualTo(2));
    }

    [Test]
    [Description("Dividing resulting in a whole number")]
    public void ShouldReturnCorrectResultWhenDivideResultingInWholeNumber()
    {
        // Arrange
        var lhs = new RationalNumber(3, 1);
        var rhs = new RationalNumber(3, 2);

        // Act
        var sut = lhs.Divide(rhs); // 3/1 / 3/2 = 2/1

        // Assert
        Assert.That(sut.Numerator, Is.EqualTo(2));
        Assert.That(sut.Denominator, Is.EqualTo(1));
    }

    //Add
    [Test]
    [Description("Addition of two regular fractions")]
    public void ShouldReturnCorrectResultWhenAddTwoRegularFractions()
    {
        // Arrange
        var lhs = new RationalNumber(1, 2);
        var rhs = new RationalNumber(1, 3);

        // Act
        var sut = lhs.Add(rhs); // 1/2 + 1/3 = 5/6

        // Assert
        Assert.That(sut.Numerator, Is.EqualTo(5));
        Assert.That(sut.Denominator, Is.EqualTo(6));
    }

    [Test]
    [Description("Adding with a whole number")]
    public void ShouldReturnCorrectResultWhenAddWithWholeNumber()
    {
        // Arrange
        var lhs = new RationalNumber(1, 2);
        var rhs = new RationalNumber(1, 1);

        // Act
        var sut = lhs.Add(rhs); // 1/2 + 1/1 = 3/2

        // Assert
        Assert.That(sut.Numerator, Is.EqualTo(3));
        Assert.That(sut.Denominator, Is.EqualTo(2));
    }

    [Test]
    [Description("Adding resulting in a whole number")]
    public void ShouldReturnCorrectResultWhenAddResultingInWholeNumber()
    {
        // Arrange
        var lhs = new RationalNumber(1, 2);
        var rhs = new RationalNumber(1, 2);

        // Act
        var sut = lhs.Add(rhs); // 1/2 + 1/2 = 1/1

        // Assert
        Assert.That(sut.Numerator, Is.EqualTo(1));
        Assert.That(sut.Denominator, Is.EqualTo(1));
    }

    //Subtract
    [Test]
    [Description("Subtraction of two regular fractions")]
    public void ShouldReturnCorrectResultWhenSubtractTwoRegularFractions()
    {
        // Arrange
        var lhs = new RationalNumber(1, 2);
        var rhs = new RationalNumber(1, 3);

        // Act
        var sut = lhs.Subtract(rhs); // 1/2 - 1/3 = 1/6

        // Assert
        Assert.That(sut.Numerator, Is.EqualTo(1));
        Assert.That(sut.Denominator, Is.EqualTo(6));
    }

    [Test]
    [Description("Subtracting with a whole number")]
    public void ShouldReturnCorrectResultWhenSubtractWithWholeNumber()
    {
        // Arrange
        var lhs = new RationalNumber(1, 1);
        var rhs = new RationalNumber(1, 2);

        // Act
        var sut = lhs.Subtract(rhs); // 2/2 - 1/2 = 1/2

        // Assert
        Assert.That(sut.Numerator, Is.EqualTo(1));
        Assert.That(sut.Denominator, Is.EqualTo(2));
    }

    [Test]
    [Description("Subtracting resulting in a whole number")]
    public void ShouldReturnCorrectResultWhenSubtractResultingInWholeNumber()
    {
        // Arrange
        var lhs = new RationalNumber(3, 2);
        var rhs = new RationalNumber(1, 2);

        // Act
        var sut = lhs.Subtract(rhs); // 3/2 - 1/2 = 1/1

        // Assert
        Assert.That(sut.Numerator, Is.EqualTo(1));
        Assert.That(sut.Denominator, Is.EqualTo(1));
    }

    //decimal ToDecimal()
    [Test]
    [Description("Convert regular fraction to decimal")]
    public void ShouldReturnCorrectDecimalWhenDecimalRegularFraction()
    {
        // Arrange
        var fraction = new RationalNumber(1, 2);

        // Act
        var sut = fraction.ToDecimal(); // 1/2 = 0.5

        // Assert
        Assert.That(sut, Is.EqualTo(0.5m));
    }

    [Test]
    [Description("Convert whole number to decimal")]
    public void ShouldReturnCorrectDecimalToDecimalWholeNumber()
    {
        // Arrange
        var fraction = new RationalNumber(5, 1);

        // Act
        var sut = fraction.ToDecimal(); // 5/1 = 5.0

        // Assert
        Assert.That(sut, Is.EqualTo(5.0m));
    }

    [Test]
    [Description("Convert fraction resulting in recurring decimal(Round to 4 decimal)")]
    public void ShouldReturnCorrectDecimalToDecimalRecurringDecimalRoundTo4Decimals()
    {
        // Arrange
        var fraction = new RationalNumber(1, 3);

        // Act (4 decimals)
        var sut = fraction.ToDecimal();
        Assert.That(sut, Is.EqualTo(0.3333m));
    }
}