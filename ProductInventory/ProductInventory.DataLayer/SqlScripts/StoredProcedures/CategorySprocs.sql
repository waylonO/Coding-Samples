
CREATE PROCEDURE CategoryInsert (
	@CategoryName varchar(25)
)
AS

INSERT INTO Category (CategoryName)
VALUES (@CategoryName)

GO

CREATE PROCEDURE CategoryUpdate (
	@CategoryID int,
	@CategoryName varchar(25)
)
AS

UPDATE Category
SET	CategoryName = @CategoryName
WHERE CategoryID = @CategoryID

GO

CREATE PROCEDURE CategorySelect (
	@CategoryID int
)
AS

SELECT CategoryID, CategoryName
FROM Category
WHERE CategoryID = @CategoryID

GO

CREATE PROCEDURE CategorySelectAll
AS

SELECT CategoryID, CategoryName
FROM Category

GO

CREATE PROCEDURE CategoryDelete (
	@CategoryID int
)
AS

DELETE FROM Category
WHERE CategoryID = @CategoryID

GO

CREATE PROCEDURE SubcategorySelectByCategory (
	@CategoryId int
)
AS

SELECT SubcategoryId, CategoryId, SubcategoryName
FROM Subcategory
WHERE CategoryId = @CategoryId

GO