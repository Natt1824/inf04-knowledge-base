
#klasy (definiuje konstruktory , zakres widoczności pól)
##Konstruktory: 
- metoda wywołana w momencie uruchomienia aplikacji. 
Cel - zainicjownaie pól obiektu

##Klasy co to jest?
- Klasa to szablon lub projekt na bazie którego tworzymy konkretne projekt.
- Klasa składa się z:
	- Pola (Atrybuty): To dane, które opisują obiekt (cechy). Przykład dla klasy Samochod: marka, model, kolor, prędkość maksymalna.
	- Metody (Funkcje): To czynności, które obiekt może wykonywać (zachowania). Przykład dla klasy Samochod: jedź(), hamuj(), zatrąb().

## 1. Python konstruktory i klasy: 
```python

class Samochod:
	def __init__(self, marka, model): #Definicja konstruktora __init__
		self.marka = marka # tu wlasnie jest inicjalizacja pol / Przypisanie argumentu 'marka' do pola obiektu 'self.marka'
		self.model = model #Przypisanie argumentu 'model' do pola obiektu 'self.model'

auto = Samochod("Tesla", "S") #Tworzenie instancji klasy (wywołanie konstruktora)
#W pythonie konstruktorem jest metoda __init__. Pierwszym argumentem musi być self, bo reprezentuje tworzony obiekt
```
## Też Python konstruktory i klasy tylko bardziej rozbudowany przykład
```python
class Pracownik: #Definicja nowej klasy.
    def __init__(self, imie, pensja):
        self.imie = imie          # Publiczne: dostępny wszędzie
        self.__pensja = pensja    # Prywatne: ukryte przed dostępem z zewnątrz / Użycie __ powoduje zmianę nazwy pola w pamięci, co uniemożliwia bezpośredni dostęp z zewnątrz.

    def wyswietl_dane(self):
        # Dostęp do pola prywatnego jest możliwy wewnątrz klasy
        print(f"Pracownik: {self.imie}, Zarobki: {self.__pensja}")

    def daj_podwyzke(self, procent):
        if procent > 0:
            self.__pensja *= (1 + procent / 100)

# Użycie:
p1 = Pracownik("Jan", 5000)
p1.daj_podwyzke(10)      # Metoda modyfikuje ukryte pole
p1.wyswietl_dane()       # Metoda odczytuje ukryte pole
# print(p1.__pensja)     # BŁĄD! Python zgłosi AttributeError
```
---

##C++ Konstruktory i klasy
```cpp

class Samochod {
public: // pola będą widoczne wszędzie
    string marka;
    string model;

    // Konstruktor z tzw. listą inicjalizacyjną
    Samochod(string m, string mod) : marka(m), model(mod) {
        //Wnętrze konstruktora (puste, bo dane już przypisano)
    }
};

// Stworzenie obiektu na stosie
Samochod auto("Tesla", "S");
```
##C++ Konstruktory i klasy, bardziej rozbudowany przykład
```cpp

#include <iostream>
#include <string>
using namespace std;

class Pracownik {
private:
    double pensja; // Pole prywatne 

public:
    string imie;   // Pole publiczne

    // Konstruktor z listą inicjalizacyjną (wydajniejszy)
    Pracownik(string i, double p) : imie(i), pensja(p) {}

    // Metoda publiczna (tzw. getter) do odczytu prywatnego pola
    void pokazDane() {
        cout << imie << " zarabia: " << pensja << endl;
    }

    // Metoda publiczna (tzw. setter) z logiką walidacji
    void ustawPensje(double nowaPensja) {
        if (nowaPensja > 0) pensja = nowaPensja;
    }
};

int main() {
    Pracownik p("Anna", 6000);
    p.imie = "Joanna";     // OK - imie jest publiczne
    // p.pensja = 7000;    // BŁĄD KOMPILACJI - pensja jest prywatna
    p.ustawPensje(7500);   // OK - zmieniamy przez oficjalną metodę
    p.pokazDane();
    return 0;
}
```
---

## C# Konstruktory i klasy, 

```csharp


public class Samochod {
    //  Deklaracja pól publicznych
    public string Marka;
    public string Model;

    // Definicja konstruktora
    public Samochod(string marka, string model) {
        // Słowo 'this' wskazuje na pole klasy
        this.Marka = marka; //Słowo this mówi kompilatorowi: "this.Marka to to pole u góry, a marka to wartość z nawiasu".
        this.Model = model;
    }
}

// Użycie słowa kluczowego 'new' do stworzenia obiektu
Samochod auto = new Samochod("Tesla", "S"); //W C# obiekty klas zawsze tworzymy za pomocą słowa new. Powoduje to utworzenie obiektu na tzw. stercie (zarządzanej pamięci).

```

##Zakres widoczności pól

określa, kto ma dostęp do danych (pól) i metod wewnątrz klasy. To kluczowy element enkapsulacji (hermetyzacji), czyli ukrywania wewnętrznych szczegółów działania obiektu przed „światem zewnętrznym”.

###Przykłady: 
- public - Dostęp do tych pól i metod ma każdy. Jeśli pole jest publiczne, można je odczytać i zmienić z dowolnego miejsca w programie.
- private - Dostęp do tych elementów mają tylko metody tej samej klasy. Nawet jeśli stworzysz klasę "pochodną" (np. SportowySamochod na bazie Samochod), nie będzie ona miała dostępu do prywatnych pól rodzica.
- protected - To poziom pośredni. Elementy chronione są niedostępne dla "obcych" klas z zewnątrz, ale są widoczne dla klas, które dziedziczą po danej klasie.

---
## Przykład cpp
```cpp
class Przyklad {
public:
    int publiczne;    // Widoczne wszędzie
protected:
    int chronione;    // Widoczne w tej klasie i klasach pochodnych
private:
    int prywatne;     // Widoczne TYLKO w tej klasie
};
```
## Przykład python
```python
class Pracownik:
    def __init__(self):
        self.imie = "Jan"          # Publiczne
        self._pensja = 5000.0      # Protected (konwencja: "nie ruszaj, chyba że dziedziczysz")
        self.__haslo = "1234"      # Private (Python zmieni nazwę tego pola w pamięci)

# Test w Pythonie:
p = Pracownik()
print(p.imie)    # Działa
print(p._pensja) # Działa (ale IDE pokaże ostrzeżenie, że to pole chronione)
# print(p.__haslo) # BŁĄD (AttributeError) - Python ukrył to pole
```
---

## Przykład C#

```csharp

public class Pracownik {
    public string imie;          // Dostępne dla każdego
    protected double pensja;     // Dostępne dla Pracownik i np. Kierownik (dziedziczenie)
    private string haslo;        // Tylko wewnątrz klasy Pracownik

    public void UstawHaslo(string h) {
        this.haslo = h; // Metoda publiczna ma dostęp do pola prywatnego
    }
}
```




