DELETE FROM Category
DBCC CHECKIDENT ('Category', RESEED, 0)

INSERT INTO Category(CategoryName)
VALUES ('Clothing'),
('Groceries'),
('Electronics')

