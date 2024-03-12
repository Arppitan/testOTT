using System.Collections.Generic;
using System;

class WishList
{
    private List<Show> wishlist = new List<Show>();

    public void AddToShowWishlist(Show show)
    {
        wishlist.Add(show);
        Console.WriteLine($"{show.Title} added to wishlist.");
    }
}
