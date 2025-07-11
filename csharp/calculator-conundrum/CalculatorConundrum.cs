public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        switch (operation) {
            case "+":
                return $"{operand1} + {operand2} = {SimpleOperation.Addition(operand1, operand2)}";
            case "*":
                return $"{operand1} * {operand2} = {SimpleOperation.Multiplication(operand1, operand2)}";
            case "/":
                return operand2 != 0
                    ? $"{operand1} / {operand2} = {SimpleOperation.Division(operand1, operand2)}"
                    : "Division by zero is not allowed.";
            case "**":
                throw new ArgumentOutOfRangeException();
            case "":
                throw new ArgumentException();
            case null:
                throw new ArgumentNullException();
            default:
                return "";
        } 

    }
}
