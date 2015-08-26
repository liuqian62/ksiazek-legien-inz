# Założenia projektu #

## DICOM ##

Dane medyczne aplikacja będzie przyjmować w postaci serii obrazów w standardzie DICOM(Digital Imaging and Communications in Medicine), okreslającym sposób przedstawiania wyników badań medycznych w poctaci cyfrowej oraz metody ich wymiany. Norma jest ogólnie przyjęta i stosowana między innymi w przetwarzaniu obrazów tomografii komputerowej, tomografii rezonansu magnetycznego, pozytonowej tomografii emisyjnej, cyfrowej angiografii subtrakcyjnej, cyfrowej radiografii konwencjonalnej, radiografii cyfrowej. W projekcie skupiono się na obsłudze obrazów pochodzących z tomografii.

Pierwsza wersja standardu powstała w roku 1985. Plik w formacie DICOM zawiera dane pacjenta, informacje o badaniu jakie wykonano oraz warunkach jego przeprowadzenia, oraz serie danych. Mogą one zawierać obrazy, nieprzetworzone dane lub np. notatki.

W badanych w projekcje zagadnieniach rozważamy obrazy DICOM, których właściwe dane to wynik tomografii, przedstawiony w postaci macierzy punktów opisanych z użyciem modelu HSV. Interpretacją wartości danego punktu jest jego gęstość.


## Wizualizacja wolumetryczna ##

Odpowiednio _gęste_ wykonanie zdjęć danego obszaru ciała lub tkanki, ze stałą odległością między zdjęciami rzędu 1-5 mm, pozwala na zebranie wystarczającej ilości danych do przedstawienia badanego obiektu w postaci trójwymiarowego obrazu.

Wizualizacja objętościowa jest techniką przedstawiającą na płaszczyźnie dwuwymiarowej uproszczoną funkcję powierzchni trójwymiarowej, stworzoną poprzez analizę obrazów 2-D. Cechą charakterystyczną jest użycie w obrazie półprzeźroczystości, który daje wgląd w wewnętrzne obszary obiektów, co istotne jest zwłaszcza w diagnostyce medycznej.

##  ##