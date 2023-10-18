using System;


namespace RationalNumberApp;

public class RationalNumber 
{
    private int numerator;
    private int denominator;
    
    //1 Get properties for the numerator
    public int Numerator
    {
        get { return numerator; }
    }
    // 2 Get properties for the denominator
    public int Denominator
    {
        get { return denominator; }
    }
    // 3 No-argument constructor - initializes numerator to 0 and denominator to 1
    public RationalNumber()
    {
        numerator = 0;
        denominator = 1;
    }
    // 4 Two-argument constructor - initializes the numerator and the denominator.
    // If the denominator is initialized to 0 then an ArgumentException is thrown
    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        int gcd = GCD(numerator, denominator);
        this.numerator = numerator / gcd;
        this.denominator = denominator / gcd;

        if (this.denominator < 0)
        {
            this.numerator = -this.numerator;
            this.denominator = -this.denominator;
        }
    }
    // 5 RationalNumber Add(RationalNumber rhs)

    public RationalNumber Add(RationalNumber rhs)
    {
        int newNumerator = (numerator * rhs.denominator) + (rhs.numerator * denominator);
        int newDenominator = denominator * rhs.denominator;
        return new RationalNumber(newNumerator, newDenominator);
    }

    // 6. Subtract method
    public RationalNumber Subtract(RationalNumber rhs)
    {
        int newNumerator = this.numerator * rhs.denominator - this.denominator * rhs.numerator;
        int newDenominator = this.denominator * rhs.denominator;

        return new RationalNumber(newNumerator, newDenominator);
    }

    // 7. Multiply method
    public RationalNumber Multiply(RationalNumber rhs)
    {
        int newNumerator = this.numerator * rhs.numerator;
        int newDenominator = this.denominator * rhs.denominator;

        return new RationalNumber(newNumerator, newDenominator);
    }

    // 8. Divide method
    public RationalNumber Divide(RationalNumber rhs)
    {
        if (rhs.numerator == 0)
            throw new ArgumentException("Cannot divide by a fraction with a numerator of zero.");

        int newNumerator = this.numerator * rhs.denominator;
        int newDenominator = this.denominator * rhs.numerator;

        return new RationalNumber(newNumerator, newDenominator);
    }

    // 9. ToString method
    public override string ToString()
    {
        return $"{numerator}/{denominator}";
    }

    // 10. ToDecimal method
    public decimal ToDecimal()
    {
        //return round to 4 decimal places. simplify the code
        return decimal.Round((decimal)numerator / denominator, 4);

    }

    private int GCD(int a, int b)
    {
        if (a == 0)
            return b;

        return GCD(b % a, a);
    }

}
