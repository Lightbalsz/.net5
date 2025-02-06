using System;
using System.Collections.Generic;
using System.Linq;

public enum VehicleType { Mobil, Motor }

public class Vehicle
{
    public string LicensePlate { get; set; }
    public VehicleType Type { get; set; }
    public string Color { get; set; }

    public Vehicle(string licensePlate, VehicleType type, string color)
    {
        LicensePlate = licensePlate;
        Type = type;
        Color = color;
    }
}

public class ParkingLot
{
    private int TotalLots;
    private Dictionary<int, Vehicle> occupiedLots = new();

    public ParkingLot(int totalLots)
    {
        TotalLots = totalLots;
        Console.WriteLine($"Created a parking lot with {totalLots} slots");
    }

    public void Park(Vehicle vehicle)
    {
        if (occupiedLots.Count >= TotalLots)
        {
            Console.WriteLine("Sorry, parking lot is full");
            return;
        }

        int lotNumber = Enumerable.Range(1, TotalLots).Except(occupiedLots.Keys).First();
        occupiedLots[lotNumber] = vehicle;
        Console.WriteLine($"Allocated slot number: {lotNumber}");
    }

    public void Leave(int slotNumber)
    {
        if (occupiedLots.ContainsKey(slotNumber))
        {
            occupiedLots.Remove(slotNumber);
            Console.WriteLine($"Slot number {slotNumber} is free");
        }
        else
        {
            Console.WriteLine("Slot not found");
        }
    }

    public void Status()
    {
        Console.WriteLine("Slot\tNo.\tType\tRegistration No\tColour");
        foreach (var slot in occupiedLots)
        {
            Console.WriteLine($"{slot.Key}\t{slot.Value.LicensePlate}\t{slot.Value.Type}\t{slot.Value.Color}");
        }
    }

    public void TypeOfVehicles(VehicleType type)
    {
        Console.WriteLine(occupiedLots.Values.Count(v => v.Type == type));
    }

   public void RegistrationNumbersForOddPlate()
{
    var oddPlates = occupiedLots.Values
        .Where(v => int.TryParse(new string(v.LicensePlate.Where(char.IsDigit).Last().ToString()), out int lastDigit) && lastDigit % 2 == 1)
        .Select(v => v.LicensePlate);

    Console.WriteLine(oddPlates.Any() ? string.Join(", ", oddPlates) : "No vehicles with odd plate numbers found.");
}

public void RegistrationNumbersForEvenPlate()
{
    var evenPlates = occupiedLots.Values
        .Where(v => int.TryParse(new string(v.LicensePlate.Where(char.IsDigit).Last().ToString()), out int lastDigit) && lastDigit % 2 == 0)
        .Select(v => v.LicensePlate);

    Console.WriteLine(evenPlates.Any() ? string.Join(", ", evenPlates) : "No vehicles with even plate numbers found.");
}

    public void RegistrationNumbersForColor(string color)
    {
        Console.WriteLine(string.Join(", ", occupiedLots.Values.Where(v => v.Color.Equals(color, StringComparison.OrdinalIgnoreCase)).Select(v => v.LicensePlate)));
    }

    public void SlotNumbersForColor(string color)
    {
        Console.WriteLine(string.Join(", ", occupiedLots.Where(s => s.Value.Color.Equals(color, StringComparison.OrdinalIgnoreCase)).Select(s => s.Key)));
    }

    public void SlotNumberForRegistration(string licensePlate)
    {
        var slot = occupiedLots.FirstOrDefault(s => s.Value.LicensePlate == licensePlate).Key;
        Console.WriteLine(slot > 0 ? slot.ToString() : "Not found");
    }
}

public class Program
{
    public static void Main()
    {
        ParkingLot? parkingLot = null;
        while (true)
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) continue;
            if (input == "exit") break;
            var args = input.Split(' ');

            switch (args[0])
            {
                case "create_parking_lot":
                    parkingLot = new ParkingLot(int.Parse(args[1]));
                    break;
                case "park":
                    if (parkingLot != null)
                        parkingLot.Park(new Vehicle(args[1], Enum.Parse<VehicleType>(args[3], true), args[2]));
                    break;
                case "leave":
                    if (parkingLot != null)
                        parkingLot.Leave(int.Parse(args[1]));
                    break;
                case "status":
                    parkingLot?.Status();
                    break;
                case "type_of_vehicles":
                    if (parkingLot != null)
                        parkingLot.TypeOfVehicles(Enum.Parse<VehicleType>(args[1], true));
                    break;
                case "registration_numbers_for_vehicles_with_ood_plate":
                    parkingLot?.RegistrationNumbersForOddPlate();
                    break;
                case "registration_numbers_for_vehicles_with_event_plate":
                    parkingLot?.RegistrationNumbersForEvenPlate();
                    break;
                case "registration_numbers_for_vehicles_with_colour":
                    parkingLot?.RegistrationNumbersForColor(args[1]);
                    break;
                case "slot_numbers_for_vehicles_with_colour":
                    parkingLot?.SlotNumbersForColor(args[1]);
                    break;
                case "slot_number_for_registration_number":
                    parkingLot?.SlotNumberForRegistration(args[1]);
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }
    }
}
