using System;

class VirtualPet
{
    // Properties of pet information
    public string PetType { get; }
    public string Name { get; }
    // Pet's status tracking system
    public int Hunger { get; private set; } = 5;
    public int Happiness { get; private set; } = 5;
    public int Health { get; private set; } = 5;

    // Assigning Pet with name and type 
    public VirtualPet(string petType, string name)
    {
        PetType = petType;
        Name = name;
    }
    // Assigning numbers to the pet functionings
    public void DisplayAs()
    {
        Console.WriteLine("Choose an action:");
        Console.WriteLine("1. Feed");
        Console.WriteLine("2. Play");
        Console.WriteLine("3. Rest");
        Console.WriteLine("4. Quit");
    }
    // Method to display current status
    public void DisplayStatus()
    {
        Console.WriteLine($"{Name} ({PetType}) - Hunger: {Hunger}/10, Happiness: {Happiness}/10, Health: {Health}/10");
    }
    // Method to feed the pet
    public void Feed()
    {
        Hunger = Math.Max(0, Hunger - 2);
        Health = Math.Min(10, Health + 1);
        Console.WriteLine($"{Name} has been fed. Hunger decreased, and health increased.");
    }
    // Method to play with the pet 
    public void Play()
    {
        Happiness = Math.Min(10, Happiness + 2);
        Hunger = Math.Min(10, Hunger + 1);
        Console.WriteLine($"{Name} had fun playing. Happiness increased, but hunger slightly increased.");
    }
    // Method to let the pet rest
    public void Rest()
    {
        Health = Math.Min(10, Health + 2);
        Happiness = Math.Max(0, Happiness - 1);
        Console.WriteLine($"{Name} is resting. Health increased, but happiness slightly decreased.");
    }
    // Simulating time pass mechanism
    public void TimePasses()
    {
        Hunger = Math.Min(10, Hunger + 1);
        Happiness = Math.Max(0, Happiness - 1);

        // To check if pet is getting hungry and update it
        if (Hunger <= 3)
        {
            Health = Math.Max(0, Health - 1);
            Console.WriteLine($"{Name} is getting hungry. Health will decrease if not fed.");
        }

        // Notify if pet is feeling sad. Play with it
        if (Happiness <= 3)
        {
            Console.WriteLine($"{Name} is feeling sad. Play with your pet to increase happiness.");
        }

        // Notify if pet's health is getting low
        if (Health <= 3)
        {
            Console.WriteLine($"{Name}'s health is getting low. Take care of your pet!");
        }
    }


    public void CheckStatus()
    {
        // Display warning if pet is very hungry
        if (Hunger >= 8)
        {
            Console.WriteLine($"Warning: {Name} is very hungry!");
        }
        // Display warning if pet is full
        else if (Hunger <= 2)
        {
            Console.WriteLine($"Warning: {Name} is full.");
        }
        // Display warning if the pet is  very unhappy
        if (Happiness <= 2)
        {
            Console.WriteLine($"Warning: {Name} is very unhappy!");
        }
        // Display warning if the pet's health is critical
        if (Health <= 2)
        {
            Console.WriteLine($"Warning: {Name}'s health is critical. Take action!");
        }
    }
}

class Program
{
    static void Main()
    {
        // Welcome message and pet initialization
        Console.WriteLine("Welcome to the Virtual Pet Care Simulator!");

        Console.Write("Choose a pet type:\n");
        Console.WriteLine("1. Cat");
        Console.WriteLine("2. Dog");
        Console.WriteLine("3. Rabbit");
        string petType = Console.ReadLine();

        Console.Write("Give your pet a name: ");
        string petName = Console.ReadLine();

        VirtualPet pet = new VirtualPet(petType, petName);

        Console.WriteLine($"Welcome, {pet.Name} the {pet.PetType}!");

        // Main loop for interacting with the pet
        while (true)
        {
            // Display pet status
            pet.DisplayStatus();
            pet.DisplayAs();

            Console.Write("Enter the number to your choice: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }
            // Command to perform the chosen action
            switch (choice)
            {
                case 1:
                    pet.Feed();
                    break;
                case 2:
                    pet.Play();
                    break;
                case 3:
                    pet.Rest();
                    break;
                case 4:
                    Console.WriteLine("Thank you for playing!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please choose a number from the options.");
                    break;
            }
            // Simulating time passing and pet's status
            pet.TimePasses();
            pet.CheckStatus();

        }
    }
}
