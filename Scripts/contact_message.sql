
--Completarea unui Formular de Contact

CREATE OR ALTER PROCEDURE contact_message
    @first_name NVARCHAR(20),
    @last_name NVARCHAR(20),
    @email NVARCHAR(50),
    @phone_number NVARCHAR(11),
    @message NVARCHAR(1000)
AS
    INSERT INTO Contact2(first_name, last_name, email, phone_number, message_text)
    VALUES (@first_name, @last_name, @email, @phone_number, @message)
GO

exec contact_message 
    @first_name = 'ana', 
    @last_name = 'popescu', 
    @email = 'ana@gmail.com', 
    @phone_number = '0734343434',
    @message = 'F tare';
go

SELECT * FROM Contact2;
