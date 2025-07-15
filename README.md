# 🎓 StudentManager Console App

## 🇵🇱 Wersja polska
## 🇬🇧 English version below 

--------------------🇵🇱---------------

### 📌 Opis

StudentManager to aplikacja konsolowa w języku C#, która umożliwia zarządzanie listą studentów. Program wspiera operacje dodawania, usuwania, wyszukiwania i sortowania studentów. Dane są przechowywane w pliku JSON z obsługą dziedziczenia klas.

### ✨ Funkcjonalności

- ➕ Dodawanie studentów (dziennych i zaocznych)
- ➖ Usuwanie studentów po imieniu, nazwisku lub indeksie
- 🔍 Wyszukiwanie studentów
- 🔃 Sortowanie wg:
  - Imienia
  - Nazwiska
  - Wieku
  - Kierunku
  - Trybu studiów (dzienny/zaoczny)
- 📊 Statystyki:
  - Średni wiek studentów
  - Najstarszy i najmłodszy student
  - Liczba studentów wg kierunku
  - Liczba studentów wg typu
- 💾 Zapis/odczyt danych do/z pliku JSON z obsługą dziedziczenia (System.Text.Json)

### 🛠️ Technologie

- C# (.NET 6+)
- System.Text.Json
- Programowanie obiektowe (dziedziczenie, interfejsy)
- LINQ

### ▶️ Jak uruchomić

```bash
git clone https://github.com/Szymon-programming/StudentManager-ConsoleApp.git
cd StudentManager-ConsoleApp
dotnet run

------------------🇬🇧--------------------

## 📌 Description

StudentManager is a C# console application for managing a list of students. It allows adding, removing, searching, and sorting students. Data is stored in a JSON file with support for class inheritance (daily and part-time students).

## ✨ Features

- ➕ Add students (daily or part-time)
- ➖ Remove students by name, surname, or index
- 🔍 Search for students
- 🔃 Sort students by:
  - Name
  - Surname
  - Age
  - Field of study
  - Type (daily/part-time)
- 📊 Statistics:
  - Average age of students
  - Oldest and youngest student
  - Number of students by field of study
  - Number of students by type
- 💾 JSON data persistence using `System.Text.Json` with inheritance handling

## 🛠️ Technologies

- C# (.NET 6+)
- Object-Oriented Programming (inheritance, interfaces)
- `System.Text.Json`
- LINQ

## ▶️ How to Run

```bash
git clone https://github.com/Szymon-programming/StudentManager-ConsoleApp.git
cd StudentManager-ConsoleApp
dotnet run
