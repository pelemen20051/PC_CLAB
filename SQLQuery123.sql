CREATE DATABASE DB_PC;

-- ������� ��� �������
CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NULL,
    Price DECIMAL(10, 2) NULL,
    Category NVARCHAR(50) NULL
);
INSERT INTO Products (Name, Price, Category) VALUES 
('�� Lenovo', 50000, '����������'),
('������� HP', 70000, '��������'),
('���������� Logitech', 2000, '����������'),
('���� Razer', 3000, '����');

-- ������� ��� �������
CREATE TABLE Orders (
    Id INT PRIMARY KEY IDENTITY,
    CustomerName NVARCHAR(100) NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    Phone NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    ProductIds NVARCHAR(MAX) NOT NULL
);
SELECT * FROM Orders;
--string connectionString = "Data Source=DESKTOP-777FV0N\\KAZI2005;Initial Catalog=DB_PC;Integrated Security=True";