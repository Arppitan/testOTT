using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        User user = RegisterUser();
        Subscription selectedSubscription = ChooseSubscription();

        Console.WriteLine("Payment Page");
        Console.WriteLine($"Total Cost: ${selectedSubscription.Cost}");
        Console.WriteLine("Choose Payment Method (Credit Card, PayPal, etc.): ");
        string paymentMethod = Console.ReadLine();

        IPaymentService paymentService = new PaymentService();
        Payment payment = paymentService.ProcessPayment(user, selectedSubscription, paymentMethod);

        Console.WriteLine("Payment Successful!");
        Console.WriteLine($"Payment ID: {payment.PaymentId}");
        Console.WriteLine($"Payment Method: {payment.PaymentMethod}");
        Console.WriteLine($"User ID: {payment.UserId}");
        Console.WriteLine($"Date: {payment.Date}");

        IShowService showService = new ShowService();
        List<Show> allShows = showService.GetAllShows();

        Console.WriteLine("Choose a Show (type 'exit' to stop):");
        bool addToWishlist = true;

        while (addToWishlist)
        {
            Console.WriteLine("Choose a Show (type 'exit' to stop):");

            foreach (var show in allShows)
            {
                Console.WriteLine($"{show.Title}");
            }

            string selectedShowTitle = Console.ReadLine();

            if (selectedShowTitle.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                addToWishlist = false;
                break; // Exit the loop if 'exit' is entered
            }

            Show selectedShow = allShows.FirstOrDefault(show =>
                show.Title.Equals(selectedShowTitle, StringComparison.OrdinalIgnoreCase));

            if (selectedShow != null)
            {
                Console.WriteLine("Show Details:");
                Console.WriteLine($"Title: {selectedShow.Title}");
                Console.WriteLine($"Published Year: {selectedShow.PublishedYear}");
                Console.WriteLine($"Genre: {selectedShow.Genre}");
                Console.WriteLine($"Ratings: {selectedShow.Ratings}");

                Console.WriteLine("Do you want to add this show to your wishlist? (yes/no): ");
                string addToWishlistChoice = Console.ReadLine();

                if (addToWishlistChoice.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    Wishlist wishlist = new Wishlist();
                    wishlist.AddToShowWishlist(selectedShow);
                }
            }
            else
            {
                Console.WriteLine("Invalid show title. Please try again.");
            }


        }

        Console.WriteLine("Application exiting...");
    }

    static User RegisterUser()
    {
        Console.WriteLine("Sign Up Page");
        Console.Write("Enter UserID: ");
        int userId = int.Parse(Console.ReadLine());

        Console.Write("Enter Username: ");
        string username = Console.ReadLine();

        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        Console.Write("Enter Phone Number: ");
        string phoneNumber = Console.ReadLine();

        Console.Write("Enter EmailID: ");
        string emailId = Console.ReadLine();

        return new User { UserId = userId, Username = username, Password = password, PhoneNumber = phoneNumber, EmailId = emailId };
    }

    static Subscription ChooseSubscription()
    {
        ISubscriptionService subscriptionService = new SubscriptionService();
        List<Subscription> availableSubscriptions = subscriptionService.GetAvailableSubscriptions();

        Console.WriteLine("Choose a Subscription:");
        for (int i = 0; i < availableSubscriptions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableSubscriptions[i].Name} - ${availableSubscriptions[i].Cost} ({availableSubscriptions[i].DurationInMonths} months)");
            Console.WriteLine($"   Perks: {availableSubscriptions[i].Perks}");
        }

        int subscriptionChoice = 0;
        bool validChoice = false;

        while (!validChoice)
        {
            Console.Write("Enter the number corresponding to your choice: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out subscriptionChoice) && subscriptionChoice >= 1 && subscriptionChoice <= availableSubscriptions.Count)
            {
                validChoice = true;
            }
            else
            {
                Console.WriteLine($"Invalid choice. Please enter a valid subscription number. You entered: {input}");
            }
        }


        // Return the selected subscription
        return availableSubscriptions[subscriptionChoice - 1];
    }
}

class Wishlist
{
    private List<Show> wishlistShows;

    public Wishlist()
    {
        wishlistShows = new List<Show>();
    }

    public void AddToShowWishlist(Show show)
    {
        wishlistShows.Add(show);
        Console.WriteLine($"{show.Title} added to your wishlist.");
    }
}
