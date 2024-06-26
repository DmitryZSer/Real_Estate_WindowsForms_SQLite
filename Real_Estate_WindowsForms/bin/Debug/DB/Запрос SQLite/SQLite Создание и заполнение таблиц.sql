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

-- Заполнение таблицы "Профессии в недвижимости"
INSERT INTO Professions (ProfessionName, Salary)
VALUES
('Риелтор', 30000.00),
('Менеджер по недвижимости', 40000.00),
('Агент по продажам', 35000.00),
('Старший риелтор', 45000.00),
('Директор агентства недвижимости', 55000.00);

-- Создание таблицы "Сотрудники"
CREATE TABLE Employees (
    PersonCode INTEGER NOT NULL,
    ProfessionCode INTEGER NOT NULL,
    FOREIGN KEY (PersonCode) REFERENCES Person(Code),
    FOREIGN KEY (ProfessionCode) REFERENCES Professions(Code)
);

-- Заполнение таблицы "Person"
INSERT INTO Person (LastName, FirstName, MiddleName, BirthDate, Phone, Email)
VALUES
('Иванов', 'Иван', 'Иванович', '1990-05-15', '+7 (123) 456-7890', 'ivan@example.com'),
('Петров', 'Петр', 'Петрович', '1985-08-20', '+7 (987) 654-3210', 'petr@example.com'),
('Сидорова', 'Елена', 'Петровна', '1995-03-10', '+7 (777) 123-4567', 'elena@example.com'),
('Смирнов', 'Андрей', 'Андреевич', '1988-12-05', '+7 (222) 987-6543', 'andrey@example.com'),
('Козлов', 'Сергей', 'Игоревич', '1992-06-25', '+7 (111) 567-8901', 'sergey@example.com'),
('Новиков', 'Александр', 'Александрович', '1993-07-12', '+7 (777) 777-7777', 'alexander@mail.ru'),
('Федорова', 'Ольга', 'Викторовна', '1986-09-18', '+7 (999) 999-9999', 'olga@gmail.com'),
('Кузнецов', 'Дмитрий', 'Дмитриевич', '1991-11-24', '+7 (555) 555-5555', 'dmitri@yandex.ru'),
('Морозов', 'Егор', 'Алексеевич', '1989-04-30', '+7 (333) 333-3333', 'egor@mail.ru'),
('Николаева', 'Татьяна', 'Сергеевна', '1997-02-14', '+7 (222) 222-2222', 'tatiana@gmail.com'),
('Лебедев', 'Артем', 'Алексеевич', '1994-08-03', '+7 (444) 444-4444', 'artem@yandex.ru'),
('Макарова', 'Анастасия', 'Ивановна', '1990-12-08', '+7 (888) 888-8888', 'anastasia@gmail.com'),
('Зайцев', 'Игорь', 'Артемович', '1996-06-20', '+7 (666) 666-6666', 'igor@mail.ru'),
('Соловьева', 'Мария', 'Дмитриевна', '1987-03-26', '+7 (111) 111-1111', 'maria@yandex.ru'),
('Васильев', 'Владимир', 'Сергеевич', '1988-10-05', '+7 (999) 888-7777', 'vladimir@gmail.com'),
('Григорьев', 'Михаил', 'Юрьевич', '1991-05-20', '+7 (321) 654-9870', 'mikhail@example.com'),
('Воробьева', 'Екатерина', 'Сергеевна', '1984-11-30', '+7 (321) 111-2222', 'ekaterina@example.com'),
('Орлова', 'Анна', 'Игоревна', '1992-01-25', '+7 (555) 222-3333', 'anna@example.com'),
('Крылов', 'Виталий', 'Алексеевич', '1987-07-19', '+7 (777) 333-4444', 'vitaly@example.com'),
('Медведева', 'Дарья', 'Андреевна', '1995-03-15', '+7 (999) 444-5555', 'daria@example.com'),
('Борисов', 'Георгий', 'Петрович', '1990-08-25', '+7 (111) 555-6666', 'georgy@example.com'),
('Романов', 'Николай', 'Васильевич', '1989-04-05', '+7 (333) 666-7777', 'nikolay@example.com'),
('Миронова', 'Евгения', 'Ивановна', '1986-12-12', '+7 (555) 777-8888', 'evgeniya@example.com'),
('Фролов', 'Станислав', 'Михайлович', '1993-06-20', '+7 (777) 888-9999', 'stanislav@example.com');

-- Заполнение таблицы "Employees"
INSERT INTO Employees (PersonCode, ProfessionCode)
VALUES
(3,1),
(4,1),
(5,2),
(6,3),
(7,4),
(8,2),
(9,3),
(10,1),
(11,4),
(12,2);

-- Создание таблицы "Тип недвижимости"
CREATE TABLE TypeOfRealEstate(
    Code INTEGER PRIMARY KEY AUTOINCREMENT,
    NameOfTheRealEstateType TEXT NOT NULL
);

-- Заполнение таблицы "TypeOfRealEstate"
INSERT INTO TypeOfRealEstate (NameOfTheRealEstateType)
VALUES
('Квартира'),
('Комната'),
('Дом, дача, коттедж'),
('Земельный участок'),
('Гараж и машиноместо'),
('Коммерческая недвижимость');

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

-- Заполнение таблицы "RealEstate"
INSERT INTO RealEstate (OwnerCode, Address, SquareMeters, TypeOfRealEstateCode, Price)
VALUES
(2, 'Ул. Примерная, 123', 80.5, 1, 6300000),
(8, 'Ул. Тестовая, 456', 120.0, 3, 13400000),
(9, 'Ул. Новая, 789', 65.2, 4, 4000000),
(10, 'Ул. Главная, 111', 95.3, 2, 11400000),
(1, 'Ул. Первая, 222', 110.8, 6, 17400000),
(3, 'Ул. Вторая, 333', 75.0, 2, 8200000),
(4, 'Ул. Третья, 444', 85.7, 1, 9700000),
(5, 'Ул. Четвертая, 555', 95.1, 3, 11300000),
(6, 'Ул. Пятая, 666', 105.6, 4, 12400000),
(7, 'Ул. Шестая, 777', 115.8, 5, 13500000);

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

-- Заполнение таблицы "Deals"
INSERT INTO Deals (DealDate, EmployeeCode, OwnerCode, RealEstateCode, Commission)
VALUES
('2023-05-10', 1, 1, 5000.00),
('2023-05-11', 2, 2, 7500.00),
('2023-05-12', 2, 3, 3750.00),
('2023-05-13', 4, 4, 6250.00),
('2023-05-14', 5, 5, 7000.00),
('2023-05-15', 6, 6, 8000.00),
('2023-05-16', 7, 7, 9500.00),
('2023-05-17', 8, 8, 6700.00),
('2023-05-18', 9, 9, 7200.00),
('2023-05-19', 10, 10, 8700.00);

-- Создание таблцы Users, выполняет служебную фкнкцию для 
-- авторизации пользователей и разделения ролей
CREATE TABLE "Users" (
	"Code"	INTEGER NOT NULL UNIQUE,
	"Login"	TEXT NOT NULL UNIQUE,
	"Password"	TEXT NOT NULL,
	PRIMARY KEY("Code" AUTOINCREMENT)
);