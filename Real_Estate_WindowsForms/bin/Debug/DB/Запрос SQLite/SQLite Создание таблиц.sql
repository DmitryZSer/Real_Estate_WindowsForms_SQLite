-- Создание таблицы "Человек"
CREATE TABLE Person (
    Code INTEGER PRIMARY KEY AUTOINCREMENT,
    LastName TEXT NOT NULL,
    FirstName TEXT NOT NULL,
    MiddleName TEXT NOT NULL,
    BirthDate DATE NOT NULL,
    Phone TEXT NOT NULL,
    Email TEXT
);

-- Создание таблицы "Профессии"
CREATE TABLE Professions (
    Code INTEGER PRIMARY KEY AUTOINCREMENT,
    ProfessionName TEXT NOT NULL,
    Salary REAL NOT NULL
);

-- Создание таблицы "Сотрудники"
CREATE TABLE Employees (
    PersonCode INTEGER NOT NULL,
    ProfessionCode INTEGER NOT NULL,
    FOREIGN KEY (PersonCode) REFERENCES Person(Code),
    FOREIGN KEY (ProfessionCode) REFERENCES Professions(Code)
);

-- Создание таблицы "Тип недвижимости"
CREATE TABLE TypeOfRealEstate(
    Code INTEGER PRIMARY KEY AUTOINCREMENT,
    NameOfTheRealEstateType TEXT NOT NULL
);

-- Создание таблицы "Объект недвижимости"
CREATE TABLE RealEstate (
    Code INTEGER PRIMARY KEY AUTOINCREMENT,
    OwnerCode INTEGER NOT NULL,
    Address TEXT NOT NULL,
    SquareMeters REAL NOT NULL,
    TypeOfRealEstateCode INTEGER NOT NULL,
    Price REAL NOT NULL,
    FOREIGN KEY (OwnerCode) REFERENCES Person(Code),
    FOREIGN KEY (TypeOfRealEstateCode) REFERENCES TypeOfRealEstate(Code)
);

-- Создание таблицы "Сделки"
CREATE TABLE Deals (
    Code INTEGER PRIMARY KEY AUTOINCREMENT,
    DealDate DATE NOT NULL,
    EmployeeCode INTEGER NOT NULL,
    RealEstateCode INTEGER NOT NULL, 
    Commission REAL,
    FOREIGN KEY (EmployeeCode) REFERENCES Employees(PersonCode),
    FOREIGN KEY (RealEstateCode) REFERENCES RealEstate(Code)
);

-- Создание таблцы Users, выполняет служебную фкнкцию для 
-- авторизации пользователей и разделения ролей
CREATE TABLE "Users" (
	"Code"	INTEGER NOT NULL UNIQUE,
	"Login"	TEXT NOT NULL UNIQUE,
	"Password"	TEXT NOT NULL,
	PRIMARY KEY("Code" AUTOINCREMENT)
);