/*
// 1. Allow the weighing maching to have a precision
var wm = new WeighingMachine(precision: 3);
Console.WriteLine($"wm.Precision: {wm.Precision}"); // => 3

// 2. Allow the weight to be set on the weighing machine
wm.Weight = 60.5;
Console.WriteLine($"wm.Weight: {wm.Weight}"); // => 60.5

// 3. Ensure that a negative input weight is rejected
// wm.Weight = -10; // Throws an ArgumentOutOfRangeException

// 4. Allow a tare adjustment to be applied to the weighing machine
wm.TareAdjustment = -10.6;
Console.WriteLine($"wm.TareAdjustment: {wm.TareAdjustment}"); // => -10.6

// 5. Ensure that the weighing machine has a default tare adjustment
var wm1 = new WeighingMachine(precision: 3);
Console.WriteLine($"wm1.TareAdjustment: {wm1.TareAdjustment}"); // => 5.0

// 6. Allow the weight to be retrieved
wm.Weight = 60.567;
wm.TareAdjustment = 10;
Console.WriteLine($"wm.DisplayWeight: {wm.DisplayWeight}"); // => "50.567 kg"
*/

class WeighingMachine(int precision)
{
    public int Precision { get; } = precision;

    private double _weight;
    public double Weight
    {
        get => _weight;
        set =>
            _weight =
                value < 0
                    ? throw new ArgumentOutOfRangeException(
                        "Weight",
                        "Weight cannot be less than 0"
                    )
                    : value;
    }

    public double TareAdjustment { get; set; } = 5;

    public string DisplayWeight => $"{(Weight - TareAdjustment).ToString($"F{Precision}")} kg";
}
