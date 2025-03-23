IF EXISTS (SELECT * FROM sys.databases WHERE name = 'Airport')
BEGIN
    PRINT 'Dropping database Airport';
    ALTER DATABASE Airport SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE Airport;
END
ELSE
BEGIN
    PRINT 'Database Airport does not exist';
END
