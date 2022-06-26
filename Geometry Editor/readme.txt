*** KLAWISZOLOGIA ***
-aby dodać wielokąt, należy nacisnąć "Add polygon", kliknąć LPM aby pojawił się wierzchołek i kliknąć PPM aby zakończyć dodawanie,
-aby dodać okrąg, należy nacisnąć "Add circle", kliknąć LPM w pożądanym miejscu środka okręgu, następnie kliknąć LPM gdzieś indziej aby zatwierdzić promień,
-aby przemieścić wierzchołek/wielokąt okrąg, należy być w trybie "Move", przytrzymać LPM na danym obiekcie, przemieścić mysz i puścić LPM,
-aby usunąć wierzchołek/wielokąt/okrąg, należy być w trybie "Move", przytrzymać LPM na danym obiekcie i nacisnąć DELETE,
-aby zmienić promień okręgu, należy być w trybie "Move", przytrzymać LPM na granicy okręgu, przesunąć mysz i puścić,
-aby dodać relację, należy nacisnąć odpowiedni przycisk, wybrać pierwszą krawędź pojedynczym kliknięciem LPM, a następnie wybrać drugą krawędź (lub okrąg) w ten sam sposób
(aby dodać styczność, najpierw trzeba wybrać krawędź, potem okrąg),
-aby ograniczyć długość krawędzi, należy nacisnąć "Lock edge length", wybrać krawędź, wybrać długość w menu które się pojawiło i nacisnąć OK,
-aby ograniczyć promień okręgu - analogicznie jak wyżej,
-aby odblokować długość/promień - analogicznie,
-aby złamać krawędź, należy podwójnie kliknąć na krawędź w pożądanym miejscu.

Po wszystkich akcjach program automatycznie przechodzi w tryb "Move". Część kolorów można personalizować.

Oznaczenia relacji: P-parallelism, L-same length, T-tangency.

*** OPIS MODELU RELACJI ***
Wszystkie klasy relacji dziedziczą z klasy Relation.
Wierzchołek przesuwam korzystając z metody Translate klasy Vertex. Patrzy ona, czy któraś z krawędzi (lub obie) wychodzących z wierzchołka należy do jakiejś relacji.
Jeśli tak, przesuwa drugą krawędź z tej relacji (lub okrąg) tak, aby została ona zachowana.
Konkretnie:
-równoległość - przesuwa jeden z wierzchołków tak, aby kąt nachylenia się zgadzał i jednocześnie nie zmieniać kąta nachylenia sąsiedniej krawędzi, w ten sposób
łatwo zachować równoległość np. równoległoboku bez rozpatrywania szczególnych przypadków,
-równa długość - przesuwa jeden z wierzchołków wzdłuż prostej na której leży dana krawędź, tak aby długość była taka sama jak innej krawędzi relacji,
-styczność - zależnie od przypadku:
--zmienia promień okręgu, tak aby był styczny do prostej (brak ograniczeń okręgu lub przypięty środek, ruch krawędzi),
--zmienia środek okręgu bez zmiany promienia, tak aby był styczny do prostej (ustalony promień, ruch krawędzi),
--przesuwa krawędź styczną o taką samą deltę, jak przesunął się wyliczony punkt styczności (ustalony promień, ruch okręgu/przypięty środek, zmiana promienia),
--nie przesuwa nic (ustalony promień, przypięty środek, ruch krawędzi).
