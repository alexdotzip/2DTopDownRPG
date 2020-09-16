using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class NavigationManager
{
    public static Dictionary<string, Route> RouteInformation = new Dictionary<string, Route>() {
        {"Overworld", new Route { RouteDescription  = "Map of the Sticks", CanTravel = true } 
        },
        {"Castle", new Route { RouteDescription  = "Almerry Keep", CanTravel = true }
        },
        {"Town", new Route { RouteDescription  = "The Sticks", CanTravel = true }
        },
        {"Room", new Route { RouteDescription  = "Home of the High Councilor, a great friend to the King of the Sticks and day watcher of Princess Ailsa.", CanTravel = false }
        },
        {"Blacksmith", new Route { RouteDescription  = "Weapons and Armor Upgrades", CanTravel = false}
        },
        {"Market", new Route { RouteDescription  = "Shop for items", CanTravel = false }
        },
    };


    public static string GetRouteInfo(string destination)
    {
        return RouteInformation.ContainsKey(destination) ? RouteInformation[destination].RouteDescription : null;
    }

    public static bool CanNavigate(string destination)
    {
        return RouteInformation.ContainsKey(destination) ? RouteInformation[destination].CanTravel : false;
    }

    public static void NavigateTo(string destination)
    {
        //for future
        SceneManager.LoadScene(destination);
    }


    public struct Route
    {
        public string RouteDescription;
        public bool CanTravel;
    }
}
