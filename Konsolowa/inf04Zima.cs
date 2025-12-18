using System;
using System.Text;
using System.Linq;

//egzmain inf 04. Zima - Wizyta u weterynarza / zliczanie samoglosek
public class LiczenieSamoglosek // tworzymy klase w ktorej jest wszystko
{
    public static int zlicz_samogloski(string tekst)
    {
        if (string.IsNullOrEmpty(tekst)) return 0; //Sprawdzenie czy string nie jest pusty a jak jest pusty to konczy program 
        
        string samogloski = "aąeęiouóyAĄEĘIOUÓY"; //tu definiujemy listę znaków czyli przypisujemy do samogłosek - samogloski
        
        int count = tekst.Count(ch => samogloski.Contains(ch)); // przechodzi przez wszystkie elementy i zlicza je
        
        Console.WriteLine($"Liczba samoglosek: {count}"); // Liczba samoglosek 
        return count;
    }
    
    public static string usun_duplikaty(string tekst)
    {
        if (string.IsNullOrEmpty(tekst)) return "";
        
        StringBuilder result = new StringBuilder(); // to taki pojemnik ktory rezerwuje miejsce w pamieci na zapas wiecej elementow.
        
        char lastChar = '\0'; // To "krótkotrwała pamięć". Zapisujemy tu literkę, którą widzieliśmy przed chwilą. Na start dajemy tam pusty znak.
        
        foreach (char ch in tekst)
        {
            if (ch != lastChar) //czy litera jest inna od poprzedniej?
            {
                result.Append(ch); // jesli jest inna to wrzuc ja do pojemnika(StringBuilder)
                lastChar = ch; // ta litera staje sie poprzednia dla nastepnego kroku
            }
        }
        return result.ToString();
    }
}

class Program
{
    static void Main() //glowny program
    {
        Console.Write("Wprowadz napis: ");
        string userInput = Console.ReadLine() ?? ""; //Console.ReadLine(): Program zatrzymuje się i czeka, aż coś wpiszesz a pytajniki - jesli komputer nie odczyta niczego to program podstawi pusty tekst
        
        LiczenieSamoglosek.zlicz_samogloski(userInput);
        string wynik = LiczenieSamoglosek.usun_duplikaty(userInput);
        
        Console.WriteLine($"Napis po usunieciu duplikatow: {wynik} ");// to jest proste do wydedukowania :>
    }
}