
# egzmain inf 04. Zima - Wizyta u weterynarza / zliczanie samoglosek
def zlicz_samogloski(tekt): # robimy funkcję zlicz_samogloski
    samogloski = "aąeęiouóyAĄEĘIOUÓY" # tu definiujemy listę znaków czyli przypisujemy do samogłosek - samogloski
    cout = sum(1 for ch in tekst if ch in samogloski) # to przechodzi przez tekst i sprawdza która litera to samogłoska. Jeśli tak to daj 1. Potem zlicza te jedynki
    print(f"Liczba samoglosek: {count}") # tu się pokazują zliczone jedynki
    return count 
    
def usun_duplikaty(tekst):
    if not tekst: #sprawdzanie czy napis nie jest pusty
        return ""
    
    result = [tekst[0]] #tworzymy listę od razu dodając tam pierwszą litere
    for i in range(1, len(tekst)): #Pętla, która idzie po indeksach (numerach) liter, zaczynając od drugiej (numer 1), aż do końca.
        if tekst[i] != tekst[i-1]: #porownujemy obecna litere z ta ktora stoi przed nia...
            result.append(tekst[i])# i dorzucamy ja do listy
            
    return "".join(result) #wszystko na koncu sklejamy w jeden napis
    
    user_input = input("Wprowadz napis:")
    zlicz_samogloski(user_input)
    wynik = usun_duplikaty(user_input)
    print(f"Napis po usunieciu powtorzenia: {wynik}")
    #tej czesci nie trzeba tlumaczyc bo to proste i na chlopski rozum zrozumiesz