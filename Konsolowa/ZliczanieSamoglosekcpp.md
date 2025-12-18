#Kod z egzaminu inf04 Zima 2024 Wizyta u weta
- Aplikacja konsolowa z zliczania samogłosek.
---
```cpp
#include <iostream>
#include <string>

using namespace std; // korzystanie z przestrzeni nazw standardowych

class LiczenieSamoglosek{ //klasa ala pudelko na wszyskie komponenty
    public: //wszystko bedzie dostepne dla glownego programu
    static int zlicz_samogloski(const string& tekst){ //to zwraca liczbe int static - nie musimy budowac fizycznego obiektu klasy by tego uzyc
        if (tekst.empty()) return 0; // jesli wpiszesz pusty tekst - program wypisze 0
        
        const string samogloski = "aąeęiouóyAĄEĘIOUÓY"; // pudelko na samogloski
        int licznik = 0; //licznik samoglosek
        
        for (char litera : tekst){ // petla bierze kazda literke po kolei ze zdania 
            if (samogloski.find(litera) != string::npos){ // czy litera jest na liscie? tak = find sprawdza pozycje/ nie - zwraca specjalny sygnał string::npos (brak pozycji).
            //!= string::npos oznacza więc: "jeśli ZNALEZIONO".
                ++licznik; // dodajemy samogloske do licznika 
            }
        }
        cout<<"Liczba samoglosek: "<<licznik<<endl;
        return licznik;
    }
    
    static string usun_duplikaty(const string& tekst){
        if (tekst.empty()) return ""; //pusty tekst na wejsciu = pusty tekst na wyjsciu
        
        string wynik; //budujemy zdanie po usunieciu duplikatu
        char poprzedni_znak = '\0'; //To nasza "pamięć". Zapisujemy tu ostatnią literę, jaką widzieliśmy. Na start jest tam "nic" (\0).
        
        for (char litera : tekst){ // petla idziemy znak po znaku
            if (litera != poprzedni_znak){ //Czy ta litera jest inna niż ta, która była przed chwilą?
                wynik += litera; //Jeśli jest inna, doklejamy ją do naszego nowego zdania.
                poprzedni_znak = litera; //Zapamiętujemy tę literę, żeby w następnym kroku pętli wiedzieć, co było przed chwilą.
            }
        }
        return wynik;
    }
    
};

int main()
{
    string userInput; // miejsce na nasz tekst
    cout<<"Wprowadz napis: ";
    getline(cin, userInput); //Pobiera całą linijkę tekstu (ze spacjami!).
    
    LiczenieSamoglosek::zlicz_samogloski(userInput); //Uruchamiamy liczenie. Wynik wypisze się sam (bo wewnątrz funkcji jest cout).
    
    string czysty_tekst = LiczenieSamoglosek::usun_duplikaty(userInput); //Uruchamiamy czyszczenie i wynik zapisujemy do czysty_tekst.
    cout<<"Tekst po usunieciu powtorzen: "<<czysty_tekst<<endl;

    return 0;
}
```