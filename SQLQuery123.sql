CREATE DATABASE compshop;
USE compshop;

CREATE TABLE Покупатели (
    id_покупателя INT PRIMARY KEY IDENTITY(1,1),
    имя VARCHAR(255) NOT NULL,
    адрес VARCHAR(255) NOT NULL,
    телефон VARCHAR(20) NOT NULL
);

CREATE TABLE Компьютеры (
    id_компьютера INT PRIMARY KEY IDENTITY(1,1),
    процессор VARCHAR(255),
    видеокарта VARCHAR(255),
    оперативная_память VARCHAR(255),
    цена DECIMAL(10, 2),
количество INT
);

CREATE TABLE Ноутбуки (
    id_ноутбука INT PRIMARY KEY IDENTITY(1,1),
    модель VARCHAR(255),
    процессор VARCHAR(255),
    экран VARCHAR(255),
    цена DECIMAL(10, 2),
    количество INT
);

CREATE TABLE Мышки_и_клавиатуры (
    id_мышки_клавиатуры INT PRIMARY KEY IDENTITY(1,1),
    тип VARCHAR(255),
    производитель VARCHAR(255),
    цена DECIMAL(10, 2),
количество INT
);


CREATE TABLE Заказы (
    id_заказа INT PRIMARY KEY IDENTITY(1,1),
    id_покупателя INT,
    id_компьютера INT,
    id_ноутбука INT,
    id_мышки_клавиатуры INT,
    FOREIGN KEY (id_покупателя) REFERENCES Покупатели(id_покупателя),
    FOREIGN KEY (id_компьютера) REFERENCES Компьютеры(id_компьютера),
    FOREIGN KEY (id_ноутбука) REFERENCES Ноутбуки(id_ноутбука),
    FOREIGN KEY (id_мышки_клавиатуры) REFERENCES Мышки_и_клавиатуры(id_мышки_клавиатуры)
);


INSERT INTO Покупатели (имя, адрес, телефон) VALUES
('Иван Иванов', 'ул. Ленина, 1', '89123456789'),
('Петр Петров', 'ул. Кирова, 2', '89123456790'),
('Никита Сидоров', 'ул. Свободы, 3', '89123456791'),
('Алексей Алексеев', 'ул. Мира, 4', '89123456792'),
('Федор Дмитриев', 'ул. Победы, 5', '89123456793'),
('Александр Андреев', 'ул. Советская, 6', '89123456794');

INSERT INTO Компьютеры (процессор, видеокарта, оперативная_память, цена) VALUES
('Intel i5', 'Nvidia GTX 1650', '8GB', 60000),
('AMD Ryzen 5', 'AMD Radeon RX 6600', '16GB', 80000),
('Intel i7', 'Nvidia RTX 3060', '32GB', 120000),
('AMD Ryzen 7', 'AMD Radeon RX 6700 XT', '16GB', 100000),
('Intel i9', 'Nvidia RTX 3070', '32GB', 150000),
('AMD Ryzen 9', 'AMD Radeon RX 6800', '64GB', 180000);

INSERT INTO Ноутбуки (модель, процессор, экран, цена) VALUES
('Acer Aspire 5', 'Intel i3', '15.6"', 40000),
('HP Pavilion', 'AMD Ryzen 3', '14"', 50000),
('Lenovo IdeaPad', 'Intel i5', '17.3"', 70000),
('ASUS VivoBook', 'AMD Ryzen 5', '15.6"', 60000),
('Dell Inspiron', 'Intel i7', '14"', 80000),
('MSI Stealth', 'Intel i9', '17.3"', 120000);

INSERT INTO Мышки_и_клавиатуры (тип, производитель, цена) VALUES
('Мышь проводная', 'Logitech', 1500),
('Клавиатура проводная', 'Оклик', 4000),
('Мышь беспроводная', 'Razer', 3000),
('Клавиатура беспроводная', 'Logitech', 6000),
('Геймпад', 'Microsoft', 5000),
('Мышь вертикальная', 'Defender', 2500);

CREATE login admin with password = '5TGBnhy6';
CREATE login pokupat;

CREATE USER Admin for login admin;
CREATE USER Pokupat for login pokupat;

CREATE ROLE role_Admin;
CREATE ROLE role_Pokupat;

grant select, delete, insert, update ON Покупатели to role_Admin;
grant select, delete, insert, update ON Компьютеры to role_Admin;
grant select, delete, insert, update ON Ноутбуки to role_Admin;
grant select, delete, insert, update ON Мышки_и_клавиатуры to role_Admin;
grant select, delete, insert, update ON Заказы to role_Admin;

grant select, insert ON Заказы to role_Pokupat;
grant select, insert ON Покупатели to role_Pokupat;

exec 
sp_addrolemember role_Admin, Admin;
go
sp_addrolemember role_Pokupat, Pokupat;
go